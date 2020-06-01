using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Tiles.DragonShrine.Pillars
{
	public class DragonPillarCItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Pillar Large");
		}
		public override void SetDefaults()
		{
            item.width = 32;
            item.height = 80;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 3;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.createTile = mod.TileType("DragonPillarCTile");
            item.placeStyle = 0;
		}
	}
}