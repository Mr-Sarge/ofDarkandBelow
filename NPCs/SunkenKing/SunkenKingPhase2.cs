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
    public class SunkenKingPhase2 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Sunken King");
            Main.npcFrameCount[npc.type] = 12;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 3200;
            npc.width = 90;
            npc.height = 250;
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
            if (hereWeGo <= 780)
            {
                npc.frameCounter += 0.35;
            }
            else
            {
                npc.frameCounter += 0.5;
            }
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
            Texture2D textureGlow = mod.GetTexture("NPCs/SunkenKing/SunkenKingPhase2_glowmask");
            Texture2D slashAni = mod.GetTexture("NPCs/SunkenKing/SunkenKingPhase2_Attack1");
            Texture2D slashAniGlow = mod.GetTexture("NPCs/SunkenKing/SunkenKingPhase2_Attack1_glowmask");
            Texture2D slashAni2Downward = mod.GetTexture("NPCs/SunkenKing/SunkenKingPhase2_Attack2");
            Texture2D slashAni2DownwardGlow = mod.GetTexture("NPCs/SunkenKing/SunkenKingPhase2_Attack2_glowmask");
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (!attack1 && !attack2)
            {
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
                spriteBatch.Draw(textureGlow, npc.Center - Main.screenPosition, npc.frame, npc.GetAlpha(Color.White), npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (attack1)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = slashAni.Height / 5; // 6 is number of frames
                int y6 = num214 * attack1Frame;
                Main.spriteBatch.Draw(slashAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, slashAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)slashAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
                Main.spriteBatch.Draw(slashAniGlow, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, slashAniGlow.Width, num214)), npc.GetAlpha(Color.White), npc.rotation, new Vector2((float)slashAniGlow.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }

            if (attack2)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = slashAni2Downward.Height / 8; // 6 is number of frames
                int y6 = num214 * attack2Frame;
                Main.spriteBatch.Draw(slashAni2Downward, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, slashAni2Downward.Width, num214)), drawColor, npc.rotation, new Vector2((float)slashAni2Downward.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
                Main.spriteBatch.Draw(slashAni2DownwardGlow, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, slashAni2DownwardGlow.Width, num214)), npc.GetAlpha(Color.White), npc.rotation, new Vector2((float)slashAni2DownwardGlow.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            return false;
        }
        public int attack1Frame;
        public int attack1Counter;
        public int attack2Frame;
        public int attack2Counter;
        private bool wyvernSpawn;
        private bool talkAngry;
        private bool talkAngry2;
        private int hereWeGo;
        private int pattern1;
        private int pattern2;
        private int pattern3;

        public override void AI()
        {
            npc.rotation = npc.velocity.X * 0.02f;
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
            if (npc.life < npc.lifeMax * 0.65 && wyvernSpawn == false && Main.expertMode)
            {
                Main.NewText("The King's pet has arrived!", Color.Blue.R, Color.Blue.G, Color.Blue.B);
                NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y, mod.NPCType("SunkenWyvern"));
                wyvernSpawn = true;
            }
            Lighting.AddLight(npc.position, 0f, 0.45f, 0.65f);
            if (Main.player[npc.target].dead)
            {
                npc.timeLeft = 0;
            }
            hereWeGo++;
            if (hereWeGo == 60)
            {
                Main.NewText("YOU KNOW WHO I ONCE WAS...", Color.Blue.R, Color.Blue.G, Color.Blue.B);
            }
            if (hereWeGo == 300)
            {
                Main.NewText("...AND AS THE ELDEST KING OF TERRA...", Color.Blue.R, Color.Blue.G, Color.Blue.B);
            }
            if (hereWeGo == 540)
            {
                Main.NewText("...I SHALL RECLAIM MY RIGHT TO THE THRONE...", Color.Blue.R, Color.Blue.G, Color.Blue.B);
            }
            if (hereWeGo == 780)
            {
                Main.NewText("...STARTING WITH BUILDING UPON THE REMAINS OF YOUR POWERLESS CORPSE!", Color.Blue.R, Color.Blue.G, Color.Blue.B);
            }
            if (hereWeGo >= 920)
            {
                npc.dontTakeDamage = false;
                hereWeGo = 935;
                pattern1++;
            }
            else
            {
                npc.dontTakeDamage = true;
                npc.velocity *= 0.45f;
            }
            if (pattern1 == 10)
            {
                attack1 = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 12) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 12) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (pattern1 == 280)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                attack1 = true;
                float Speed = 8f;  //projectile speed
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
            }
            if (pattern1 == 420)
            {
                attack2 = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 6) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 6) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (pattern1 == 480)
            {
                attack1 = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 8) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 8) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (pattern1 == 530)
            {
                attack2 = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (pattern1 == 620)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                attack1 = true;
                float Speed = 8f;  //projectile speed
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
            }
            if (pattern1 == 720)
            {
                pattern1 = 0;
            }
            if (npc.life < npc.lifeMax * 0.65)
            {
                pattern1 = 0;
                pattern2++;
            }
            if (pattern2 == 120)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                attack1 = true;
                float Speed = 10f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 14;  //projectile damage
                int type = mod.ProjectileType("Sharproom");  //put your projectile
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num57 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num58 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num59 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                Main.projectile[num54].netUpdate = true;
                Main.projectile[num55].netUpdate = true;
                Main.projectile[num56].netUpdate = true;
                Main.projectile[num57].netUpdate = true;
                Main.projectile[num58].netUpdate = true;
                Main.projectile[num59].netUpdate = true;
            }
            if (pattern2 == 220)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                attack1 = true;
                float Speed = 12f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 14;  //projectile damage
                int type = mod.ProjectileType("Sharproom");  //put your projectile
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num57 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num58 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num59 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                Main.projectile[num54].netUpdate = true;
                Main.projectile[num55].netUpdate = true;
                Main.projectile[num56].netUpdate = true;
                Main.projectile[num57].netUpdate = true;
                Main.projectile[num58].netUpdate = true;
                Main.projectile[num59].netUpdate = true;
            }
            if (pattern2 == 350)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)npc.position.X, (int)npc.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraSwingBoss"));
                float Speed = 14f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 14;  //projectile damage
                int type = mod.ProjectileType("Sharproom");  //put your projectile
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num56 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                int num57 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                int num58 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + -1, (float)((Math.Sin(rotation) * Speed) * -1) + -1, type, damage, 0f, 0);
                int num59 = Projectile.NewProjectile(vector8.X, vector8.Y - 100, (float)((Math.Cos(rotation) * Speed) * -1) + 1, (float)((Math.Sin(rotation) * Speed) * -1) + 1, type, damage, 0f, 0);
                Main.projectile[num54].netUpdate = true;
                Main.projectile[num55].netUpdate = true;
                Main.projectile[num56].netUpdate = true;
                Main.projectile[num57].netUpdate = true;
                Main.projectile[num58].netUpdate = true;
                Main.projectile[num59].netUpdate = true;
            }
            if (pattern2 == 350)
            {
                attack2 = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (pattern2 == 500)
            {
                attack2 = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.65f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.65f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (pattern2 == 560)
            {
                attack1 = true;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.45f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.45f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
                }
                npc.ai[0] %= (float)Math.PI * 2f;
                Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                Color color = new Color();
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
            }
            if (pattern2 == 690)
            {
                pattern2 = 0;
            }
            if (npc.life < npc.lifeMax * 0.40)
            {
                pattern1 = 0;
                pattern2 = 0;
                pattern3++;
            }
            return;
        }
        public override bool PreAI()
        {
            Player player = Main.player[npc.target];
            if (hereWeGo >= 920)
            {
                if (npc.velocity.X >= 0)
                {
                    npc.spriteDirection = 1;
                }
                else if (npc.velocity.X < 0)
                {
                    npc.spriteDirection = -1;
                }
            }
            else
            {
                if (player.Center.X > npc.Center.X)
                {
                    npc.spriteDirection = 1;
                }
                else
                {
                    npc.spriteDirection = -1;
                }
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