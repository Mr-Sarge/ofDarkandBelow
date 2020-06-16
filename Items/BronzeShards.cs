using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class BronzeShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Shards");
            Tooltip.SetDefault("'Small shards of a forgotten metal...'");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.value = Item.sellPrice(copper: 70);
            item.rare = 2;
            item.maxStack = 999;
            item.material = true;
        }
    }
}
