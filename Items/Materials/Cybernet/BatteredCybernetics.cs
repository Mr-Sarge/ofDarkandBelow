using Microsoft.Xna.Framework;
using ofDarkandBelow.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Materials.Cybernet
{
    public class BatteredCybernetics : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cybernetic Plating");
            Tooltip.SetDefault("'An advanced technology, beyond your understanding...'");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 5;
            item.maxStack = 999;
            item.material = true;
        }
    }
}
