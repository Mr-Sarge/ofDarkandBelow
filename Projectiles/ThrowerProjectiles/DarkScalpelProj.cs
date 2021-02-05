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
	public class DarkScalpelProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(48);
			projectile.width = 20;
			projectile.height = 22;
			projectile.penetrate = -1;
		}
		public override void AI()
		{
			projectile.rotation += 0.4f * (float)projectile.direction;
			int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 14, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
			Main.dust[DustID4].noGravity = true;
		}
	}
}