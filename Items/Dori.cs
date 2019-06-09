using ofDarkandBelow.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class Dori : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Dori");
			Tooltip.SetDefault("'Today, we are going to hell!'");
		}

		public override void SetDefaults() {
			item.damage = 28;
			item.useStyle = 5;
			item.useAnimation = 35;
			item.useTime = 35;
			item.shootSpeed = 2.5f;
			item.knockBack = 7f;
			item.width = 73;
			item.height = 73;
			item.scale = 1f;
			item.rare = 2;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("DoriProjectile");
		}

		public override bool CanUseItem(Player player) {
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BronzeBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}