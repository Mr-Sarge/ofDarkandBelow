using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ofDarkandBelow.Projectiles;
namespace ofDarkandBelow.Projectiles.SunkenProj
{
	public class MushSpawnBig
        : ModProjectile
	{
        public override void SetDefaults()
        {
			projectile.width = 38;
			projectile.height = 44;
			projectile.alpha = 60;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.timeLeft = 260;
        }
		public override void AI() {
            projectile.rotation += 0.2f;
            projectile.velocity.Y = projectile.velocity.Y + 0.8f;
            if (projectile.velocity.Y > 20f)
            {
                projectile.velocity.Y = 20f;
            }
        }
		public override void Kill(int timeLeft) {
            Main.PlaySound(SoundID.NPCDeath1, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts
												  // Please note the usage of MathHelper, please use this! We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
			Vector2 rotVector =
				(projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < 20; i++) {
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 16);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 1.2f;
				dust.noGravity = true;
			}
            float Speed = 7.5f;  //projectile speed
            Vector2 vector8 = new Vector2(projectile.Center.X, projectile.Center.Y);
            int damage = 0;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
            int type = mod.ProjectileType("MushSpawn");  //put your projectile
            float rotation = (float)Math.Atan2(vector8.Y + (projectile.position.Y - (projectile.height * 0.5f)), vector8.X + (projectile.position.X - (projectile.width * 0.5f)));
            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -0.5), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
            int num55 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -0.25), (float)((Math.Sin(rotation) * Speed) * -1.5), type, damage, 0f, 0);
            int num56 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * 0.25), (float)((Math.Sin(rotation) * Speed) * -1.5), type, damage, 0f, 0);
            int num57 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * 0.5), (float)((Math.Sin(rotation) * Speed) * -2), type, damage, 0f, 0);
        }
	}
}