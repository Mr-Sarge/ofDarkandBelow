using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class ChildofScalibaar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Child of Scalibaar");
			Tooltip.SetDefault("A forgotten blade...");
		}
		public override void SetDefaults()
		{
			item.damage = 30;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 3;
			item.knockBack = 6;
			item.value = 1000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
