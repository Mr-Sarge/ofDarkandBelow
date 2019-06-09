using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MeatLeggings : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Meat Leggings");
			Tooltip.SetDefault("I can't fathom putting these on my legs.");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = 1000;
			item.rare = 2;
			item.defense = 3;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RawMeat"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}