using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class TerraScalibaar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terra-Edged Scalibaar");
			Tooltip.SetDefault("The Blade of Terra mixed with the Ancient Power of Scalibaar.");
		}
		public override void SetDefaults()
		{
			item.damage = 235;
			item.melee = true;
			item.shoot = (mod.ProjectileType("ScalibaarProj"));
			item.shootSpeed = 60f;
			item.width = 80;
			item.height = 80;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item65;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(mod.ItemType("Scalibaar"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
        float numberProjectiles = 3;
        float rotation = MathHelper.ToRadians(10);
        position += Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;
        for (int i = 0; i < numberProjectiles; i++)
        {
           Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
           Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
	   	   Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 132, damage, knockBack, player.whoAmI);
        }
        return false;
		}
    }
}