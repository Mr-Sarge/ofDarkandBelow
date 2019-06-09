using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.NPCs.SunkenKing
{
    public class SunkenSoldier : ModNPC
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
            npc.damage = 15;
            npc.defense = 2;
            npc.lifeMax = 40;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
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
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenSoldierGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenSoldierGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenSoldierGore3"), 1f);
            }
        }
    }
}