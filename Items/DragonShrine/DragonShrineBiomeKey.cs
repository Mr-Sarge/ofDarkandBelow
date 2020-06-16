using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
    class DragonShrineBiomeKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Shrine Biome Key");
            Tooltip.SetDefault("Unlocks the Dragon Shrine Biome Chest.");
        }
        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.GoldenKey);
            item.width = 20;
            item.height = 38;
            item.maxStack = 99;
            item.rare = 8;
        }
    }
}
