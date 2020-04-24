using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
    public class Celestra : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestra");
			Tooltip.SetDefault("Bring down Deathly Rain"
			+ "\nCelestra fires 3 arrows rapidly on use.");
		}
        public override void SetDefaults()
        {
            item.damage = 36;
			item.crit = 6;
            item.noMelee = true;
            item.ranged = true;
            item.width = 32;
            item.height = 62;
            item.useTime = 13;
            item.useAnimation = 39;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = Item.sellPrice(gold: 3);
            item.rare = 3;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Celestra");
            item.autoReuse = false;
            item.shootSpeed = 40f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }
    }
}