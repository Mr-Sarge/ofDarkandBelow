using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items
{
    public class KaproKapper : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kapro-Kapper");
			Tooltip.SetDefault("Fires a special bullet that inflicts cursed inferno and ichor."
			+ "\n'The crocodilian boar that roars!.'");
		}
        public override void SetDefaults()
        {
            item.damage = 35;
			item.crit = 14;
            item.noMelee = true;
            item.ranged = true;
            item.width = 62;
            item.height = 20;
            item.useTime = 49;
            item.useAnimation = 49;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 5;
            item.value = Item.sellPrice(gold: 6);
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 36f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            int projectile1 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("KaproBullet"), damage, knockBack, player.whoAmI);
            return false;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Musket);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.TheUndertaker);
			recipe2.AddIngredient(ItemID.HellstoneBar, 10);
			recipe2.AddIngredient(ItemID.TissueSample, 10);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}