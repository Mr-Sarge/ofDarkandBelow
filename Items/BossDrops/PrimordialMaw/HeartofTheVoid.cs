using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
    [AutoloadEquip(EquipType.Neck)]
	public class HeartofTheVoid : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Heart of the Void");
			Tooltip.SetDefault("'The undying heart of the Maw...'"
			+ "\nAll Attacks inflict Cosmic Flame"
			+ "\n8% Increase to All Damage"
			+ "\nEvery 30 Seconds you get the Shadow Dodge buff."
			+ "\nDefense LOWERED by 5"
			+ "\n10% DECREASED Movement Speed");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(11, 12));
		}

		public override void SetDefaults() {
			item.width = 54;
			item.height = 46;
			item.value = 100000;
			item.rare = 9;
			item.expert = true;
			item.accessory = true;
		}
        private int dodgeTimer;
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeDamage += .08f;
			player.thrownDamage += .08f;
			player.rangedDamage += .08f;
			player.magicDamage += .08f;
			player.minionDamage += .08f;
			player.statDefense -= 5;
			player.moveSpeed -= 0.10f;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().cosmicInfliction = true;
            dodgeTimer++;
            if (dodgeTimer >= 1800)
            {
                player.AddBuff(59, 600);
                dodgeTimer = 0; //resets the timer
            }
}}}