using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles.Tainted
{
	public class TaintedSoilTile : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("TaintedSoilItem");
			AddMapEntry(new Color(Color.Green.R, Color.Green.G, Color.Green.B));
			Main.tileMerge[Type][mod.TileType("TaintedStoneTile")] = true;
		}
	}
}