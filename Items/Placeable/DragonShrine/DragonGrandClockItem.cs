using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonGrandClockItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Shrine Grand-Father Clock");
			Tooltip.SetDefault("'It really is a grandfather!'");
		}
		public override void SetDefaults()
		{
            item.width = 32;
            item.height = 80;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 20;
            item.useTime = 15;
            item.useStyle = 1;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 35, 0);
            item.rare = 3;
            item.createTile = mod.TileType("DragonGrandClockTile");
            item.placeStyle = 0;
		}
	}
}