using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class OdyesseusChestArmor : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Odysseus' Armor");
			Tooltip.SetDefault("Armor donned by the Cyclops' Escapee");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 18;
			item.value = 100000;
			item.rare = 5;
			item.defense = 12;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("OdyesseusBar"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}