using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable
{
	public class FreakCandleItem : ModItem
	{
        #region Overriden Methods

        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Freak Candle");
		}

		public override void SetDefaults() {
			item.width = 16;
			item.height = 16;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = mod.TileType("FreakCandleTile");
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Candle);
			recipe.AddIngredient(mod.ItemType("FreakWood"), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        #endregion Overriden Methods
    }
}