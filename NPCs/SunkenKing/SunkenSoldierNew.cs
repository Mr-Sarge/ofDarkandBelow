using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.NPCs.SunkenKing
{
    public class SunkenSoldierNew : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunken Soldier");
            Main.npcFrameCount[npc.type] = 3;
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 48;
            npc.friendly = false;
            npc.damage = 20;
            npc.defense = 2;
            npc.lifeMax = 25;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath32;
            npc.value = 0f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
			aiType = NPCID.GoblinScout;
			animationType = NPCID.Zombie;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 1f, npc.velocity.Y * 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenSoldierNewGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenSoldierNewGore2"), 1f);
            }
        }
        private int soundTimer;
        public override bool PreAI()
        {
            soundTimer++;
            if (soundTimer >= 400)
            {
                soundTimer = 0;
                if (Main.rand.Next(6) < 2)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/Sunken_1"));
                }
            }
            return true;
        }
    }
}