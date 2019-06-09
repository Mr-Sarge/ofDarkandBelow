using ofDarkandBelow.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items
{
	public class TheWildWind : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("The Wild Wind");
			Tooltip.SetDefault("'There will be a catastrophe, the like we've never seen.'"
			+"\nInflicts a myriad of damaging debuffs on hit."
			+"\nExplodes on enemy hits.");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() {
			item.useStyle = 5;
			item.width = 30;
			item.height = 26;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 220;
			item.rare = 10;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 22);
			item.shoot = mod.ProjectileType("TheWildWindProj");
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TheEyeOfCthulhu, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 25);
			recipe.AddIngredient(ItemID.SoulofFright, 25);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(3458, 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}