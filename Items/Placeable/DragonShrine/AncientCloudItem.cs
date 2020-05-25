using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class AncientCloudItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Cloud");
			Tooltip.SetDefault("'This toxic cloud has been around for decades, longer more likely...'");
		}
		public override void SetDefaults()
		{
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 2;
            item.createTile = mod.TileType("AncientCloudTile");
            item.placeStyle = 0;
		}
	}
}