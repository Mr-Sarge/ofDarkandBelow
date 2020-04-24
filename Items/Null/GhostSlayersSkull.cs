using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items.Null
{
	public class GhostSlayersSkull : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ghost Slayer's Skull");
			Tooltip.SetDefault("'The Skull of a Forgotten Hero.'"
			+ "\n7% Increased Crit Chance"
			+ "\n+5 Defense"
			+ "\n7% Increased Damage");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 32;
            item.value = Item.sellPrice(gold: 3);
            item.rare = 12;
			item.expert = true;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeDamage += .07f;
            player.rangedDamage += .07f;
            player.magicDamage += .07f;
            player.minionDamage += .07f;
            player.thrownDamage += .07f;
            player.statDefense += 5;
            player.meleeCrit += 7;
            player.rangedCrit += 7;
            player.magicCrit += 7;
            player.thrownCrit += 7;
        }
	}
}