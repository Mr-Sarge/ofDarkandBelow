using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class IcyDemise : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icy Demise");
			Tooltip.SetDefault("'Become a Herald of the Ice!'");
		}
		public override void SetDefaults()
		{
			item.damage = 52;
			item.melee = true;
			item.width = 56;
			item.height = 52;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 7);
            item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 263;
			item.shootSpeed = 25f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceSickle, 1);
			recipe.AddIngredient(ItemID.IceBlade, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
