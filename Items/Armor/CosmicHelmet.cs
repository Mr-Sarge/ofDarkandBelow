using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmicHelmet : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Horned Helm");
			Tooltip.SetDefault("You are a horned beast.");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 10000;
			item.rare = 2;
			item.defense = 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("CosmicBreastplate") && legs.type == mod.ItemType("CosmicLeggings");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "10% Increase to ALL Damage";
			player.meleeDamage += 0.1f;
			player.thrownDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.magicDamage += 0.1f;
			player.minionDamage += 0.1f;
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