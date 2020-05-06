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
			projectile.width = 8;
			projectile.height = 8;
			projectile.alpha = 20;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.aiStyle = 0;
            projectile.penetrate = 1;
            projectile.scale = 1.15f;
            drawOffsetX = -62;
            drawOriginOffsetY = -20;
            drawOriginOffsetX = 31;
            projectile.timeLeft = 50;
        }

		public override void AI() {
            Lighting.AddLight(projectile.position, 0.678f, 0.847f, 0.902f);
            projectile.spriteDirection = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();
            // Adding Pi to rotation if facing left corrects the drawing
            projectile.rotation = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
            if (projectile.spriteDirection == 1) // facing right
            {
                drawOffsetX = -62;
                drawOriginOffsetY = -2;
                drawOriginOffsetX = 31;
            }
            else
            {
                drawOffsetX = 0;
                drawOriginOffsetY = -2; // doesn't change
                drawOriginOffsetX = -31;
            }
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 21, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 17, default(Color), 1f);
            Main.dust[dust].velocity /= 30f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 1f;  //this modify the scale of the first dust
        }
		public override void Kill(int timeLeft) {

            Vector2 position = projectile.Center;
            int radius = 5;

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.2)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 21, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1f);
                    }
                }
            }
        Main.PlaySound(SoundID.Item27, (int)projectile.position.X, (int)projectile.position.Y);
            for (int i = 0; i < 5; i++)
            {
                int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, mod.ProjectileType("ScalibaarHome"), (int)(projectile.damage * .25f), 0, projectile.owner);
                Main.projectile[a].aiStyle = 1;
                Main.projectile[a].tileCollide = true;
            }
        }
    }
}