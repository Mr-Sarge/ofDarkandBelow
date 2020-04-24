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
			Tooltip.SetDefault("This spear deals Magic Damage and Regens Mana on hit.");
		}

		public override void SetDefaults() {
			item.damage = 25;
			item.useStyle = 5;
			item.useAnimation = 42;
			item.useTime = 14;
			item.shootSpeed = 2f;
			item.knockBack = 2.5f;
			item.width = 62;
			item.height = 68;
			item.scale = 1f;
			item.rare = 2;
			item.value = Item.sellPrice(silver: 120);

			item.magic = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false;

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("TerrorNaginataProj");
		}

		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Spear, 1);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 30);
			recipe.AddIngredient(mod.ItemType("ZeroSpirit"), 1);
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