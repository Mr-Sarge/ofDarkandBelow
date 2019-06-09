using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.Tainted
{
	public class TaintedStoneItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tainted Stone");
			Tooltip.SetDefault("'A grotesque and balmy rock with unknown origin."
			+  "\nThe lights emanating from it seem to follow your every move.'");
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
            item.rare = 2;
            item.createTile = mod.TileType("TaintedStoneTile");
            item.placeStyle = 0;
		}
	}
}