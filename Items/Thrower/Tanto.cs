using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class Tanto : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tanto");
			Tooltip.SetDefault("'Open your kimono and die with honor.'");
		}
		public override void SetDefaults()
		{
			item.damage = 21;
			item.crit = 11;
			item.width = 22;
			item.height = 20;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(silver: 35);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("TantoProj");
			item.shootSpeed = 20f;
		}
	}
}



