using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class Aegisuchus : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aegisuchus");
			Tooltip.SetDefault("Bully of the Pond.");
		}
        public override void SetDefaults()
        {
            item.damage = 15;
            item.noMelee = true;
            item.ranged = true;
            item.width = 48;
            item.height = 28;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SarcoItem");
            item.autoReuse = true;
            item.shootSpeed = 20f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Boomstick);
			recipe.AddIngredient(ItemID.DemoniteBar, 20);
			recipe.AddIngredient(ItemID.ShadowScale, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Boomstick);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 20);
			recipe2.AddIngredient(ItemID.TissueSample, 20);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}