using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class CosmicRevivalCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cosmic Revival Cooldown");
			Description.SetDefault("\"Primordial revival rechrging...\"");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            int DustID2 = Dust.NewDust(player.position, player.width, player.height + 2, mod.DustType("CosmicDust"), player.velocity.X * 0.1f, player.velocity.Y * 0.1f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
            Main.dust[DustID2].scale = 0.8f;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().cosmicRevivalCooldown = true;
        }
	}
}