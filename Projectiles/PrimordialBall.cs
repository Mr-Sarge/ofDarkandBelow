using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class PrimordialBall : ModProjectile
    {
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Primordial Spike Ball");
		}
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
			projectile.scale = 1.5f;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.ranged = false;
			projectile.magic = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 400;
            projectile.light = 0.60f;
			projectile.aiStyle = ProjectileID.ThornBall;
        }
        public override void AI()
        {
            int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 21, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
        }

    public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
    {
            target.AddBuff(mod.BuffType("CosmicFlame"), 600);
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
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 20);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
			}
	    }
    }
}