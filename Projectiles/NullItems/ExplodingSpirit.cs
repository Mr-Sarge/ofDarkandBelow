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

namespace ofDarkandBelow.Projectiles.NullItems
{
    public class ExplodingSpirit : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(181);
            aiType = 388;
            projectile.netImportant = true;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 100;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.aiStyle = 66;
        }



        public override bool PreAI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, mod.DustType("NullFire"), Alpha: 50);
            Main.dust[dust].velocity.Y -= 1.2f;
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("BelowZero"), 160);
        }
		public override void Kill(int timeLeft)
		{
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
                        Dust.NewDust(position, 22, 22, 89, 0.0f, 0.0f, mod.DustType("NullFire"), new Color(), 1f);  //this is the dust that will spawn
					}
				}
			}
		}
    }
}