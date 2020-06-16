using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Placeable.DragonShrine
{
	public class DragonShrineBiomeChestItemLocked : ModItem
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dragon Shrine Biome Chest but locked");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 1500;
			item.createTile = mod.TileType("DragonShrineBiomeChestTile");
		}
	}
}