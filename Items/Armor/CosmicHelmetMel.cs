using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmicHelmetMel : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Mask");
			Tooltip.SetDefault("10% increased melee speed"
				+ "\n'Terrify enemies with the hint of Maw's presence.'");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 22;
            item.value = Item.sellPrice(gold: 2);
			item.rare = 3;
			item.defense = 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("CosmicBreastplate") && legs.type == mod.ItemType("CosmicLeggings");
		}

		public override void UpdateEquip(Player player) {
            player.meleeSpeed += 0.10f;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "6% increased melee damage"
                + "\n25% increased melee speed";
			player.meleeDamage += 0.06f;
            player.meleeSpeed += 0.25f;
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