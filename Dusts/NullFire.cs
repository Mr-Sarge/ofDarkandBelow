using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Dusts
{
	public class NullFire : ModDust
	{
		public int smallening;
		public override void OnSpawn(Dust dust) {
			dust.velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
			dust.velocity.X *= 0.3f;
			dust.scale *= 1f;
		}

		public override bool MidUpdate(Dust dust) 
		{
			bool flag5 = WorldGen.SolidTile(Framing.GetTileSafely((int)dust.position.X / 16, (int)dust.position.Y / 16));
			smallening++;
			if (!dust.noGravity) {
				dust.velocity.Y += 0.025f;
			}

			if (dust.noLight) {
				return false;
			}
			float strength;
			if (flag5)
			{
				strength = dust.scale * 0.25f;
			}
			else
			{
				strength = dust.scale * 0.5f;
			}
			Lighting.AddLight(dust.position, 0f * strength, 0.45f * strength, 0.45f * strength);
			if (smallening == 5)
			{
				dust.scale -= 0.05f;
				smallening = 0;
			}
			if (dust.scale == 0)
			{
				dust.active = false;
			}
			if (Collision.SolidCollision(dust.position + dust.velocity, 10, 10) && dust.fadeIn == 0f)
            {
				dust.scale -= 0.05f;
            }
			return false;
		}
	}
}