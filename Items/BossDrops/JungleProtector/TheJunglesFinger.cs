using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.JungleProtector
{
	public class TheJunglesFinger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Jungle's Finger");
			Tooltip.SetDefault("'A blade forged from the very flora of the Jungle.'");
		}
		public override void SetDefaults()
		{
			item.damage = 30;
			item.shoot = 124;
			item.shootSpeed = 18f;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
