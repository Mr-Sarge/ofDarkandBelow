using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Dracarnium
{
	public class DracarniumGlaiveProj : ModProjectile
	{
		public static Color lightColor = new Color(50, 25, 35);
		public static Vector2[] spearPos = new Vector2[]{ new Vector2(0, 0), new Vector2(30, -5), new Vector2(70, -30), new Vector2(70, 0), new Vector2(70, 30), new Vector2(30, 5), new Vector2(10, 0), new Vector2(130, 0), new Vector2(130, 0), new Vector2(10, 0) };

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Projectiles/Dracarnium/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            DisplayName.SetDefault("Dracarnium Great-Glaive");
		}	

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.timeLeft = 600;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
			projectile.alpha = 254;
            projectile.glowMask = customGlowMask;
        }

		public override void AI()
		{
			AIArcStabSpear(projectile, ref projectile.ai, false);
            int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
            Main.dust[DustID4].noGravity = true;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(mod.BuffType("DracarniumFlames"), 360);
		}

		public override bool PreDraw(SpriteBatch sb, Color dColor)
		{
			BaseDrawing.DrawProjectileSpear(sb, Main.projectileTexture[projectile.type], 0, projectile, null, 0f, 0f);
			return false;
		}

        public static void AIArcStabSpear(Projectile p, ref float[] ai, bool overrideKill = false)
        {
            Player plr = Main.player[p.owner];
            Item item = plr.inventory[plr.selectedItem];
            if (Main.myPlayer == p.owner && item != null && item.autoReuse && plr.itemAnimation == 1) { p.Kill(); return; } //prevents a bug with autoReuse and spears
            Main.player[p.owner].heldProj = p.whoAmI;
            Main.player[p.owner].itemTime = Main.player[p.owner].itemAnimation;
			Vector2 gfxOffset = new Vector2(0, plr.gfxOffY);
            AIArcStabSpear(p, ref ai, plr.Center + gfxOffset, BaseUtility.RotationTo(p.Center, p.Center + p.velocity), plr.direction, plr.itemAnimation, plr.itemAnimationMax, overrideKill, plr.frozen);
        }

        public static void AIArcStabSpear(Projectile p, ref float[] ai, Vector2 center, float itemRot, int ownerDirection, int itemAnimation, int itemAnimationMax, bool overrideKill = false, bool frozen = false)
        {
			if(p.timeLeft < 598) p.alpha -= 70; if(p.alpha < 0) p.alpha = 0;
            p.direction = ownerDirection;
			Vector2 oldCenter = p.Center;
            p.position.X = center.X - p.width * 0.5f;
            p.position.Y = center.Y - p.height * 0.5f;
			p.position += BaseUtility.RotateVector(default, BaseUtility.MultiLerpVector(1f - itemAnimation / (float)itemAnimationMax, spearPos), itemRot);		
            if (!overrideKill && Main.player[p.owner].itemAnimation == 0){ p.Kill(); }
            p.rotation = BaseUtility.RotationTo(center, oldCenter) + 2.355f;				
			if (p.direction == -1) { p.rotation -= 0f; }else
			if (p.direction == 1) { p.rotation -= 1.57f; }		
		}
    }
}