using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class BrokenIronSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Iron Sword");
			Tooltip.SetDefault("A broken and useless sword.");
		}
		public override void SetDefaults()
		{
			item.damage = 1;
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
