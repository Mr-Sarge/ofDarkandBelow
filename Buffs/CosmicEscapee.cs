using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Buffs
{
    public class CosmicEscapee : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Cosmical Escapee");
			Description.SetDefault("75% increased movement speed, 20% Increased Summon Damage,");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.75f;
            player.minionDamage += 0.20f;
        }
    }
}