using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class CatastrophicRedemption : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Catastrophic Redemption");
			Tooltip.SetDefault("Each swing throws out a random cluster of projectiles."
            + "\nc  h  a  o  s"
            + "\n'Blessed with the randomness of the Noob King himself...'"
            + "\nDeveloper Item: Hallam");
		}
		public override void SetDefaults()
		{
			item.damage = 190;
			item.melee = true;
			item.width = 98;
			item.height = 88;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.shoot = 254;
			item.shootSpeed = 20f;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 9;
			item.expert = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
        float numberProjectiles = 3;
        float rotation = MathHelper.ToRadians(10);
        position += Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;
        for (int i = 0; i < numberProjectiles; i++)
        {
           Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
           float scale = 1f - (Main.rand.NextFloat() * .3f);
		   perturbedSpeed = perturbedSpeed * scale;
                if (Main.rand.Next(7) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 483, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 451, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 15, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 16, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 41, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 114, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 182, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 246, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 242, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 278, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 279, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(14) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 706, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 278, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 591, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(6) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 636, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(6) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 711, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(6) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 459, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(5) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 634, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(5) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 343, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(5) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 340, damage, knockBack, player.whoAmI);
                }
            }
        return false;
		}
	}
}