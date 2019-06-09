using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
	public class ScalibaarProj : ModProjectile
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			projectile.width = 18;
			projectile.height = 88;
			projectile.alpha = 20;
            projectile.CloneDefaults(132);
		}

		public override void AI() {
                                 
           projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
           int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 21, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 17, default(Color), 1f);
           Main.dust[dust].velocity /= 30f;  //this modify the velocity of the first dust
           Main.dust[dust].scale = 1f;  //this modify the scale of the first dust
        }
		public override void Kill(int timeLeft) {
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts
												  // Please note the usage of MathHelper, please use this! We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
			Vector2 rotVector =
				(projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < 20; i++) {
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 17);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
	    }   }
    }
}