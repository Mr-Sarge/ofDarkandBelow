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
			Tooltip.SetDefault("Increases your max number of minions by 2"
				+ "\nIncreases maximum mana by 15"
				+ "\n'A fine piece of facewear.'");
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
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = "Increases minion damage by 15%"
                + "\nIncreases your max number of minions by 2"
                + "\nYou will gain the 'Cosmic Escapee' buff when you are struck.";
			player.minionDamage += 0.15f;
            player.maxMinions++;
            player.maxMinions++;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().cosmicEscapeeEffect = true;
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