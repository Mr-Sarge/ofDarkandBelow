using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable
{
	public class FreakWoodItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freak Wood");
			Tooltip.SetDefault("'If you build with this. You're a disgusting person.'");
		}
		public override void SetDefaults()
		{
            item.width = 24;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 2;
            item.createTile = mod.TileType("FreakWoodTile");
            item.placeStyle = 0;
		}
	}
}