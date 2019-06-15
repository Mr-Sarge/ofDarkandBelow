using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.NPCs.Null
{
    public class NullWalker : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Walker");
            Main.npcFrameCount[npc.type] = 9;
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 58;
            npc.friendly = false;
            npc.damage = 40;
            npc.defense = 4;
            npc.lifeMax = 150;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 3;
			aiType = NPCID.GoblinScout;
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Neiroplasm"), 4);
		}
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.5;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
		public override bool PreAI()
        {
		Player player = Main.player[npc.target];
		if (player.Center.X > npc.Center.X)
		{
   		    npc.spriteDirection = 1;
		}
		else
		{
   		    npc.spriteDirection = -1;
		}
		return true;
		}
    }
}