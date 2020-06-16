using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Null
{
	public class ZeroSpirit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zero Spirit");
			Tooltip.SetDefault("'A powerless, potential-ridden spirit.'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.value = Item.sellPrice(silver: 50);
			item.rare = 2;
			item.maxStack = 999;
			item.material = true;
		}
	}
}