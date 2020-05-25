using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Tiles.DragonShrine
{
	public class DragonStoneWallTile : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(63, 58, 52));
		}
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override void KillWall(int i, int j, ref bool fail)
        {
            fail = true;
        }
    }
}