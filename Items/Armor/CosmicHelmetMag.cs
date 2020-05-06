using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmicHelmetMag : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Headwear");
			Tooltip.SetDefault("A spiky piece of primordial head-wear."
				+ "\n+45 Max Mana");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 22;
            item.value = Item.sellPrice(gold: 2);
			item.rare = 3;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("CosmicBreastplate") && legs.type == mod.ItemType("CosmicLeggings");
		}

		public override void UpdateEquip(Player player) {
			player.statManaMax2 += 45;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "12% Increase to Magic Damage,"
                + "\n7% Increase to Magic Crit Chance"
                 + "\nYou will gain Mana when you are struck.";
			player.magicDamage += 0.12f;
            player.magicCrit += 7;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().cosmicManaRegen = true;
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