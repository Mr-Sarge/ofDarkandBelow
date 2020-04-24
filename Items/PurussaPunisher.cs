using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class PurussaPunisher : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purussa-Punisher");
			Tooltip.SetDefault("God of the lake.");
		}
        public override void SetDefaults()
        {
            item.damage = 58;
            item.noMelee = true;
            item.ranged = true;
            item.width = 90;
            item.height = 40;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 7;
            item.value = Item.sellPrice(gold: 30);
            item.rare = 10;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PurussaItem");
            item.autoReuse = true;
            item.shootSpeed = 60f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 12 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("CrocoRocket"), damage, knockBack, player.whoAmI);
			}
			return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SDMG);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddIngredient(mod.ItemType("DeinoDevastator"));
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(3456, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}