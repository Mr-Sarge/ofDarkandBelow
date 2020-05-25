using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;

namespace ofDarkandBelow.Waters
{
	public class ShrineWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
		{
			return !Main.gameMenu && Main.LocalPlayer.GetModPlayer<MyPlayer>().ZoneShrine;
        }

		public override int ChooseWaterfallStyle()
		{
			return mod.GetWaterfallStyleSlot("ShrineWaterfallStyle");
		}

		public override int GetSplashDust()
		{
			return mod.DustType("ShrineWaterSplash");
		}

		public override int GetDropletGore()
		{
			return mod.GetGoreSlot("Gores/ShrineDroplet");
		}

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 0.25f;
			g = 0.25f;
			b = 0f;
		}

		public override Color BiomeHairColor()
		{
			return Color.ForestGreen;
		}
	}
}