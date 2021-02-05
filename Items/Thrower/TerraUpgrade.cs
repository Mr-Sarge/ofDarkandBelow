using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Thrower
{
    public class TerraUpgrade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Core");
            Tooltip.SetDefault("'Teemingly with ancient power...'");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.value = Item.sellPrice(gold: 9);
            item.rare = 8;
            item.maxStack = 99;
            item.material = true;
        }
    }
}
