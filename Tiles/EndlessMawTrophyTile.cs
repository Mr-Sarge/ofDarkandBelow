using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles
{
	public class EndlessMawTrophyTile : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			dustType = 7;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("EndlessMawTrophyTile");
			AddMapEntry(new Color(120, 85, 60), name);
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY) //this make that when you break the Trophy it will give you the TrophyItem
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("EndlessMawTrophy"));
		}
	}
}