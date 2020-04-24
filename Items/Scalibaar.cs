using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class Scalibaar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scalibaar");
			Tooltip.SetDefault("An ancient and powerful sword.");
		}
		public override void SetDefaults()
		{
			item.damage = 85;
			item.shoot = (mod.ProjectileType("ScalibaarProj"));
			item.shootSpeed = 15f;
			item.melee = true;
			item.width = 66;
			item.height = 70;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 8);
            item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(mod.ItemType("ChildofScalibaar"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
