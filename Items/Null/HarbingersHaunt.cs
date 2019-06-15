using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Null
{
	public class HarbingersHaunt : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Harbinger's Haunt");
			Tooltip.SetDefault("'Burn away their essence.'"
			+ "\nUses Gel as Ammo and Spits Cursed Flames");
		}

		public override void SetDefaults() {
		    item.CloneDefaults(ItemID.Flamethrower);
			item.damage = 20;
			item.ranged = true;
			item.width = 40;
			item.height = 34;
			item.noMelee = true;
			item.knockBack = 2;
			item.shoot = mod.ProjectileType("HarbingersBreath");
			item.value = 10000;
			item.rare = 3;
			item.crit = 12;
		}
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .55f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3 + Main.rand.Next(5);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(+2, +2);
		}
	}
}