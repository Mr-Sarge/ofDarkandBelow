using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MeatHelmet : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Meat Helmet");
			Tooltip.SetDefault("'You are a barbarian of meat.'");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 1000;
			item.rare = 1;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("MeatChestplate") && legs.type == mod.ItemType("MeatLeggings");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases minion damage by 15%"
					+ "\n'You smell disgusting.'";
			player.minionDamage += 0.2f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RawMeat"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}