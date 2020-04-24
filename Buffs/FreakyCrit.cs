using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Buffs
{
    public class FreakyCrit : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Freaky Critical");
			Description.SetDefault("+45% Critical Chance with Ranged Weapons. +20% ranged damage.");
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.rangedCrit += 45;
            player.rangedDamage += 0.20f;
        }
    }
}