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
            npc.defense = 0;
            npc.lifeMax = 30;
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
            if (npc.life <= 0 || npc.life == 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NullEaterGore"), 1f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Dungeon.Chance * 0.05f;
        }
        public override void NPCLoot()
        {
            if (Main.rand.NextFloat() < .5f)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Neiroplasm"), 1);
            }
        }
        private bool deathCharge;
        private int deathChargeTimer;
        public override bool PreAI()
        {
            Player player = Main.player[npc.target];
            float distance = npc.Distance(Main.player[npc.target].Center);
            if (distance <= 200)
            {
                if (Main.rand.Next(150) == 0)
                {
                    if (!deathCharge)
                    {
                        deathCharge = true;
                    }
                }
            }
            if (deathCharge == true)
            {
                deathChargeTimer++;
            }
            if (deathChargeTimer <= 90 && deathCharge == true)
            {
                npc.velocity *= 0.8f;
            }
            if (deathChargeTimer >= 90 && deathCharge == true)
            {
                npc.damage = 60;
            }
            if (deathChargeTimer == 90)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 18) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 18) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (deathChargeTimer == 110)
            {
                npc.life = 0;
                Gore.NewGore(npc.position, npc.velocity * 0.85f, mod.GetGoreSlot("Gores/NullEaterGore"), 1f);
                Vector2 position = npc.Center;
                int radius = 3;

                for (int x = -radius; x <= radius; x++)
                {
                    for (int y = -radius; y <= radius; y++)
                    {
                        int xPosition = (int)(x + position.X / 16.0f);
                        int yPosition = (int)(y + position.Y / 16.0f);

                        if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                        {
                            Dust.NewDust(position, 22, 22, 89, 0.0f, 0.0f, mod.DustType("NullFire"), new Color(), 1f);  //this is the dust that will spawn
                        }
                    }
                }
            }
            return true;
        }
    }
}