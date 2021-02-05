using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Dracarnium
{
    public class BlackArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 40;
            projectile.alpha = 60;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 3;
            projectile.melee = false;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            aiType = 1;
        }

        public override void AI()
        {
            int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
            int DustID5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
            int DustID6 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
            Main.dust[DustID4].noGravity = true;
            Main.dust[DustID5].noGravity = true;
            Main.dust[DustID6].noGravity = true;
            Lighting.AddLight(projectile.Center, 0.67f, 0.13f, 0.88f);
        }
        public override void Kill(int timeLeft)
        {
            Vector2 usePos = projectile.position; // Position to use for dusts
                                                  // Please note the usage of MathHelper, please use this! We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
            Vector2 rotVector =
            (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
            usePos += rotVector * 16f;

            // Spawn some dusts upon javelin death
            for (int i = 0; i < 20; i++)
            {
                // Create a new dust
                Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, mod.DustType("TaintedDust"));
                dust.position = (dust.position + projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 2f;
                dust.noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            target.AddBuff(mod.BuffType("DracarniumFlames"), 360);
            target.AddBuff(mod.BuffType("HidepiercedDebuff"), 900);
        }
    }
}