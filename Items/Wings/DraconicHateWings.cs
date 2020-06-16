using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class DraconicHateWings : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Draconic Hate Wings");
			Tooltip.SetDefault("\nFlight Time: 100"
            + "\nGood Acceleration"
            + "\nGood Horizontal Mobility"
			+ "\n'Torn from a dragon...'");

		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 28;
            item.value = Item.sellPrice(gold: 5);
            item.rare = 6;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 100;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.25f;
			maxCanAscendMultiplier = 2f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.25f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9f;
			acceleration *= 2.5f;
		}
	}
}