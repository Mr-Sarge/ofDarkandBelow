using ofDarkandBelow.Items;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.SunkenProj
{
	public class KingusBeamBig : ModProjectile
	{
        public override void SetDefaults()
        {
            projectile.alpha = 20;
            projectile.width = 34;
			projectile.height = 104;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.timeLeft = 400;
            projectile.light = 1f;
            aiType = 575;
            projectile.aiStyle = 575;
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
                Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 17);
                dust.position = (dust.position + projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
            }
        }
        private int speen;
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.0f, 0.0f, 0.6f);  //this defines the projectile light color
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16);   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 30f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 1f;
            Main.dust[dust].noGravity = true;
            speen++;
            if (speen <= 120)
            {
                projectile.velocity *= 0f;
                projectile.rotation += 0.15f;
            }
            if (speen >= 121)
            {
                projectile.rotation += 0.30f;
                if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 9000f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    Vector2 newMove = Main.player[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    projectile.velocity = (10 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }
            }
        }
            private void AdjustMagnitude(ref Vector2 vector)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 6f)
                {
                    vector *= 6f / magnitude;
                }
            }
    }
}