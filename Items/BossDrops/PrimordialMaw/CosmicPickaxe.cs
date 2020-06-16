using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
	public class CosmicPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Pickaxe");
			Tooltip.SetDefault("'Consume soil, stone, ore and blood alike!'");
		}
		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 17;
			item.useAnimation = 17;
			item.pick = 110;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(gold: 2);
            item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}