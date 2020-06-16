using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 namespace ofDarkandBelow.Items
{
	public class OdyesseusSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Odysseus' Spear");
			Tooltip.SetDefault("Rapid fire Odysseus spears."
			+ "\nSpears inflict Ichor.");
		}
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 20f;
			item.damage = 55;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 11;
			item.useTime = 11;
			item.width = 54;
			item.height = 54;
			item.maxStack = 1;
			item.rare = 5;

			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 5);
			item.shoot = mod.ProjectileType("OdyesseusSpearProj");
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("OdyesseusBar"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}