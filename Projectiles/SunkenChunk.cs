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
	public class SunkenChunk : ModProjectile
	{
        public override void SetDefaults()
        {
			projectile.width = 56;
			projectile.height = 52;
			projectile.alpha = 60;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.timeLeft = 260;
        }
		public override void AI() {
		projectile.rotation += 0.125f;
		}
		public override void Kill(int timeLeft) {
			Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
			Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
			NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, mod.NPCType("SunkenSoldier"));
			NPC.NewNPC((int)projectile.Center.X * 2, (int)projectile.Center.Y * 2, mod.NPCType("SunkenSoldier"));
			Main.PlaySound(SoundID.NPCDeath1, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts
												  // Please note the usage of MathHelper, please use this! We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
			Vector2 rotVector =
				(projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < 20; i++) {
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 16);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
			}
		}
	}
}