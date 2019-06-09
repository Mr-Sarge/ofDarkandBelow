using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class RawMeat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raw Meat");
			Tooltip.SetDefault("Eugh! It's awful!");
		}
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 43;
			item.value = 100;
			item.rare = 1;
			item.maxStack = 999;
			item.material = true;
		}}}
