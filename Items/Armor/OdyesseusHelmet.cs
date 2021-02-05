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
			Tooltip.SetDefault("5% increased throwing and ranged damage"
            + "\n'A man who has been through bitter experiences and travelled far enjoys even his sufferings after a time.'");
        }

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 1000000;
			item.rare = 5;
			item.defense = 9;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.05f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("OdyesseusChestArmor") && legs.type == mod.ItemType("OdyesseusGreaves");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "10% increased throwing and ranged damage"
				+ "\n10% increased throwing and ranged crit chance"
				+ "\nMovement speed increased by 15%"
				+ "\n‘You are Odysseus.’";
			player.thrownDamage += 0.10f;
			player.rangedDamage += 0.10f;
            player.thrownCrit += 10;
			player.rangedCrit += 10;
            player.moveSpeed += 0.15f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("HeroesAlloy"), 9);
			recipe.AddIngredient(3380, 5);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}