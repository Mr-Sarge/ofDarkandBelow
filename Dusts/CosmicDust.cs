using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Dusts
{
	public class CosmicDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
			dust.velocity.X *= 0.6f;
			dust.scale *= 1.2f;
            dust.noGravity = true;
		}

		public override bool MidUpdate(Dust dust) {
			if (!dust.noGravity) {
				dust.velocity.Y += 0.15f;
			}

			if (dust.noLight) {
				return false;
			}

			float strength = dust.scale * 1.2f;
			if (strength > 1f) {
				strength = 1f;
			}
			Lighting.AddLight(dust.position, 0.3f * strength, 0f * strength, 0.3f * strength);
			return false;
		}
	}
}