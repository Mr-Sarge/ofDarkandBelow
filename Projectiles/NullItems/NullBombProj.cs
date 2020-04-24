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
namespace ofDarkandBelow.Projectiles.NullItems
{
	public class NullBombProj : ModProjectile
	{
        public override void SetDefaults()
        {
		    projectile.CloneDefaults(ProjectileID.Grenade);
			projectile.width = 28;
			projectile.height = 24;
			projectile.alpha = 60;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.melee = false;
			projectile.thrown = true;;
			projectile.timeLeft = 200;
        }
	    public override void Kill(int timeLeft) {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 5;
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ExplodingSpirit"), (int) (projectile.damage * 0.8), projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextBool(3)) {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ExplodingSpirit"), (int) (projectile.damage * 0.8), projectile.knockBack, Main.myPlayer);
			}
			if (Main.rand.NextBool(4)) {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ExplodingSpirit"), (int) (projectile.damage * 0.8), projectile.knockBack, Main.myPlayer);
			}
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
 
                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                        Dust.NewDust(position, 22, 22, 89, 0.0f, 0.0f, mod.DustType("NullFire"), new Color(), 1f);  //this is the dust that will spawn
					}
				}
			}
		}
	}
}