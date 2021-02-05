using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.Behemoth
{
	public class BehemothBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Behemoth Brick");
			Tooltip.SetDefault("'Pulsing with dark power... almost... demeaning in nature.'");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 22;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 2;
			item.createTile = mod.TileType("BehemothBlockTile");
			item.placeStyle = 0;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BeserkerCrystal"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult((this), 100);
            recipe.AddRecipe();
        }
    }
}