using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class Tainted : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tainted!");
			Description.SetDefault("\"Your body is decaying\"");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            player.lifeRegen = -15;
	        player.statDefense = -15;
            int DustID2 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("TaintedDust"), player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 100, default(Color), 1f);
            Main.dust[DustID2].noGravity = true;
		}
		        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<SGlobalNPC>(mod).tainted = true;
        }
	}
}