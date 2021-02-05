using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.Behemoth
{
    public class BehemothChestItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Behemoth Cest");
        }
        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 24;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 2;
            item.createTile = mod.TileType("BehemothChestTile");
            item.placeStyle = 0;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BeserkerCrystal"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}