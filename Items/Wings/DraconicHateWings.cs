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
			Tooltip.SetDefault("'Torn from a Dragon...'");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 28;
			item.value = 10000;
			item.rare = 2;
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