using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrimsonDemonHat : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Crimson Demon Hat");
			Tooltip.SetDefault("'EXPLOSION'");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 18;
			item.value = 9999;
			item.rare = 2;
			item.vanity = true;
        }
    }
}