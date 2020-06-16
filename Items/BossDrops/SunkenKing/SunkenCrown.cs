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
			Tooltip.SetDefault("8 defense"
			+ "\nWhen Below 50% life, you gain 5 more defense and"
            + "\na miniature Sunken Wyvern shall protect you."
            + "\nHer damage is scaled off of your max life."
			+ "\n'The crown of a deceased surface-sovereign...'");

		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 40;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 12;
			item.expert = true;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statDefense += 8;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            modPlayer.sunkenCrownEffect = true;
        }
	}
}