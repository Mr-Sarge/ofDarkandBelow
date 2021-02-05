using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class RedKris : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Kris");
			Tooltip.SetDefault("Thrown daggers give a very small amount of health back on hit."
				+ "\n'Great for dark rituals and aspiring cults...'");
		}
		public override void SetDefaults()
		{
			item.damage = 23;
			item.crit = 3;
			item.width = 22;
			item.height = 24;
			item.useTime = 32;
			item.useAnimation = 32;
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
			item.shoot = mod.ProjectileType("RedKrisProj");
			item.shootSpeed = 20f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1257, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}



