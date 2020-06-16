using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class DracarniumFlames : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dracarnium Flames");
			Description.SetDefault("\"A dragon's fury HURTS! ...and burns.\"");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            player.lifeRegen = -10;
	
	      	int DustID2 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("DracarniumFlamesDust"), player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
		}
	    public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<SGlobalNPC>().dracarniumFlames = true;
        }
	}
}