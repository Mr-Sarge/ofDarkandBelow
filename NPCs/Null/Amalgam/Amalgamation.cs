using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.NPCs.Null.Amalgam
{
    public class Amalgamation : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Amalgamation");
            Main.npcFrameCount[npc.type] = 11;
        }

        public override void SetDefaults()
        {
            npc.width = 120;
            npc.height = 66;
            npc.friendly = false;
            npc.damage = 30;
            npc.defense = 10;
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 44;
            npc.noTileCollide = true;
            npc.scale = 1.2f;
			npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SiegeofTerror");
            aiType = NPCID.Harpy;
			npc.buffImmune[mod.BuffType("CosmicFlame")] = true;
			npc.buffImmune[mod.BuffType("BelowZero")] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.2f);
            npc.damage = 60;
        }
        public override bool CheckDead()
        {
            npc.SetDefaults(mod.NPCType("AmalgamationAngry"));
            return false;
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
        private int shootTimer2;
        private int shootTimer3;
        private int shootTimer4;
        private int shootTimer5;
        private bool talk1;
        private bool talk2;
        private bool talk3;
		public bool spawnMessage; 
        public override bool PreAI()
        {
            npc.ai[3]++;
            spawnTimer++;
            shootTimer++;
            shootTimer2++;
            shootTimer3++;
            shootTimer4++;
            shootTimer5++;
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
            if (spawnTimer >= 400 && NPC.CountNPCS(mod.NPCType("NullDevourer")) <= 3)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("NullDevourer"));
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
                float Speed = 8f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 12;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("PhantomFemurHostile");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer = 0;
            }
            if (shootTimer2 >= 250)
            {
                Main.PlaySound(SoundID.Item8, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 9f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 12;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("PhantomFemurHostile");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer2 = 0;
            }
            if (shootTimer3 >= 260)
            {
                Main.PlaySound(SoundID.Item8, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 10f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 12;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("PhantomFemurHostile");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer3 = 0;
            }
            if (shootTimer4 >= 270)
            {
                Main.PlaySound(SoundID.Item8, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 11f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 12;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("PhantomFemurHostile");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer4 = 0;
            }
            if (shootTimer5 >= 280)
            {
                Main.PlaySound(SoundID.Item8, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 12f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 12;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("PhantomFemurHostile");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer5 = 0; //resets the timer
            }
            return true;
        }
    public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
    {
            target.AddBuff((BuffID.Obstructed), 60);
            target.AddBuff((BuffID.WitheredWeapon), 100);
            target.AddBuff(mod.BuffType("BelowZero"), 120);
        }
    }
}