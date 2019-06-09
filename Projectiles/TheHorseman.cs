using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
	public class TheHorseman : ModProjectile
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("The Horseman");
			Main.projFrames[projectile.type] = 8;
		}

		public override void SetDefaults() {
			projectile.width = 300;
			projectile.height = 192;
			projectile.alpha = 60;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.magic = true;
			projectile.timeLeft = 400;
			projectile.penetrate = 2000;
		}

		public override void AI() {
			if (++projectile.frameCounter >= 8) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 7) {
					projectile.frame = 0;
	    }
           projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);  
           Lighting.AddLight(projectile.Center, 1f, 0.6f, 0f);
		   projectile.aiStyle = 274;
		   aiType = ProjectileID.DeathSickle;
		   projectile.rotation += 0.3f;
		   int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
		   Main.dust[dust].scale = 5f;
        }
    }
}}