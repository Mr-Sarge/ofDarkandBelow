using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles.DragonShrine
{
	public class AncientCloudTile : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][33] = true;
            Main.tileMerge[Type][1] = true;
            Main.tileMerge[Type][189] = true;
            Main.tileMerge[Type][mod.TileType("DragonStoneATile")] = true;
            Main.tileMerge[Type][mod.TileType("DragonSoilTile")] = true;
            Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("AncientCloudItem");
            dustType = mod.DustType("DragonBlockDust");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Ancient Cloud");
            AddMapEntry(new Color(156, 145, 134));
            minPick = 55;
            mineResist = 0.9f;
        }
	}
}