using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	public class KingsHarvest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The King's Harvest");
			Tooltip.SetDefault("'Reap the Benefits of Royalty'");
		}
		public override void SetDefaults()
		{
			item.damage = 27;
			item.crit = 10;
			item.melee = true;
			item.shoot = 131;
			item.shootSpeed = 60f;
			item.width = 52;
			item.height = 44;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(silver: 25);
            item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
