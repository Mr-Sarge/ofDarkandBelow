using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles.DragonShrine
{
	public class DragonStoneATile : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][33] = true;
            Main.tileMerge[Type][1] = true;
            Main.tileMerge[Type][189] = true;
            Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
            Main.tileMerge[Type][mod.TileType("DragonSoilTile")] = true;
            Main.tileMerge[Type][mod.TileType("AncientCloudTile")] = true;
            soundType = 21;
            drop = mod.ItemType("DragonStoneAItem");
            dustType = mod.DustType("DragonBlockDust");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Dragon Shrine Stone");
            AddMapEntry(new Color(86, 79, 71));
            minPick = 205;
            mineResist = 1.1f;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}