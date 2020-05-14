using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class KingPowerCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sovereign Cool-Down");
			Description.SetDefault("The Sovereign's power must wait to burst forth again...");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().kingPowerCooldown = true;
        }
	}
}