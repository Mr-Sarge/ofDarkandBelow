using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.SleepingCity
{
	public class SleepingCityBrickPurpleItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("City Brick");
			Tooltip.SetDefault("'Purple, Ancient, Forgotten.'");
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
            item.createTile = mod.TileType("SleepingCityBrickPurple");
            item.placeStyle = 0;
		}
	}
}