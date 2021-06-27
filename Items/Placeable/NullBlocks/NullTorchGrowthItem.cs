using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.NullBlocks
{
	public class NullTorchGrowthItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Null Torch Growth");
			Tooltip.SetDefault("'Is this an actual torch?'"
                  + "\nPart of the Null Sub-Biome.");
		}
		public override void SetDefaults()
		{
            item.width = 18;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;        
            item.rare = 1;
            item.createTile = mod.TileType("NullTorchGrowth");
            item.placeStyle = 0;
		}
	}
}