using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ofDarkandBelow.Items
{
	public class TestPick : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("U B E R ODEV Test Pick of YES 9001");
            Tooltip.SetDefault("For Testing Purposes. Fish was here."
                + "\n'If you got this you're either Sarge, a tester, or a dirty lil' cheater...'");
		}
		public override void SetDefaults()
		{
			item.damage = 556;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 1;
			item.useAnimation = 10;
			item.pick = 1000;
			item.useStyle = 1;
			item.knockBack = 12;
            item.value = Item.sellPrice(gold: 0);
            item.rare = -12;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}