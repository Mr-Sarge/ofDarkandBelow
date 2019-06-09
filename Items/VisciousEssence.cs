using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class VisciousEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viscious Essence");
			Tooltip.SetDefault("The Essence of Viscious Creatures.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 43;
			item.value = 10000;
			item.rare = 2;
			item.maxStack = 999;
			item.material = true;
		}}}
