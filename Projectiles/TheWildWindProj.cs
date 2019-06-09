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

namespace ofDarkandBelow.Projectiles
{
	public class TheWildWindProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			// The following sets are only applicable to yoyo that use aiStyle 99.
			// YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
			// Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			// YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
			// Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 550f;
			// YoyosTopSpeed is top speed of the yoyo projectile. 
			// Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 19f;
		}
		private int spawnTimer;
		Vector2 position;
		float speedX;
		float speedY;
		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 14;
			projectile.height = 14;
			// aiStyle 99 is used for all yoyos, and is Extremely suggested, as yoyo are extremely difficult without them
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1.4f;
			spawnTimer++;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(BuffID.OnFire, 180);
			target.AddBuff(BuffID.CursedInferno, 180);
			target.AddBuff(BuffID.Bleeding, 220);
			target.AddBuff(BuffID.Poisoned, 180);
			target.AddBuff(BuffID.Venom, 180);
			target.AddBuff(BuffID.ShadowFlame, 120);
			target.AddBuff(BuffID.Ichor, 220);
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 5;
 
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
 
                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                        Dust.NewDust(position, 22, 22, 89, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn
					}
				}
			}
		}
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 89);   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 10f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = .9f;  //this modify the scale of the first dust
        }
	}
}