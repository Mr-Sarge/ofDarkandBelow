using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Dusts
{
	public class DragonBlockDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
			dust.velocity.X *= 0.52f;
			dust.scale *= 1f;
            dust.noGravity = true;
		}

		public override bool MidUpdate(Dust dust) {
			if (!dust.noGravity) {
				dust.velocity.Y += 0.25f;
			}

			if (dust.noLight) {
				return true;
			}

			float strength = dust.scale * 1.4f;
			if (strength > 1f) {
				strength = 1f;
			}
			return false;
		}
	}
}