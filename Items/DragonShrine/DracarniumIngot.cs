using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class DracarniumIngot : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarnium Ingot");
			Tooltip.SetDefault("'Made with the blood and rotted flesh of slain dragons...'");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
            item.value = Item.sellPrice(silver: 40);
            item.rare = 3;
			item.maxStack = 999;
			item.material = true;
		}
	}
}