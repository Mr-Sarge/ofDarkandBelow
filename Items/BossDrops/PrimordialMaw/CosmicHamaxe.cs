using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
	public class CosmicHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Ham-Axe");
			Tooltip.SetDefault("'Devour wood and wall alike!'");
		}
		public override void SetDefaults()
		{
			item.damage = 18;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 15;
			item.useAnimation = 15;
			item.axe = 24;
			item.hammer = 120;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}