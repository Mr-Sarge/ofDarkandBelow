using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Dusts
{
	public class NullDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
			dust.velocity.X *= 0.3f;
			dust.scale *= 1.2f;
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
			Lighting.AddLight(dust.position, 0.4f * strength, 1.2f * strength, 1.1f * strength);
			return false;
		}
	}
}