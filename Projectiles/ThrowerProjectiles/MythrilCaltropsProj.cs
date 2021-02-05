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
	public class MythrilCaltropsProj : ModProjectile
	{
		public bool stopSpinning;
		public override void SetDefaults()
		{
			projectile.CloneDefaults(48);
			projectile.width = 26;
			projectile.height = 24;
			projectile.penetrate = 15;
			projectile.timeLeft = 600;
			projectile.thrown = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 40;
			stopSpinning = false;
		}
		public override void AI()
		{
			if (stopSpinning == false)
			{
				projectile.rotation += 0.1f * (float)projectile.direction;
			}
			int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 42, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
			Main.dust[DustID4].noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			projectile.velocity = Vector2.Zero;
			stopSpinning = true;
			return false;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
			Player player = Main.player[projectile.owner];
			player.armorPenetration += 10;
		}
    }
}