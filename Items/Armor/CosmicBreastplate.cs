using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CosmicBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Cosmic Breastplate");
            Tooltip.SetDefault("Your heart burns with the power of diminished stars."
                + "\nImmunity to 'Cosmic Flame'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 3);
            item.rare = 3;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player) {
			player.buffImmune[mod.BuffType("CosmicFlame")] = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}