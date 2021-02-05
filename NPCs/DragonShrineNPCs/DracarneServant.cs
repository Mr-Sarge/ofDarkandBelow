using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.NPCs.DragonShrineNPCs
{
    public class DracarneServant : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarne Servant");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void SetDefaults()
        {
            npc.width = 54;
            npc.height = 62;
            npc.friendly = false;
            npc.damage = 30;
            npc.defense = 6;
            npc.lifeMax = 120;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.25f;
            npc.aiStyle = 3;
            aiType = NPCID.GoblinScout;  //npc behavior
            animationType = NPCID.Zombie;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            }
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
        }
        public override void AI()
        {
            if (npc.life < npc.lifeMax * 0.40)
            {
                aiType = NPCID.AngryBones;
            }
        }
    }
}