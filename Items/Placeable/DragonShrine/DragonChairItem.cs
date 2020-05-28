using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonChairItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Shrine Chair");
			Tooltip.SetDefault("'This uncomfortable chair is older than you!'");
		}
		public override void SetDefaults()
		{
            item.width = 16;
            item.height = 30;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 3;
            item.createTile = mod.TileType("DragonChairTile");
            item.placeStyle = 0;
		}
	}
}