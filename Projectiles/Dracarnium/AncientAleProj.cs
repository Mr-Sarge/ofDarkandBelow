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
namespace ofDarkandBelow.Projectiles.Dracarnium
{
	public class AncientAleProj : ModProjectile
	{
        public override void SetDefaults()
        {
            projectile.CloneDefaults(399);
            projectile.width = 18;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.thrown = false;
			projectile.timeLeft = 200;
            projectile.penetrate = 1;
        }
	    public override void Kill(int timeLeft) {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 5;
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 3) * 4, -projectile.velocity.Y + Main.rand.Next(1, 2) * 4)), mod.ProjectileType("DracarniumSparkRanged"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 2) * 4, -projectile.velocity.Y + Main.rand.Next(2, 3) * 4)), mod.ProjectileType("DracarniumSparkRanged"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 4) * 4, -projectile.velocity.Y + Main.rand.Next(1, 4) * 4)), mod.ProjectileType("DracarniumSparkRanged"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 2) * 4, -projectile.velocity.Y + Main.rand.Next(2, 4) * 4)), mod.ProjectileType("DracarniumSparkRanged"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
 
                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                        Dust.NewDust(position, 22, 22, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                    }
				}
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

            target.AddBuff(mod.BuffType("DracarniumFlames"), 340);
            target.immune[projectile.owner] = 5;
        }
    }
}