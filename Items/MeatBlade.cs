using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class MeatBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meat-Blade");
			Tooltip.SetDefault("Slash your enemies with sharpened meat");
		}
		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 34;
			item.height = 44;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RawMeat"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
	}
}}