using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Armor.Dev
{
    [AutoloadEquip(EquipType.Legs)]
    public class BehemothLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Behemoth Plate Greaves");
            Tooltip.SetDefault("Increases Movement Speed by 45%, Health by 25"
            + "\nDev Leggings: Jsoull");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(gold: 15);
            item.rare = 11;
            item.defense = 22;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.45f;
            player.statLifeMax2 += 25;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BeserkerCrystal"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}