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
	public class CobaltShurikenProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(48);
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = 1;
		}
		public override void AI()
		{
			projectile.rotation += 0.1f * (float)projectile.direction;
			int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 14, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
			Main.dust[DustID4].noGravity = true;
		}
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
			Player player = Main.player[projectile.owner];
			player.armorPenetration += 5;
		}
    }
}