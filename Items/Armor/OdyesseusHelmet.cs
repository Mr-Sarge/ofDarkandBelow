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
			Tooltip.SetDefault("9% increased throwing damage"
            + "\n'A man who has been through bitter experiences and travelled far enjoys even his sufferings after a time.'");
        }

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 1000000;
			item.rare = 5;
			item.defense = 13;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.09f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("OdyesseusChestArmor") && legs.type == mod.ItemType("OdyesseusGreaves");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "20% increased throwing damage"
				+ "\n12% increased throwing crit chance"
				+ "\nMovement speed increased by 45%"
				+ "\n‘You are Odysseus.’";
			player.thrownDamage += 0.20f;
            player.thrownCrit += 12;
            player.moveSpeed += 0.45f;
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