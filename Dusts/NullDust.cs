using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Dusts
{
	public class NullDust : ModDust
	{
		public int smallening;
		public override void OnSpawn(Dust dust) {
			dust.velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
			dust.velocity.X *= 0.3f;
			dust.scale *= 1f;
		}

		public override bool MidUpdate(Dust dust) 
		{
			smallening++;
			if (!dust.noGravity) {
				dust.velocity.Y += 0.025f;
			}

			if (dust.noLight) {
				return false;
			}
			float strength = dust.scale * 0.75f;
			Lighting.AddLight(dust.position, 0f * strength, 0.5f * strength, 0.5f * strength);
			if (smallening == 4)
			{
				dust.scale -= 0.05f;
				smallening = 0;
			}
			if (dust.scale == 0)
			{
				dust.active = false;
			}
			return false;
		}
	}
}