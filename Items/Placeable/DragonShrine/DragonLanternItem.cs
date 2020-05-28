using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonLanternItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Lantern");
			Tooltip.SetDefault("'This Lantern houses trapped dragon fire.'");
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
            item.value = Item.sellPrice(0, 0, 11, 0);
            item.consumable = true;        
            item.rare = 3;
            item.createTile = mod.TileType("DragonLanternTile");
            item.placeStyle = 0;
		}
	}
}