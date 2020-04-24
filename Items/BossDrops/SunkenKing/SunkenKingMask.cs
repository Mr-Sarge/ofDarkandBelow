using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	[AutoloadEquip(EquipType.Head)]
	public class SunkenKingMask : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Sunken King Mask");
			Tooltip.SetDefault("'Et tu, Brute?'");
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