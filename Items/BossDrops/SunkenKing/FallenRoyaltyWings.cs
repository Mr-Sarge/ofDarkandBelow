using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	[AutoloadEquip(EquipType.Wings)]
	public class FallenRoyaltyWings : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fallen Royalty Wings");
            Tooltip.SetDefault("'Who needs a griffin?'"
            +  "\nFlight Time: 25"
            + "\nGood Acceleration"
            + "\nDecent Horizontal Mobility");
        }
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 2;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 25;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 1f;
			ascentWhenRising = 0.20f;
			maxCanAscendMultiplier = 1.4f;
			maxAscentMultiplier = 2.4f;
			constantAscend = 0.19f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 7f;
			acceleration *= 1.6f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FallenFragment"), 12);
		}
	}
}