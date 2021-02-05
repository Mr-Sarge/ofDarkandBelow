using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items.Freak
{
    public class SiameseShot : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Siamese Shot");
			Tooltip.SetDefault("'Conjoin your arrows.'");
		}
        public override void SetDefaults()
        {
            item.damage = 12;
            item.noMelee = true;
            item.ranged = true;
            item.width = 56;
            item.height = 20;
            item.useTime = 43;
            item.useAnimation = 43;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = 2;
            item.autoReuse = false;
            item.UseSound = SoundID.Item108;
            item.shootSpeed = 20f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[type].noDropItem = true;
            }
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemonBow);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(mod.ItemType("FreakMaterial"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.TendonBow);
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