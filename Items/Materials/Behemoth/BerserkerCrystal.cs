using Microsoft.Xna.Framework;
using ofDarkandBelow.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Materials.Behemoth
{
    public class BeserkerCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Crystal");
            Tooltip.SetDefault("'The energy of this crystal is unnerving.'");
        }
        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 56;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 10;
            item.maxStack = 999;
            item.material = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 1);
            recipe.AddIngredient((3458), 1);
            recipe.AddIngredient((ItemID.LunarBar), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.AdamantiteBar, 1);
            recipe2.AddIngredient((3458), 1);
            recipe2.AddIngredient((ItemID.LunarBar), 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
