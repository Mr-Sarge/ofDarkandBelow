using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 namespace ofDarkandBelow.Items.Null
{
	public class NullBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trapped Spirit Bomb");
			Tooltip.SetDefault("Bombs inflict 'Below Zero'."
			+ "\nExplosions spawn null spirits to attack enemies."
			+ "\n'Explodes with the wrath of the nullified spirits within.'");
		}
		public override void SetDefaults() {
			item.shootSpeed = 20f;
			item.damage = 19;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 20;
			item.useTime = 20;
			item.width = 54;
			item.height = 54;
			item.maxStack = 1;
			item.rare = 2;

			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 2);
			item.shoot = mod.ProjectileType("NullBombProj");
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 15);
			recipe.AddIngredient(mod.ItemType("ZeroSpirit"), 1);
			recipe.AddIngredient((ItemID.Grenade), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult((this), 1);
			recipe.AddRecipe();
		}
	}
}