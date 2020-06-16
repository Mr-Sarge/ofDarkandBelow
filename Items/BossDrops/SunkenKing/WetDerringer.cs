using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
    public class WetDerringer : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wet Derringer");
			Tooltip.SetDefault("Fires Ford's Shot."
                + "\n[Rare Drop]"
                + "\n'You can make elected figures openminded with this.'");

        }
        public override void SetDefaults()
        {
            item.damage = 94;
            item.crit = 41;
            item.noMelee = true;
            item.ranged = true;
            item.width = 36;
            item.height = 22;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = mod.ItemType("FordsShot");
            item.knockBack = 5;
            item.value = Item.sellPrice(gold: 2);
            item.expert = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SarcoItem");
            item.autoReuse = true;
            item.shootSpeed = 120f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
	}
}