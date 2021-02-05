using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class DarkScalpel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Scalpel");
			Tooltip.SetDefault("Placeholder."
				+ "\n'For making deep and... precise cuts.'");
		}
		public override void SetDefaults()
		{
			item.damage = 15;
			item.crit = 3;
			item.width = 22;
			item.height = 20;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(silver: 22);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("DarkScalpelProj");
			item.shootSpeed = 20f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(57, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}



