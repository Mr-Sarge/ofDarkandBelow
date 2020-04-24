using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class BelowZero : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Below Zero");
			Description.SetDefault("\"Your existence is fading\"");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            player.lifeRegen = -10;
            player.statDefense -= 10;
			player.moveSpeed -= 0.15f;
			player.statManaMax2 -= 30;
	
	      	int DustID2 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("NullFire"), player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
		}
	    public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<SGlobalNPC>().belowZero = true;
        }
	}
}