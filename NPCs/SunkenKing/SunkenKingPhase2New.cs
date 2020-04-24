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
using ofDarkandBelow.Projectiles;

namespace ofDarkandBelow.NPCs.SunkenKing
{
    [AutoloadBossHead]
    public class SunkenKingPhase2New : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Sunken King");
            Main.npcFrameCount[npc.type] = 12;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 2750;
            npc.width = 128;
            npc.height = 292;
            npc.friendly = false;
            npc.boss = true;
            npc.damage = 45;
            npc.defense = 12;
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraHit");
            npc.DeathSound = SoundID.NPCDeath58;
            npc.value = 20f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 14;
            aiType = NPCID.CaveBat;
            npc.boss = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SunkenBelowMadness");
            bossBag = mod.ItemType("SunkenKingBag");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.25f * bossLifeScale);
            npc.defense = 13;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenKingPart1"), 1f);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.5;
            npc.frameCounter %= 24;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        public bool attack1;
        public bool attack2;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Texture2D slashAni = mod.GetTexture("NPCs/SunkenKing/SunkenKingPhase2New_Attack1");
            Texture2D slashAni2Downward = mod.GetTexture("NPCs/SunkenKing/SunkenKingPhase2New_Attack2");
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (!attack1 && !attack2)
            {
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (attack1)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = slashAni.Height / 5; // 6 is number of frames
                int y6 = num214 * attack1Frame;
                Main.spriteBatch.Draw(slashAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, slashAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)slashAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }

            if (attack2)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = slashAni2Downward.Height / 8; // 6 is number of frames
                int y6 = num214 * attack2Frame;
                Main.spriteBatch.Draw(slashAni2Downward, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, slashAni2Downward.Width, num214)), drawColor, npc.rotation, new Vector2((float)slashAni2Downward.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            return false;
        }
        private int narrowbarrageohshitTimer;
        private int attack1Timer;
        private int chargeTimer;
        private int angry1Timer;
        private int angry2Timer;
        private int angry3Timer;
        public int attack1Frame;
        public int attack1Counter;
        public int attack2Frame;
        public int attack2Counter;

        public override void AI()
        {
            Lighting.AddLight(npc.position, 0f, 0.45f, 0.65f);
            if (Main.player[npc.target].dead)
            {
                npc.timeLeft = 0;
            }
            if (attack1 == true)
            {
                attack1Counter++;
                if (attack1Counter > 3)
                {
                    attack1Frame++;
                    attack1Counter = 0;
                }
                if (attack1Frame >= 5)
                {
                    attack1Frame = 0;
                    attack1 = false;
                }
            }
            if (attack2 == true)
            {
                attack2Counter++;
                if (attack2Counter > 3)
                {
                    attack2Frame++;
                    attack2Counter = 0;
                }
                if (attack2Frame >= 8)
                {
                    attack2Frame = 0;
                    attack2 = false;
                }
            }
            Player player = Main.player[npc.target];
            attack1Timer++;
            narrowbarrageohshitTimer++;
            npc.ai[3]++;

            if (npc.life < npc.lifeMax * 0.40)
            {
                angry1Timer++;
            }

            if (npc.life < npc.lifeMax * 0.20)
            {
                angry2Timer++;
                angry3Timer++;
            }

            if (attack1Timer >= 350)
            {
                if (npc.life < npc.lifeMax * 0.50)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                    attack1 = true;
                    float Speed = 12f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 18;  //projectile damage
                    int type = mod.ProjectileType("KingBeam");  //put your projectile
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                    int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                    int num57 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                    int num58 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                    Main.projectile[num54].netUpdate = true;
                    Main.projectile[num55].netUpdate = true;
                    Main.projectile[num56].netUpdate = true;
                    Main.projectile[num57].netUpdate = true;
                    Main.projectile[num58].netUpdate = true;
                    attack1Timer = 100;
                }
                if (npc.life > npc.lifeMax * 0.50)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                    attack1 = true;
                    float Speed = 9f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 18;  //projectile damage
                    int type = mod.ProjectileType("KingBeam");  //put your projectile
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                    int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                    Main.projectile[num54].netUpdate = true;
                    Main.projectile[num55].netUpdate = true;
                    Main.projectile[num56].netUpdate = true;
                    attack1Timer = 0;
                }
            }

            if (narrowbarrageohshitTimer >= 500)
            {
                attack1 = true;
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSpike"));
                float Speed = 10f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 3), npc.position.Y + (npc.height / 3));
                int damage = 10;  //projectile damage
                int type = mod.ProjectileType("SharproomNarrow");
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num56 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num57 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num58 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num59 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num60 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num61 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num62 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                Main.projectile[num54].netUpdate = true;
                Main.projectile[num55].netUpdate = true;
                Main.projectile[num56].netUpdate = true;
                Main.projectile[num57].netUpdate = true;
                Main.projectile[num58].netUpdate = true;
                Main.projectile[num59].netUpdate = true;
                Main.projectile[num60].netUpdate = true;
                Main.projectile[num61].netUpdate = true;
                Main.projectile[num62].netUpdate = true;
                narrowbarrageohshitTimer = 0;
            }
            npc.rotation = npc.velocity.X * 0.02f;
            if (npc.ai[2] == 0)
            {
                npc.velocity.Y += 0.005f;
                if (npc.velocity.Y > .3f)
                {
                    npc.ai[2] = 1f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[2] == 1)
            {
                npc.velocity.Y -= 0.005f;
                if (npc.velocity.Y < -.3f)
                {
                    npc.ai[2] = 0f;
                    npc.netUpdate = true;
                }
            }

            if (npc.ai[3] >= 600)
            {
                attack2 = true;
                npc.velocity = npc.DirectionTo(player.Center) * 10;
            }
            if (npc.ai[3] == 620)
            {
                npc.ai[3] = 0;
            }
            if (angry1Timer == 300)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                attack1 = true;
                float Speed = 12f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 18;  //projectile damage
                int type = mod.ProjectileType("KingBeam");  //put your projectile
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                Main.projectile[num54].netUpdate = true;
                Main.projectile[num55].netUpdate = true;
                Main.projectile[num56].netUpdate = true;
                angry1Timer = 0;
            }
            if (angry2Timer == 340)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                attack2 = true;
                float Speed = 15f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 18;  //projectile damage
                int type = mod.ProjectileType("KingBeam");  //put your projectile
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num57 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, mod.ProjectileType("Sharproom"), 15, 0f, 0);
                Main.projectile[num54].netUpdate = true;
                Main.projectile[num55].netUpdate = true;
                Main.projectile[num56].netUpdate = true;
                Main.projectile[num57].netUpdate = true;
                angry2Timer = 0;
            }
            if (angry3Timer == 400)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                attack2 = true;
                float Speed = 15f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 18;  //projectile damage
                int type = mod.ProjectileType("KingBeam");  //put your projectile
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, mod.ProjectileType("MushSpawnBig"), 7, 0f, 0);
                int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num57 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, mod.ProjectileType("Sharproom"), 15, 0f, 0);
                int num58 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, mod.ProjectileType("Sharproom"), 15, 0f, 0);
                Main.projectile[num54].netUpdate = true;
                Main.projectile[num55].netUpdate = true;
                Main.projectile[num56].netUpdate = true;
                Main.projectile[num57].netUpdate = true;
                Main.projectile[num58].netUpdate = true;
                angry3Timer = 0;
            }
            return;
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
        public override void NPCLoot()
        {
            Vector2 position = npc.position;
            Vector2 center = Main.player[npc.target].Center;
            Vector2 position2 = center;
            MyWorld.downedSunkenKing = true;
            if (Main.expertMode)
            {
                npc.DropBossBags();
                npc.position = position;
            }
            else
            {
                if (Main.rand.NextBool(3))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FirstTerraBlade"));
                }
                if (Main.rand.NextBool(3))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KinglyKnife"));
                }
                if (Main.rand.NextBool(3))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KingsHarvest"));
                }
                npc.position = position;
            }
        }
    }
}