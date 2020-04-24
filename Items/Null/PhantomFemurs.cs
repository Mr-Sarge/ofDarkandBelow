using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 namespace ofDarkandBelow.Items.Null
{
	public class PhantomFemurs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantom Femurs");
			Tooltip.SetDefault("'It may be ghostly, but being hit with a bone hurts!'"
			+ "\nBones Inflict 'Below Zero'");
		}
		public override void SetDefaults() {
			item.shootSpeed = 15f;
			item.damage = 23;
			item.knockBack = 4f;
			item.useStyle = 1;
			item.useAnimation = 14;
			item.useTime = 14;
			item.width = 54;
			item.height = 54;
			item.maxStack = 999;
			item.rare = 2;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 5);
			item.shoot = mod.ProjectileType("PhantomFemurProj");
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 15);
			recipe.AddIngredient((ItemID.Bone), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult((this), 125);
			recipe.AddRecipe();
		}
	}
}