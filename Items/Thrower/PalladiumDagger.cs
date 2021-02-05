using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class PalladiumDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palladium Dagger");
			Tooltip.SetDefault("Has a chance to apply the Rapid Healing buff on hit.");
		}
		public override void SetDefaults()
		{
			item.damage = 38;
			item.crit = 4;
			item.width = 22;
			item.height = 22;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(copper: 36);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("PalladiumDaggerProj");
            item.shootSpeed = 25f;
			item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1184, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 75);
			recipe.AddRecipe();
		}
	}
}



