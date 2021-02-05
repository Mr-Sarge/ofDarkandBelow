using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Armor.Dev.Cybernet
{
    [AutoloadEquip(EquipType.Legs)]
    public class CybernetLeggings : ModItem
    {
        public override void SetStaticDefaults() // Tiki has 6, 17, 12 (total 35) Defense, 30% MD, +4 Sums, Spoopy has 9, 11, 10 (total 30), 58% MD, +4 Sums
        {
            DisplayName.SetDefault("Cybernet Protogreaves");
            Tooltip.SetDefault("10% increased minion damage"
            + "\nMovement speed increased by 25%"
            + "\n'Chase some lightning, you might just be faster.'"
            + "\nDev Leggings: Fishcookie");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(gold: 15);
            item.rare = 7;
            item.defense = 11;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
            player.minionDamage += 0.10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BatteredCybernetics"), 7);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}