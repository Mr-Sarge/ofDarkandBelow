using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Tainted
{
	public class TaintedRipper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tainted Ripper");
			Tooltip.SetDefault("'Tainted with endless amounts of Magic.'");
		}
		public override void SetDefaults()
		{
			item.damage = 22;
			item.shoot = mod.ProjectileType("TaintBolt");
			item.shootSpeed = 20f;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
