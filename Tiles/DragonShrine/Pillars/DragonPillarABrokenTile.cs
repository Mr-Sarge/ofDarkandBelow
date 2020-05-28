using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ofDarkandBelow.Tiles.DragonShrine.Pillars
{
	public class DragonPillarABrokenTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileTable[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = false;
            dustType = mod.DustType("DragonBlockDust");
            minPick = 75;
            mineResist = 1.4f;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Terraria.Item.NewItem(i * 16, j * 16, 64, 32, mod.ItemType("DragonPillarABrokenItem"));
        }
    }
}