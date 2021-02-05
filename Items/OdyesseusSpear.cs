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
			Tooltip.SetDefault("Spears inflict Ichor");
		}
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 20f;
			item.damage = 36;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 11;
			item.useTime = 20;
			item.width = 54;
			item.height = 54;
			item.maxStack = 999;
			item.rare = 5;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 2);
			item.shoot = mod.ProjectileType("OdyesseusSpearProj");
		}

		public override void AddRecipes() {
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(mod.ItemType("HeroesAlloy"), 6);
			recipe1.AddIngredient(3380, 3);
			recipe1.AddIngredient(ItemID.Bone, 10);
			recipe1.AddIngredient(ItemID.Ichor, 5);
			recipe1.AddTile(TileID.MythrilAnvil);
			recipe1.SetResult(this, 200);
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(mod.ItemType("HeroesAlloy"), 6);
			recipe2.AddIngredient(3380, 3);
			recipe2.AddIngredient(ItemID.Bone, 10);
			recipe2.AddIngredient(ItemID.CursedFlame, 5);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(this, 200);
			recipe2.AddRecipe();
		}
	}
}