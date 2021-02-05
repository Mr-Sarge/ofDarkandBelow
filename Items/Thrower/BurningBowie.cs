using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class BurningBowie : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Bowie");
			Tooltip.SetDefault("Fires off three fiery knives."
				+ "\n'You could start a revolution with this... or a fire. One of the two.");
		}
		public override void SetDefaults()
		{
			item.damage = 28;
			item.crit = 5;
			item.width = 38;
			item.height = 38;
			item.useTime = 47;
			item.useAnimation = 47;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(silver: 51);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("BurningBowieProjectile");
			item.shootSpeed = 15f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage * 2/3, knockBack, player.whoAmI);
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(175, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}



