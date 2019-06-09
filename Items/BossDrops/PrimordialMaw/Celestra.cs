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
			+ "\nThis Item has a very high Crit Chance.");
		}
        public override void SetDefaults()
        {
            item.damage = 28;
			item.crit = 36;
            item.noMelee = true;
            item.ranged = true;
            item.width = 16;
            item.height = 34;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 20f;
			item.scale = 0.8f;
        }
    }
}