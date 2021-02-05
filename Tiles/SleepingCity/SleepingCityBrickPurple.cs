using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles.SleepingCity
{
	public class SleepingCityBrickPurple : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][33] = true;
            Main.tileMerge[Type][1] = true;
            Main.tileMerge[Type][189] = true;
            Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
            soundType = 21;
            drop = mod.ItemType("SleepingCityBrickPurpleItem");
            dustType = mod.DustType("SleepingCityBrickDust");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sleeping City Brick");
            AddMapEntry(new Color(79, 60, 94));
            minPick = 500;
            mineResist = 1.4f;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}