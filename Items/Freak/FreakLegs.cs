using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Freak
{
    [AutoloadEquip(EquipType.Legs)]
    public class FreakLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freaky Legs");
            Tooltip.SetDefault("4% increased ranged critical strike chance"
                + "\nMovement speed increased by 20%"
                + "\n'Legs made of squishy freak.'");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = 10000;
            item.rare = 2;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            player.rangedCrit += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddIngredient(mod.ItemType("FreakMaterial"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 5);
            recipe2.AddIngredient(ItemID.TissueSample, 5);
            recipe2.AddIngredient(ItemID.Bone, 15);
            recipe2.AddIngredient(mod.ItemType("FreakMaterial"), 15);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}