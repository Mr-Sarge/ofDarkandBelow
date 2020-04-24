using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Freak
{
	public class FreakEater : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freak-Eater");
			Tooltip.SetDefault("'You're the real freak.'"
			+  "\n20% chance to NOT Consume Ammo");
		}
		public override void SetDefaults()
		{
			item.damage = 12;
            item.ranged = true;
            item.crit = 20;
			item.width = 48;
			item.height = 20;
			item.useTime = 5;
			item.useAnimation = 5;
			item.knockBack = 1;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = 2;
            item.useStyle = 5;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
            item.UseSound = SoundID.Item98;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .20f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlintlockPistol);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddIngredient(mod.ItemType("FreakMaterial"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.FlintlockPistol);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe2.AddIngredient(ItemID.TissueSample, 5);
            recipe2.AddIngredient(ItemID.Bone, 25);
            recipe2.AddIngredient(mod.ItemType("FreakMaterial"), 15);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
