using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DraconicHateArmor : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Draconic Armor");
			Tooltip.SetDefault("You feel like you could tear a dragon in half!");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 4;
			item.defense = 18;
		}
	}
}