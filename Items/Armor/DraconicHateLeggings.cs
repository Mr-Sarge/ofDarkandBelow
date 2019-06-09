using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DraconicHateLeggings : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Draconic Leggings");
			Tooltip.SetDefault("Leggings made of hatred");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 4;
			item.defense = 14;
		}
	}
}