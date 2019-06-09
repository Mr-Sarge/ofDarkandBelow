using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class FreakMaterial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freak Material");
			Tooltip.SetDefault("'You do not know what this is...'");
		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 100;
			item.rare = 2;
			item.maxStack = 999;
			item.material = true;
		}
	}
}
