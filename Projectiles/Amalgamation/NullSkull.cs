using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Amalgamation
{
    public class NullSkull : ModProjectile
    {
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Null Skull");
			Main.projFrames[projectile.type] = 2;
		}
        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 32;
			projectile.scale = 1f;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
			projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.light = 0.60f;
			projectile.aiStyle = ProjectileID.Skull;
			aiType = ProjectileID.Skull;
        }
        public override void AI()
        {
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2) {
					projectile.frame = 0;
				}
			}
            int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 33, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
        }

    public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
    {
            target.AddBuff(BuffID.Obstructed, 60);
            target.AddBuff(BuffID.WitheredArmor, 60);
	}
			public override void Kill(int timeLeft) {
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts
												  // Please note the usage of MathHelper, please use this! We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
			Vector2 rotVector =
				(projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < 20; i++) {
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 33);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
			}
	    }
    }
}