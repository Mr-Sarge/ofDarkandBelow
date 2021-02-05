using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.NullBlocks
{
	public class NullifiedBrickItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nullified Bricks");
			Tooltip.SetDefault("'These bricks scream for release.'");
		}
		public override void SetDefaults()
		{
            item.width = 24;
            item.height = 22;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 0;
            item.createTile = mod.TileType("NullifiedBrick");
            item.placeStyle = 0;
		}
	}
}