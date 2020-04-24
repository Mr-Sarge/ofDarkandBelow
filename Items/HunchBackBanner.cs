using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class HunchBackBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hunchback Banner");
            Tooltip.SetDefault("'Just like Notre Dame!'");
        }
        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 43;
            item.value = Item.sellPrice(silver: 2);
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 0;
            item.createTile = mod.TileType("HunchBackBanner");
            item.placeStyle = 0;
            item.maxStack = 999;
        }
    }
}
