using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmicHelmetSum : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Bandana");
			Tooltip.SetDefault("A fine piece of facewear."
				+ "\n+1 Max Minions"
				+ "\n+15 Max Mana");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 18;
			item.value = Item.sellPrice(gold: 2);
            item.rare = 3;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("CosmicBreastplate") && legs.type == mod.ItemType("CosmicLeggings");
		}

		public override void UpdateEquip(Player player) {
			player.statManaMax2 += 15;
			player.maxMinions++;
            player.maxMinions++;
            player.maxMinions++;
        }

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "15% Increase to Summon Damage,"
                + "\nYou will gain the 'Cosmic Escapee' buff when you are struck.";
			player.minionDamage += 0.15f;
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