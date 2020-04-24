using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable
{
	public class FreakWallItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freak Wall");
			Tooltip.SetDefault("'Why would you ever want to live in a house made of freaky flesh?'");
		}
		public override void SetDefaults()
		{
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 10;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 2;
            item.createWall = mod.WallType("FreakWallTile");
            item.placeStyle = 0;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FreakWoodItem"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult((this), 4);
            recipe.AddRecipe();
        }
    }
}