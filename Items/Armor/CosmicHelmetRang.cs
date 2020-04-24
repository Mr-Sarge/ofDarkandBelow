using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmicHelmetRang : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Helmet");
			Tooltip.SetDefault("Allows you to breathe while amongst the stars."
				+ "\n+3% Ranged Crit Chance");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 22;
            item.value = Item.sellPrice(gold: 2);
			item.rare = 3;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("CosmicBreastplate") && legs.type == mod.ItemType("CosmicLeggings");
		}

		public override void UpdateEquip(Player player) {
			player.rangedCrit += 3;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "10% Increased Ranged Damage"
                + "\n7% Increase to Ranged Crit Chance"
                + "\nYou gain an improved rocket boots effect."
                +"\nImmunity to Fall Damage.";
            player.rangedDamage += 0.1f;
            player.rangedCrit += 7;
            player.noFallDmg = true;
            player.canRocket = true;
            player.rocketBoots = 1;
            player.rocketTimeMax = 8;
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