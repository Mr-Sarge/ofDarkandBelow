using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items.Null
{
    public class LimboLimbthrasher : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Limbo-LimbThrasher");
			Tooltip.SetDefault("'You're on the Ramp to Purgatory.'");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 48;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = 3;
            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 40;
            item.knockBack = 7.5F;
            item.damage = 29;
            item.noUseGraphic = true; // Do not use the item graphic when using the item (we just want the ball to spawn).
            item.shoot = mod.ProjectileType("LimbthrasherProj");
            item.shootSpeed = 24F;
            item.UseSound = SoundID.Item1;
            item.melee = true; // Deals melee damage.
            item.channel = true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 30);
			recipe.AddIngredient(mod.ItemType("ZeroSpirit"), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe2.AddIngredient(mod.ItemType("Neiroplasm"), 30);
			recipe2.AddIngredient(mod.ItemType("ZeroSpirit"), 1);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
        }
    }
}