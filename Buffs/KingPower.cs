using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Buffs
{
    public class KingPower : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Sovereign's Power");
			Description.SetDefault("'A tyrant's power flows in your veins...'");
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.meleeCrit += 15;
            player.meleeDamage += 0.20f;
            player.magicCrit += 25;
            player.magicDamage += 0.25f;
            player.meleeSpeed += 0.25f;
            player.statDefense += 8;
        }
    }
}