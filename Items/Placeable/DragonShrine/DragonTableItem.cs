using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonTableItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Shrine Table");
			Tooltip.SetDefault("'This table is way older than you'd think.'");
		}
		public override void SetDefaults()
		{
            item.width = 38;
            item.height = 24;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 3;
            item.createTile = mod.TileType("DragonTableTile");
            item.placeStyle = 0;
		}
	}
}