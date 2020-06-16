using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class RawMeat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Raw Meat");
            Tooltip.SetDefault("'Eugh! It's awful! It's all freakin' awful!'");
        }
        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 43;
            item.value = Item.sellPrice(copper: 4);
            item.rare = 1;
            item.maxStack = 999;
            item.material = true;
        }
    }
}
