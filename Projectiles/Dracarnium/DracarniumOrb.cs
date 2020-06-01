using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Dracarnium
{
    public class DracarniumOrb : ModProjectile
    {
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
            DisplayName.SetDefault("Dracarnium Orb");
		}
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.ranged = false;
			projectile.magic = false;
			projectile.melee = true;
            projectile.alpha = 125;
            projectile.penetrate = 6; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 300; //The amount of time the projectile is alive for
            projectile.light = 0.60f; //This defines the projectile light
            projectile.glowMask = customGlowMask;
            projectile.scale = 1.5f;
            aiType = 1;
        }
        public int bounceAmount;
        public override void AI()
        {
            if (projectile.ai[1] == 0)
            {
                bounceAmount = 4;
                projectile.ai[1] = 1;
            }
            int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
            projectile.velocity.Y = projectile.velocity.Y + 0.22f; // 0.1f for arrow gravity, 0.4f for knife gravity
            projectile.rotation += 6f;
            if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
            {
                projectile.velocity.Y = 16f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

            target.AddBuff(mod.BuffType("DracarniumFlames"), 240);
            target.immune[projectile.owner] = 4;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounceAmount--;
            if (bounceAmount <= 0)
            {
                projectile.Kill();
            }
            else
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }
    }
}