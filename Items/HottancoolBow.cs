using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class HottancoolBow : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hottancol Bow");
			Tooltip.SetDefault("Transforms arrows into that of mixed elements");
		}
        public override void SetDefaults()
        {
            item.damage = 60;
            item.noMelee = true;
            item.ranged = true;
            item.width = 32;
            item.height = 64;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 7;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int projectile1 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("HottancoolArrowProj"), damage, knockBack, player.whoAmI);
            return false;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenFury);
			recipe.AddIngredient(ItemID.IceBow);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
    }
}}