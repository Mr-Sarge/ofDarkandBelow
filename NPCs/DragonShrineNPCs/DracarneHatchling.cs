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


namespace ofDarkandBelow.NPCs.DragonShrineNPCs
{
    public class DracarneHatchling : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hatching Dracarne");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 40;
            npc.friendly = false;
            npc.damage = 35;
            npc.defense = 2;
            npc.lifeMax = 150;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 70f;
            npc.knockBackResist = 0.75f;
			npc.aiStyle = 14;
			npc.noGravity = true;
            aiType = NPCID.CaveBat;
            animationType = NPCID.EaterofSouls;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {

            }
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
        }
        public override bool PreAI()
        {
            if (npc.velocity.X >= 0)
            {
                npc.spriteDirection = 1;
            }
            else if (npc.velocity.X < 0)
            {
                npc.spriteDirection = -1;
            }
            return true;
        }
        private int chargeTimer;
        public override void AI()
        {
            npc.velocity *= 0.95f;
            npc.rotation = npc.velocity.X * 0.045f;
            chargeTimer++;
            float distance = npc.Distance(Main.player[npc.target].Center);
            if (chargeTimer == 240)
            {
                if (distance <= 9)
                {
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                    {
                        float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                        npc.velocity.X = (float)(Math.Cos(rotation) * 8) * -1;
                        npc.velocity.Y = (float)(Math.Sin(rotation) * 8) * -1;
                    }
                    npc.ai[0] %= (float)Math.PI * 2f;
                    Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                    Color color = new Color();
                    Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                }
                chargeTimer = 0;
            }
        }
    }
}