using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonStoneAItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Stone (A)");
			Tooltip.SetDefault("'Made from the bones of fallen Dracarne...'"
			+  "\nYou probably shouldn't have this... probably.");
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
            item.createTile = mod.TileType("DragonStoneATile");
            item.placeStyle = 0;
		}
	}
}