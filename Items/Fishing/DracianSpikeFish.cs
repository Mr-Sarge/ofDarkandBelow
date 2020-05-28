using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Fishing
{
	public class DracianSpikeFish : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracian Spike-Fish");
            Tooltip.SetDefault("'It gives a putrid scent of age.'"
                + "\nUsed to craft Potions.");
		}
		public override void SetDefaults()
		{
            item.width = 36;
			item.height = 36;
            item.value = Item.sellPrice(silver: 35);
            item.rare = 3;
			item.maxStack = 999;
			item.material = true;
		}
        public override void AddRecipes()
        {
            ModRecipe recipeWrath = new ModRecipe(mod);
            recipeWrath.alchemy = true;
            recipeWrath.AddIngredient(mod.ItemType("DracianSpikeFish"), 3);
            recipeWrath.AddIngredient(ItemID.Deathweed);
            recipeWrath.AddIngredient(ItemID.BottledWater);
            recipeWrath.AddTile(TileID.Bottles);
            recipeWrath.SetResult(2349, 1);
            recipeWrath.AddRecipe();

            ModRecipe recipeRage = new ModRecipe(mod);
            recipeRage.alchemy = true;
            recipeRage.AddIngredient(mod.ItemType("DracianSpikeFish"), 3);
            recipeRage.AddIngredient(ItemID.Deathweed);
            recipeRage.AddIngredient(ItemID.BottledWater);
            recipeRage.AddTile(TileID.Bottles);
            recipeRage.SetResult(2347, 1);
            recipeRage.AddRecipe();

            ModRecipe recipeHunter = new ModRecipe(mod);
            recipeHunter.alchemy = true;
            recipeHunter.AddIngredient(mod.ItemType("DracianSpikeFish"), 2);
            recipeHunter.AddIngredient(ItemID.Daybloom);
            recipeHunter.AddIngredient(ItemID.BottledWater);
            recipeHunter.AddTile(TileID.Bottles);
            recipeHunter.SetResult(304, 1);
            recipeHunter.AddRecipe();

            ModRecipe recipeAmmo = new ModRecipe(mod);
            recipeAmmo.alchemy = true;
            recipeAmmo.AddIngredient(mod.ItemType("DracianSpikeFish"), 3);
            recipeAmmo.AddIngredient(ItemID.Moonglow);
            recipeAmmo.AddIngredient(ItemID.BottledWater);
            recipeAmmo.AddTile(TileID.Bottles);
            recipeAmmo.SetResult(2344, 1);
            recipeAmmo.AddRecipe();
        }
    }
}