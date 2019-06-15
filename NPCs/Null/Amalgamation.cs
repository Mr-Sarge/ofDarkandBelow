using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.NPCs.Null
{
    public class Amalgamation : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Amalgamation");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 114;
            npc.height = 74;
            npc.friendly = false;
            npc.damage = 40;
            npc.defense = 0;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 100000f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 44;
            npc.noTileCollide = true;
            npc.scale = 1.2f;
			npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SiegeofTerror");
            aiType = NPCID.Harpy;
        }
		public override void HitEffect(int hitDirection, double damage)
        {
			if (Main.rand.NextBool(9)) {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("NullEater"), 1);
			}
			if (Main.rand.NextBool(22)) {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("NullWormHead"), 1);
			}
			if (Main.rand.NextBool(18)) {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("NullWalker"), 1);
			}
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AmalgamationGore1"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AmalgamationGore2"), 1.2f);
                Main.NewText("One of many has been defeated...", Color.Aqua.R, Color.Aqua.G, Color.Aqua.B);
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.55f);
            npc.damage = 70;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedQueenBee)
                if (Main.hardMode)
                {
                    return SpawnCondition.Dungeon.Chance * 0.007f;
                    return SpawnCondition.Underworld.Chance * 0.007f;
                }
                else
                {
                    return SpawnCondition.Dungeon.Chance * 0.009f;
                    return SpawnCondition.Underworld.Chance * 0.009f;
                }
            else if (Main.hardMode)
            {
                return SpawnCondition.Dungeon.Chance * 0.007f;
                return SpawnCondition.Underworld.Chance * 0.007f;
            }
            else
            {
                return SpawnCondition.Dungeon.Chance * 0.009f;
                return SpawnCondition.Underworld.Chance * 0.009f;
            }
        }

        public override void NPCLoot()
        {
            MyWorld.downedAmalgamation = true;
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Neiroplasm"), 40);
			if (Main.rand.NextBool(3)) {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Amalgamate"));
			}
			if (Main.rand.NextBool(3)) {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GhostSlayer"));
			}
			if (Main.rand.NextBool(3)) {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HarbingersHaunt"));
			}
			if (Main.rand.NextBool(10)) {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NullEaterEgg"));
			}
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.2;
            npc.frameCounter %= 10;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        private int spawnTimer;
		private int shootTimer;
        private bool talk1;
        private bool talk2;
        private bool talk3;
		public bool spawnMessage; 
        public override bool PreAI()
        {
            npc.ai[3]++;
            shootTimer++;
            if (!spawnMessage)
            {
                Main.NewText("An abomination has spotted you... There is NO ESCAPE.", Color.Aqua.R, Color.Aqua.G, Color.Purple.B);
                spawnMessage = true;
            }
            Player player = Main.player[npc.target];
            
            if (player.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = -1;
            }
            
            if (npc.ai[3] == 340)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y +
            (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 7) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 7) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                int count = 30;
                for (int i = 1; i <= count; i++)
                {
                    int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, mod.DustType("NullDust"), 0, 0, 100, color, 1.2f);
                    Main.dust[dust].noGravity = false;
                }
            }
            if (npc.ai[3] == 385)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y +
            (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 8) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 8) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                int count = 30;
                for (int i = 1; i <= count; i++)
                {
                    int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, mod.DustType("NullDust"), 0, 0, 100, color, 1.2f);
                    Main.dust[dust].noGravity = false;
                }
            }
            if (npc.ai[3] == 430)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y +
            (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 9) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 9) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                int count = 30;
                for (int i = 1; i <= count; i++)
                {
                    int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, mod.DustType("NullDust"), 0, 0, 100, color, 1.2f);
                    Main.dust[dust].noGravity = false;
                }
            }
            if (npc.ai[3] == 565)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y +
            (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                int count = 30;
                for (int i = 1; i <= count; i++)
                {
                    int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, mod.DustType("NullDust"), 0, 0, 100, color, 1.2f);
                    Main.dust[dust].noGravity = false;
                }
                npc.ai[3] = 0;
            }
            if (npc.life <= npc.lifeMax * 0.75 && !talk1)
            {
                Main.NewText("I WE IT ARE LEGION", Color.Aqua.R, Color.Aqua.G, Color.Aqua.B);
                talk1 = true;
				spawnTimer++;
            }
            if (spawnTimer >= 200)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("NullEater"));
                spawnTimer = 0;
            }
            if (npc.life <= npc.lifeMax * 0.50 && !talk2)
            {
                Main.NewText("BECOME ONE WITH US IT ME", Color.Aqua.R, Color.Aqua.G, Color.Aqua.B);
                talk2 = true;
            }
            if (npc.life <= npc.lifeMax * 0.20 && !talk3)
            {
                Main.NewText("WE US IT SHALL CONSUME YOU...", Color.Aqua.R, Color.Aqua.G, Color.Aqua.B);
                talk3 = true;
            }
            if (shootTimer >= 240)
            {
                Main.PlaySound(SoundID.Item8, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 7f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 22;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("NullSkull");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer = 0; //resets the timer
            }
            return true;
        }
    public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
    {
            target.AddBuff((BuffID.Obstructed), 60);
            target.AddBuff((BuffID.WitheredWeapon), 100);
    }
}}