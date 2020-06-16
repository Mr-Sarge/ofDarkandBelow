using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TheseusHelmet : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Theseus' Helm");
			Tooltip.SetDefault("'You must decide what is false and what is true.'");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 10000;
			item.rare = 2;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("TheseusArmor") && legs.type == mod.ItemType("TheseusShoes");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "20% increased melee damage";
			player.meleeDamage += 0.2f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BronzeBar"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}