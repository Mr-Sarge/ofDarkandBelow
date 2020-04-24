using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Tiles
{
	public class FreakWallTile : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("FreakWallItem");
			AddMapEntry(new Color(210, 105, 30));
        }
    }
}