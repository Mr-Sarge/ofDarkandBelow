using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class FreakyCritCoolDown : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Freaky Cooldown");
			Description.SetDefault("Your Freaky Critical is recharging...");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().freakyCritCoolDown = true;
        }
	}
}