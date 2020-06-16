using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Buffs
{
    public class IreBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Dragon's Ire");
			Description.SetDefault("'Enemies shall know fear.'");
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.meleeCrit += 5;
            player.meleeDamage += 0.05f;
            player.magicCrit += 5;
            player.magicDamage += 0.05f;
            player.rangedCrit += 5;
            player.rangedDamage += 0.05f;
            player.minionDamage += 0.15f;

            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            modPlayer.ire = true;
            player.thorns += 0.28f;
        }
    }
}