using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class Anelace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Anelace");
			Tooltip.SetDefault("Throw out up to three enchanted blades."
				+ "\nThese blades will home in on nearby enemies and cling to them.");
		}
		public override void SetDefaults()
		{
			item.damage = 36;
			item.crit = 4;
			item.width = 36;
			item.height = 36;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(gold: 4);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("AnelaceProj");
			item.shootSpeed = 10f;
		}
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 3;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 0;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 9);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

			
			
