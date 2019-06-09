using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EndlessMawMask : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Endless Maw Mask");
			Tooltip.SetDefault("Embrace the Cosmic Wrath");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 10000;
			item.rare = 0;
			item.vanity = true;
        }
    }
}