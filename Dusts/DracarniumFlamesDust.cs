using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Dusts
{
	public class DracarniumFlamesDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity.Y = Main.rand.Next(-10, 6) * 0.12f;
			dust.velocity.X *= 0.75f;
			dust.scale *= 1.1f;
            dust.noGravity = true;
		}

		public override bool MidUpdate(Dust dust) {
			if (!dust.noGravity) {
				dust.velocity.Y += 0.16f;
			}

			if (dust.noLight) {
				return false;
			}

			float strength = dust.scale * 1.2f;
			if (strength > 1f) {
				strength = 1f;
			}
			Lighting.AddLight(dust.position, 0.05f * strength, 0.05f * strength, 0.05f * strength);
			return false;
		}
        public override Color? GetAlpha(Dust dust, Color lightColor)
    => new Color(lightColor.R, lightColor.G, lightColor.B, 25);
    }
}