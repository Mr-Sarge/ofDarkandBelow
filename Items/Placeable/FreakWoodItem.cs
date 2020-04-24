using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable
{
    public class FreakWoodItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freak Wood");
            Tooltip.SetDefault("'If you build with this. You're a disgusting person.'");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 2;
            item.createTile = mod.TileType("FreakWoodTile");
            item.placeStyle = 0;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FreakWallItem"), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult((this), 1);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("FreakMaterial"), 1);
            recipe2.AddIngredient(ItemID.Wood, 25);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.SetResult((this), 25);
            recipe2.AddRecipe();
        }
    }
}