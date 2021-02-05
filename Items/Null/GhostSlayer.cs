using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Null
{
	public class GhostSlayer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghost Slayer");
			Tooltip.SetDefault("'You are so kind to take care of that man. You know, you're a real humanitarian.'"
			+ "\n'I don't think he's human.'");
		}
		public override void SetDefaults()
		{
			item.damage = 29;
			item.crit = 46;
			item.melee = true;
			item.width = 66;
			item.height = 68;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}