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
    public class NullEater : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Eater");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 36;
            npc.friendly = false;
            npc.damage = 20;
            npc.defense = 2;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.5f;
			npc.aiStyle = 5;
			npc.noGravity = true; 
            aiType = NPCID.EaterofSouls;
            animationType = NPCID.EaterofSouls;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NullEaterGore"), 1f);
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Neiroplasm"));
        }
    }
}