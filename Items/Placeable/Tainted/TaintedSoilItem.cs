using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.Tainted
{
	public class TaintedSoilItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tainted Soil");
			Tooltip.SetDefault("'A foul, dry crumbling substance that wriggles in your hand.'");
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
            item.createTile = mod.TileType("TaintedSoilTile");
            item.placeStyle = 0;
		}
	}
}