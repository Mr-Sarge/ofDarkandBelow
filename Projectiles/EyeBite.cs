using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
	public class EyeBite : ModProjectile
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			projectile.width = 20;
			projectile.height = 30;
			projectile.alpha = 60;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.melee = true;
			projectile.timeLeft = 400;
		}

		public override void AI() {
                                 
           projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;  
        }
		public override void Kill(int timeLeft) {
			Main.PlaySound(SoundID.NPCDeath1);
			Vector2 usePos = projectile.position; // Position to use for dusts
												  // Please note the usage of MathHelper, please use this! We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
            Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/EyeBiteGore1"), 1f);
			Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/EyeBiteGore2"), 1f);
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X * 0.5f, projectile.velocity.Y * 1f);
	    }
    }
}