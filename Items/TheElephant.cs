using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items
{
    public class TheElephant : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Elephant");
			Tooltip.SetDefault("'You're supposed to kill abominations. Not use them'");
		}
        public override void SetDefaults()
        {
            item.width = 46;
            item.height = 40;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = 3;
            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 40;
            item.knockBack = 7.5F;
            item.damage = 35;
            item.noUseGraphic = true; // Do not use the item graphic when using the item (we just want the ball to spawn).
            item.shoot = mod.ProjectileType("ElephantProj");
            item.shootSpeed = 20F;
            item.UseSound = SoundID.Item1;
            item.melee = true; // Deals melee damage.
            item.channel = true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BallOHurt);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(mod.ItemType("FreakMaterial"), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.TheMeatball);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe2.AddIngredient(ItemID.TissueSample, 5);
			recipe2.AddIngredient(ItemID.Bone, 25);
			recipe2.AddIngredient(mod.ItemType("FreakMaterial"), 30);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
        }
    }
}