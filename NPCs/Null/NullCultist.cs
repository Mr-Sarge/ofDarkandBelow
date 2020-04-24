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


namespace ofDarkandBelow.NPCs.Null
{
    public class NullCultist : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Cultist");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 50;
            npc.friendly = false;
            npc.damage = 20;
            npc.defense = 0;
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.5f;
			npc.aiStyle = 8;
			npc.noGravity = false; 
			aiType = NPCID.Tim;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NullCultistGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NullCultistGore2"), 1f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		if(NPC.downedQueenBee)
            if (Main.hardMode)
            {
                return SpawnCondition.Dungeon.Chance * 0.03f;
				return SpawnCondition.Underworld.Chance * 0.03f;
            }
            else
            {
                return SpawnCondition.Dungeon.Chance * 0.07f;
				return SpawnCondition.Underworld.Chance * 0.07f;
            }
		else
		            if (Main.hardMode)
            {
                return SpawnCondition.Dungeon.Chance * 0.03f;
				return SpawnCondition.Underworld.Chance * 0.03f;
            }
            else
            {
                return SpawnCondition.Dungeon.Chance * 0.07f;
				return SpawnCondition.Underworld.Chance * 0.07f;
            }
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Neiroplasm"), 3);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.2;
            npc.frameCounter %= 15;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
		public override bool PreAI()
        {
		Player player = Main.player[npc.target];
		if (player.Center.X > npc.Center.X)
		{
   		    npc.spriteDirection = -1;
		}
		else
		{
   		    npc.spriteDirection = 1;
		}
		return true;
		}
    }
}