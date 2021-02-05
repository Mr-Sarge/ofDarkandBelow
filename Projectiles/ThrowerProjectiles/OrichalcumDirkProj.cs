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
namespace ofDarkandBelow.Projectiles.ThrowerProjectiles
{
	public class OrichalcumDirkProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(48);
			projectile.width = 24;
			projectile.height = 22;
			projectile.penetrate = 1;
		}
		public override void AI()
		{
			projectile.rotation += 0.4f * (float)projectile.direction;
			int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 86, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
			Main.dust[DustID4].noGravity = true;
		}

		public override void OnHitNPC(NPC target , int damage, float knockback, bool crit)
		{
			int numberProjectiles = Main.rand.Next(1, 3); // Shoots between 1 to 3 projectiles.
			for (int index = 0; index < numberProjectiles; ++index)
			{
				Player player = Main.player[projectile.owner];
				float SpeedX = (float)Main.rand.Next(-61, 60) * 0.02f; //change the Main.rand.Next here to, for example, (-10, 11) to reduce the spread. Change this to 0 to remove it altogether
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y-800, SpeedX, 11f, 221, damage/2, 0, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
			}
		}
	}
}