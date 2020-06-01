using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Tiles.DragonShrine.Pillars
{
	public class DragonPillarCChippedItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Pillar Chipped Large");
		}
		public override void SetDefaults()
		{
            item.width = 32;
            item.height = 48;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 3;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.createTile = mod.TileType("DragonPillarCChippedTile");
            item.placeStyle = 0;
		}
	}
}