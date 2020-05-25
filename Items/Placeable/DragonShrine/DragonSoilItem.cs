using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonSoilItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Soil");
			Tooltip.SetDefault("'Made from the flesh of dragons... Older than you are.'");
		}
		public override void SetDefaults()
		{
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 2;
            item.createTile = mod.TileType("DragonSoilTile");
            item.placeStyle = 0;
		}
	}
}