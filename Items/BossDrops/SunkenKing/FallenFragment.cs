using Microsoft.Xna.Framework;
using ofDarkandBelow.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
    public class FallenFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Fragment");
            Tooltip.SetDefault("'A fragment of the Sunken King's ancient power...'"
                + "\nUsed to create Sunken King's Drops or the Fallen Royalty Armor.");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 42;
            item.value = Item.sellPrice(silver: 8);
            item.rare = 2;
            item.maxStack = 999;
            item.material = true;
        }
    }
}
