using Microsoft.Xna.Framework;
using ofDarkandBelow.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Null
{
	public class TerrorNaginata : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Terror Naginata");
			Tooltip.SetDefault("This item deals magic damage and regens mana upon hit.");
		}

		public override void SetDefaults() {
			item.damage = 25;
			item.useStyle = 5;
			item.useAnimation = 27;
			item.useTime = 27;
			item.shootSpeed = 2f;
			item.knockBack = 7f;
			item.width = 62;
			item.height = 68;
			item.scale = 1f;
			item.rare = 2;
			item.value = Item.sellPrice(silver: 80);

			item.magic = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("TerrorNaginataProj");
		}

		public override bool CanUseItem(Player player) {
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 15);
			recipe.AddIngredient((ItemID.Spear), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }
    }
}