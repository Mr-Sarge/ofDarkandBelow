using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;

namespace ofDarkandBelow.Buffs
{
    public class HidepiercedDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hidepierced");
            Description.SetDefault("That's got to hurt.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 50;
            int DustID4 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("CosmicDust"), player.velocity.X * 0.6f, player.velocity.Y * 0.2f, 20, default(Color), 2f);
            Main.dust[DustID4].noGravity = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<SGlobalNPC>().hidepierced = true;
        }
    }
}