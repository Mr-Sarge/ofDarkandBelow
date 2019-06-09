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


namespace ofDarkandBelow.NPCs
{
    public class Criminal : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crim-Inal");
            Main.npcFrameCount[npc.type] = 3;
        }
        public override void SetDefaults()
        {
            npc.width = 80;
            npc.height = 100;
            npc.friendly = false;
            npc.damage = 100;
            npc.defense = 2;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.35f;
			npc.aiStyle = 5;
			npc.noGravity = true; 
            aiType = NPCID.EaterofSouls;
            animationType = NPCID.EaterofSouls;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CriminalGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CriminalGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CriminalGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CriminalGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CriminalGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CriminalGore4"), 1f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.Crimson.Chance * 0.06f;
            }
            else
            {
                return SpawnCondition.Crimson.Chance * 0.0f;
            }
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Ichor, 3);
        }
    }
}