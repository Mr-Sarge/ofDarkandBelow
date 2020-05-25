using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
    class DracarneKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarne Key");
            Tooltip.SetDefault("Opens one Dragon Shrine Chest");
        }
        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.GoldenKey);
            item.width = 18;
            item.height = 24;
            item.maxStack = 99;
            item.rare = 3;
        }
    }
}
