using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	public class SunkenCrown : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sunken Crown");
			Tooltip.SetDefault("'The Crown of a Dead King.'"
			+ "\n7% Decreased Movement Speed"
			+ "\n+7 Defense"
			+ "\n4% Increased Melee Damage");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 40;
			item.value = 100000;
			item.rare = 12;
			item.expert = true;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeDamage += .04f;
			player.statDefense += 7;
			player.moveSpeed -= 0.07f;
		}
	}
}