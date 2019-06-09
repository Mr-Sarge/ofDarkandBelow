using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Buffs
{
    public class MysteriousPower : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Mysterious Power");
			Description.SetDefault("+4 Defense, 4% Increased Melee and Ranged Damage, 15% Increased Movement Speed");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 4;
			player.meleeDamage += 0.04f;
			player.rangedDamage += 0.04f;
			player.moveSpeed += 0.15f;
        }
    }
}