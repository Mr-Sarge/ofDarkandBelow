using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class DeinoDevastator : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deino-Devastator");
			Tooltip.SetDefault("'Horror of the Lake.'"
                + "\nEvery third shot fires homing mushroom shot.");
		}
        private int breathBlast;
        public override void SetDefaults()
        {
            item.damage = 29;
            item.noMelee = true;
            item.ranged = true;
            item.width = 74;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 7;
            item.value = Item.sellPrice(gold: 5);
            item.rare = 8;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/DeinoItem");
            item.autoReuse = true;
            item.shootSpeed = 60f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            breathBlast++;
            if (breathBlast == 3)
            {
                type = mod.ProjectileType("MushBreath");
                breathBlast = 0;
            }
            if (breathBlast == 3)
            {
                int numberProjectiles = 13 + Main.rand.Next(4);
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
                int numberProjectiles = 9 + Main.rand.Next(2); // 4 or 5 shots
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
                    Vector2 perturbedSpeedno2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
                    speedX = perturbedSpeedno2.X;
                    speedY = perturbedSpeedno2.Y;
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
			recipe.AddIngredient(ItemID.TacticalShotgun);
			recipe.AddIngredient(mod.ItemType("SarcoSpitfire"));
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}