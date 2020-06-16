using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	[AutoloadEquip(EquipType.Legs)]
	public class FallenRoyalGreaves : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Fallen Royalty's Greaves");
			Tooltip.SetDefault("3% increased melee speed"
                + "\nIncreases maximum mana by 10"
                + "\nMovement speed increased by 15%"
                + "\nIncreased jump speed."
                + "\n'It feels as if your skin grows into these greaves…'");
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.03f;
            player.statManaMax2 += 10;
            player.moveSpeed += 0.15f;
            player.jumpSpeedBoost += 1.8f;
        }

        public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
            item.value = Item.sellPrice(silver: 70);
            item.rare = 3;
			item.defense = 6;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FallenFragment"), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}