using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.NPCs
{
    public class GrimHunchBack : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grim HunchBack");
            Main.npcFrameCount[npc.type] = 8;
        }
        public override void SetDefaults()
        {
            npc.width = 92;
            npc.height = 98;
            npc.friendly = false;
            npc.damage = 60;
            npc.defense = 10;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 26;
            aiType = NPCID.Unicorn;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 1.2f, npc.velocity.Y * 1.2f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 1f, npc.velocity.Y * 1f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.8f, npc.velocity.Y * 0.8f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.6f, npc.velocity.Y * 0.6f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f);
            }
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.50;
            npc.frameCounter %= 16;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.03f;
            }
            else
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.0f;
            }
        }
        public override bool PreAI()
        {
            if (npc.velocity.X >= 0)
            {
                npc.spriteDirection = -1;
            }
            else if (npc.velocity.X < 0)
            {
                npc.spriteDirection = 1;
            }
            return true;
        }
    }
}