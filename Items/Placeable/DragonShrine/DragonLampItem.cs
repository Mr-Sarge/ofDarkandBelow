using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonLampItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Lamp");
			Tooltip.SetDefault("'This lamp's flame burns endlessly.'");
		}
		public override void SetDefaults()
		{
            item.width = 16;
            item.height = 48;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.consumable = true;        
            item.rare = 3;
            item.createTile = mod.TileType("DragonLampTile");
            item.placeStyle = 0;
		}
	}
}