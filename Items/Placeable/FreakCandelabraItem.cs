using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable
{
	public class FreakCandelabraItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freak Candelabra");
			Tooltip.SetDefault("'Now with 3x the putrid scent!'");
		}
		public override void SetDefaults()
		{
            item.width = 26;
            item.height = 28;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 2;
            item.createTile = mod.TileType("FreakCandelabraTile");
            item.placeStyle = 0;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FreakWoodItem"), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}