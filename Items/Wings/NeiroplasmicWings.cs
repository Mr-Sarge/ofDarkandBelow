using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class NeiroplasmicWings : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Neiroplasmic Wings");
			Tooltip.SetDefault("'Dance with the Ghosts'");
		}
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 42;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 1f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1.5f;
			maxAscentMultiplier = 2.5f;
			constantAscend = 0.15f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 10f;
			acceleration *= 2.5f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 35);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}