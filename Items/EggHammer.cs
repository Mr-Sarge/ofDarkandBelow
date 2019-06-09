using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class EggHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Egg Hammer");
			Tooltip.SetDefault("'Fear the Poultry!'");
		}
		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 259;
			item.value = 0;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
	}
}
