using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ZeroGhostRobe : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Zero Ghost Robe Bottom");
			Tooltip.SetDefault("Movement speed is increased by 15%"
				+"\n'A perfect bottom for a ghastly individual like yourself.'");
		}

		public override void SetDefaults() {
			item.width = 38;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.15f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 5);
			recipe.AddIngredient(mod.ItemType("ZeroSpirit"), 1);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}