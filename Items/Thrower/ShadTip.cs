using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class ShadTip : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow's Tip");
			Tooltip.SetDefault("'The blade seems to be whispering. Are you going mad?'");
		}
		public override void SetDefaults()
		{
			item.damage = 45;
			item.crit = 4;
			item.width = 34;
			item.height = 38;
			item.useTime = 33;
			item.useAnimation = 33;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(gold: 4);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("ShadTipProj");
			item.shootSpeed = 20f;
		}
		public override void AddRecipes()
		{
			/* ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(mod.ItemType("RedKris"));
			recipe1.AddIngredient(mod.ItemType("Tanto"));
			recipe1.AddIngredient(mod.ItemType("OvergrownMachete"));
			recipe1.AddIngredient(mod.ItemType("BurningBowie"));
			recipe1.AddTile(TileID.DemonAltar);
			recipe1.SetResult(this);
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(mod.ItemType("DarkScalpel"));
			recipe2.AddIngredient(mod.ItemType("Tanto"));
			recipe2.AddIngredient(mod.ItemType("OvergrownMachete"));
			recipe2.AddIngredient(mod.ItemType("BurningBowie"));
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.SetResult(this);
			recipe2.AddRecipe(); */
			
		}
	}
}



