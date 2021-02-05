using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Dracarnium
{
    public class DracarniumSparkRanged : ModProjectile
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
            DisplayName.SetDefault("Dracarnium Spark");
		}
        public override void SetDefaults()
        {
		    projectile.CloneDefaults(401);
            projectile.width = 12;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.thrown = true;
			projectile.magic = false;
			projectile.melee = false;
            projectile.alpha = 125;
            projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 300; //The amount of time the projectile is alive for
            projectile.light = 0.60f; //This defines the projectile light
            projectile.glowMask = customGlowMask;
        }
        public override void AI()
        {
            int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

            target.AddBuff(mod.BuffType("DracarniumFlames"), 240);
            target.immune[projectile.owner] = 4;
        }
    }
}