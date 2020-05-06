using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class GrandScalibaar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grand Scalibaar");
			Tooltip.SetDefault("Banish those who dare challenge ancient might.");
		}
		public override void SetDefaults()
		{
			item.damage = 140;
			item.melee = true;
			item.shoot = (mod.ProjectileType("ScalibaarProj"));
			item.shootSpeed = 120f;
			item.width = 80;
			item.height = 80;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 8;
            item.value = Item.sellPrice(gold: 22);
            item.rare = 10;
			item.UseSound = SoundID.Item73;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ItemID.BeamSword);
            recipe.AddIngredient(ItemID.Frostbrand);
            recipe.AddIngredient(ItemID.Keybrand);
            recipe.AddIngredient(mod.ItemType("Scalibaar"));
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3;
            float numberProjectiles2 = 2;
            float rotation = MathHelper.ToRadians(7);
            float rotation2 = MathHelper.ToRadians(14);
            float rotation3 = MathHelper.ToRadians(9);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;
            for (int i = 0; i < numberProjectiles2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles2 - 1))) * .2f;
                float scale = 1f - (Main.rand.NextFloat() * .45f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation2, rotation2, i / (numberProjectiles - 1))) * .2f;
                float scale = 1f - (Main.rand.NextFloat() * .45f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 119, damage, knockBack, player.whoAmI);
            }
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation3, rotation3, i / (numberProjectiles - 1))) * .2f;
                float scale = 1f - (Main.rand.NextFloat() * .45f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 116, damage, knockBack, player.whoAmI);
            }
            return false;
		}
    }
}