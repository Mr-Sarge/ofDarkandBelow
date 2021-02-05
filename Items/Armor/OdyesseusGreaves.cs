using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class OdyesseusGreaves : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Odysseus' Greaves");
			Tooltip.SetDefault("Movement speed increased by 15%"
            + "\n'Run as quick as Odysseus!'");
        }

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 5;
			item.defense = 13;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("HeroesAlloy"), 12);
			recipe.AddIngredient(3380, 8);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}