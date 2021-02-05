using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class MythrilCaltrops : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mythril Caltrops");
			Tooltip.SetDefault("Throw a caltrop that sticks to the ground and damages enemies."
				+ "\n Active Time: 10 Seconds"
				+ "\n Durability: 15 Hits");
		}
		public override void SetDefaults()
		{
			item.damage = 38;
			item.crit = 4;
			item.width = 26;
			item.height = 24;
			item.useTime = 32;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = Item.sellPrice(copper: 28);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("MythrilCaltropsProj");
            item.shootSpeed = 15f;
			item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(381, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 75);
			recipe.AddRecipe();
		}
	}
}



