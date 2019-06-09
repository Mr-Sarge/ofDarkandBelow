using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class OdyesseusHelmet : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Odysseus' Helmet");
			Tooltip.SetDefault("'A man who has been through bitter experiences and travelled far enjoys even his sufferings after a time'");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 1000000;
			item.rare = 5;
			item.defense = 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("OdyesseusChestArmor") && legs.type == mod.ItemType("OdyesseusGreaves");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "25% Increase to Throwing Damage and 25% increased movement speed. You are Odyesseus.";
			player.thrownDamage += 0.25f;
			player.moveSpeed += 0.25f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("OdyesseusBar"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}