using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Null
{
	public class Neiroplasm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neiroplasm");
			Tooltip.SetDefault("You feel uncomfortable holding this.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.maxStack = 999;
			item.material = true;
		}}}
