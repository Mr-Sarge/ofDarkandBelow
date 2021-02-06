using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class MeatAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meat Axe");
			Tooltip.SetDefault("'But like, why? Why would you do that?'");
		}
		public override void SetDefaults()
		{
			item.damage = 5;
			item.melee = true;
			item.width = 52;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.axe = 9;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(copper: 70);
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