using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class AncientAleBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ancient Ale Buff");
			Description.SetDefault("15% Reduced Damage, Throw Ancient Ale Faster");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            player.rangedDamage -= 0.15f;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().ancientAleBuff = true;
        }
	}
}