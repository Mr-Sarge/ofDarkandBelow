using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
	public class CosmicClusterFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Cluster Fragment");
			Tooltip.SetDefault("'A shard that's less than a thousandth of the Endless Maw's original power.'");
		}
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 34;
            item.value = Item.sellPrice(silver: 45);
            item.rare = 2;
			item.maxStack = 999;
			item.material = true;
		}
	}
}