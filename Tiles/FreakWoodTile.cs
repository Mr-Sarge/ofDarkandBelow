using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles
{
	public class FreakWoodTile : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][33] = true; //Merges with Wood
            Main.tileMerge[Type][1] = true; //Merges with Stone
            Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("FreakWoodItem");
			AddMapEntry(new Color(Color.Green.R, Color.Green.G, Color.Green.B));
		}
	}
}