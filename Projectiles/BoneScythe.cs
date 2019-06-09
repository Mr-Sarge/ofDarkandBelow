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
	public class BoneScythe : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.width = 76;
			projectile.height = 60;
			projectile.alpha = 60;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = 5;
			projectile.melee = true;
			projectile.timeLeft = 400;
		}

		public override void AI() {
           Lighting.AddLight(projectile.Center, 1f, 0.6f, 0f);
		   projectile.aiStyle = 274;
		   aiType = ProjectileID.DeathSickle;
		   projectile.rotation += 0.3f;
		   int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
		   Main.dust[dust].scale = 1f;
        }
    }
}