using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable
{
	public class EndlessMawTrophy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Maw Trophy");
			Tooltip.SetDefault("'You are the killer of Maw.'");
		}
		public override void SetDefaults()
		{
            item.width = 24;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 1;
            item.createTile = mod.TileType("EndlessMawTrophyTile");
            item.placeStyle = 0;
		}
	}
}