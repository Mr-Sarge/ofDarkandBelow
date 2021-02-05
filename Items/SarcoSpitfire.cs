using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items
{
    public class SarcoSpitfire : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sarco-Spitfire");
			Tooltip.SetDefault("'Terror of the Lake'"
                + "\nEvery third shot is a blast of terror bullets.");
		}
        private int breathBlast;
        public override void SetDefaults()
        {
            item.damage = 26;
            item.noMelee = true;
            item.ranged = true;
            item.width = 66;
            item.height = 30;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 1;
            item.value = Item.sellPrice(gold: 10);
            item.rare = 5;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SarcoItem");
            item.autoReuse = true;
            item.shootSpeed = 40f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            breathBlast++;
            if (breathBlast == 3)
            {
                type = mod.ProjectileType("TerrorBreath");
                breathBlast = 0;
            }
            if (breathBlast == 3)
            {
                int numberProjectiles = 11 + Main.rand.Next(2);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 30 degree spread.
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            else
            {
                int numberProjectiles = 8 + Main.rand.Next(2);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // 30 degree spread.
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Aegisuchus"));
            recipe.AddIngredient(ItemID.Shotgun);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}