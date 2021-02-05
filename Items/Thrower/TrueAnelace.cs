using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class TrueAnelace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Anelace");
			Tooltip.SetDefault("Throw out three homing enchanted blades per swing, up to nine."
				+ "\nThese blades will home in on nearby enemies and cling to them."
				+ "\n'Against all the evil that the corruption can conjure..."
				+ "\nAll the wickeness that the crimson can produce...'");
		}
		public override void SetDefaults()
		{
			item.damage = 56;
			item.crit = 4;
			item.width = 36;
			item.height = 36;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(gold: 10);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("TrueAnelaceProj");
			item.shootSpeed = 15f;
		}
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 9;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2;
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(45));
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage * 1/2, knockBack, player.whoAmI);
			Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(-45));
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage * 1/22, knockBack, player.whoAmI);
			return true;
		}
		public override void AddRecipes()
		{
			/*
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(mod.ItemType("Anelace"));
			recipe1.AddIngredient(1570);
			recipe1.AddTile(TileID.MythrilAnvil);
			recipe1.SetResult(this);
			recipe1.AddRecipe();
			*/
		}
	}
}



