using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles.NullBlocks
{
	public class NullifiedBrick : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][33] = true;
			Main.tileMerge[Type][1] = true;
			Main.tileMerge[Type][189] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("NullifiedBrickItem");
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Nullified Brick");
			AddMapEntry(new Color(67, 117, 106));
			Main.tileMerge[Type][TileID.GreenDungeonBrick] = true;
			Main.tileMerge[Type][TileID.BlueDungeonBrick] = true;
			Main.tileMerge[Type][TileID.PinkDungeonBrick] = true;
			minPick = 100;
			mineResist = 1.5f;
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			i = 1;
			r = 0.26f;
			g = 0.45f;
			b = 0.41f;
		}
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
	}
}