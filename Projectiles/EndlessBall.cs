﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class EndlessBall : ModProjectile
    {
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Endless Spike Ball");
		}
        public override void SetDefaults()
        {
		    projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.ranged = false;
			projectile.magic = true;
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
            projectile.light = 0.60f; //This defines the projectile light
        }
        public override void AI()
        {
            int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

            target.AddBuff(mod.BuffType("CosmicFlame"), 200);    //this adds a buff to the npc hit. 210 it the time of the buff
        }
			public override void Kill(int timeLeft)
            {
			Main.PlaySound(SoundID.Item14, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
            Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/EndlessBallBroke1"), 1f);
            Gore.NewGore(projectile.position, -projectile.velocity, mod.GetGoreSlot("Gores/EndlessBallBroke2"), 1f);
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