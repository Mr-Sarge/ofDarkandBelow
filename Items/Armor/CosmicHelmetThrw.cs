using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmicHelmetThrw : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Faceguard");
			Tooltip.SetDefault("15% increased throwing velocity"
				+ "\n'Shatter planets with this stylish helm.'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 20;
            item.value = Item.sellPrice(gold: 2);
			item.rare = 3;
			item.defense = 7;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("CosmicBreastplate") && legs.type == mod.ItemType("CosmicLeggings");
		}

		public override void UpdateEquip(Player player) {
			player.thrownVelocity += 0.15f;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "15% increased throwing damage"
				+ "\n10% increased throwing crit chance"
				+ "\n25% increased movement speed";
			player.thrownDamage += 0.15f;
			player.thrownCrit += 10;
			player.moveSpeed += 0.25f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}