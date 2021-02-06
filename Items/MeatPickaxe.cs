using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class MeatPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meat Pickaxe");
			Tooltip.SetDefault("'How?'");
		}
		public override void SetDefaults()
		{
			item.damage = 2;
			item.melee = true;
			item.width = 38;
			item.height = 42;
			item.useTime = 15;
			item.useAnimation = 15;
			item.pick = 43;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(copper: 60);
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