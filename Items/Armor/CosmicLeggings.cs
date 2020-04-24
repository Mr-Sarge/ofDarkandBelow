using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CosmicLeggings : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Leggings");
			Tooltip.SetDefault("Leggings made of the Maw's small Power."
				+ "\n15% increased movement speed."
                + "\nIncreased jump height.");
        }

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(gold: 2);
            item.rare = 2;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.15f;
            player.jumpBoost = true;
            player.jumpSpeedBoost += 2f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}