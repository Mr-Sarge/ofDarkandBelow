using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HappyMask : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Happy Mask");
			Tooltip.SetDefault("Embrace the Happiness."
			+ "\nDeveloper Item: BoRKman");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 999999999;
			item.rare = 0;
			item.vanity = true;
        }
    }
}