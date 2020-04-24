using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class HanksKatana : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hank's Katana");
			Tooltip.SetDefault("'Crush, Kill, Destroy, Perfect.'"
			+ "\nDeveloper Item: Mr. Sarge'");
		}
		public override void SetDefaults()
		{
			item.damage = 1200;
			item.melee = true;
			item.width = 44;
			item.height = 48;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(platinum: 50);
            item.rare = -12;
			item.crit = 76;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
