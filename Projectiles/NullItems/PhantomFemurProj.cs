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
	public class PhantomFemurProj : ModProjectile
	{
        public override void SetDefaults()
        {
			projectile.width = 28;
			projectile.height = 24;
			projectile.alpha = 60;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.melee = false;
			projectile.thrown = true;;
			projectile.timeLeft = 400;
			aiType = ProjectileID.Bone;
        }
		public override void AI() {
		projectile.rotation += 0.6f;
        int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("NullFire"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
        Main.dust[DustID2].noGravity = true;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("BelowZero"), 100);
        }
	}
}