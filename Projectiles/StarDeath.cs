using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class StarDeath : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star-Blind");
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 40;
            projectile.scale = 1f;
            projectile.timeLeft = 200;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.alpha = 100;
            aiType = ProjectileID.Starfury;
        }
        public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.Starfury;
            return true;
        }
        public override void AI()
        {
            int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("StarBlindDust"));
            Main.dust[DustID4].noGravity = true;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + -1.57f;
            Lighting.AddLight(projectile.position, 0f, 0.25f, 0.5f);
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
                Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, mod.DustType("StarBlindDust"));
                dust.position = (dust.position + projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 2f;
                dust.noGravity = true;
            }
        }
    }
}