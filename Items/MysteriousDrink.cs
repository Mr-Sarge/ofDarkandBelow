using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class MysteriousDrink : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Drink");
			Tooltip.SetDefault("'It smells worse than Strange Brew...'");
		}
        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 20;
            item.height = 34;
            item.value = 500;                
            item.rare = 2;
            item.buffType = mod.BuffType("MysteriousPower");
            item.buffTime = 6000;
		}
	}
}