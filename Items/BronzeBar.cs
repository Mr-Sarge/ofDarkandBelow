using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class BronzeBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bronze Bar");
			Tooltip.SetDefault("The power of the bronze age resonates within this bar.");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
            item.value = Item.sellPrice(silver: 30);
            item.rare = 2;
			item.maxStack = 999;
			item.material = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 1);
			recipe.AddIngredient(mod.ItemType("BronzeShards"), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.TinBar, 1);
			recipe2.AddIngredient(mod.ItemType("BronzeShards"), 1);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}