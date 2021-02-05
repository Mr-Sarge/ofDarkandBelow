using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles.Behemoth
{
    public class BehemothBlockTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][33] = true;
            Main.tileMerge[Type][1] = true;
            Main.tileMerge[Type][189] = true;
            Main.tileMerge[Type][mod.TileType("BehemothPlatformTile")] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            soundType = 21;
            dustType = mod.DustType("HorrorHemorrhageDust");
            drop = mod.ItemType("BehemothBlock");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Behemoth Block");
            AddMapEntry(new Color(120, 109, 100));
            minPick = 150;
            mineResist = 1.1f;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}