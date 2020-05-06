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
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart of the Void");
            Tooltip.SetDefault("'The undying heart of the Maw...'"
            + "\n8% Increase to All Damage"
            + "\nUpon death, you revive with 50 HP."
            + "\nYou will also gain a single shadow dodge upon revivng."
            + "\nThe revival has a cooldown of 2 Minutes.");
        }

        public override void SetDefaults()
        {
            item.width = 54;
            item.height = 46;
            item.value = 100000;
            item.rare = 9;
            item.expert = true;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += .08f;
            player.thrownDamage += .08f;
            player.rangedDamage += .08f;
            player.magicDamage += .08f;
            player.minionDamage += .08f;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            modPlayer.cosmicRevival = true;
        }
    }
}