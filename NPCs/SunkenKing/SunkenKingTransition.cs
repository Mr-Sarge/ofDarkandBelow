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
    public class SunkenKingTransition : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Sunken King");
            Main.npcFrameCount[npc.type] = 11;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 4200;
            npc.width = 250;
            npc.height = 434;
            npc.friendly = false;
            npc.damage = 0;
            npc.defense = 999;
            npc.value = 20f;
            npc.knockBackResist = 0f;
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Bosses/OldTerraHit");
            npc.aiStyle = 0;
            aiType = 0;
            npc.noTileCollide = true;
            npc.noGravity = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SunkenBelowMadness");
        }
        public bool transition2B;
        public bool transition3B;
        public bool transition5B;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Texture2D transition2 = mod.GetTexture("NPCs/SunkenKing/SunkenKingTransition2");
            Texture2D transition3 = mod.GetTexture("NPCs/SunkenKing/SunkenKingTransition3");
            Texture2D transition5 = mod.GetTexture("NPCs/SunkenKing/SunkenKingTransition5");

            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (!transition2B && !transition3B && !transition5B)
            {
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (transition2B)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = transition2.Height / 11; // 6 is number of frames
                int y6 = num214 * transition2Frame;
                Main.spriteBatch.Draw(transition2, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, transition2.Width, num214)), drawColor, npc.rotation, new Vector2((float)transition2.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (transition3B)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = transition3.Height / 12; // 6 is number of frames
                int y6 = num214 * transition3Frame;
                Main.spriteBatch.Draw(transition3, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, transition3.Width, num214)), drawColor, npc.rotation, new Vector2((float)transition3.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (transition5B)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = transition5.Height / 12; // 6 is number of frames
                int y6 = num214 * transition5Frame;
                Main.spriteBatch.Draw(transition5, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, transition5.Width, num214)), drawColor, npc.rotation, new Vector2((float)transition5.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            return false;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25;
            npc.frameCounter %= 22;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        private int dedTimer;
        public int transition2Frame;
        public int transition2Counter;
        public int transition3Frame;
        public int transition3Counter;
        public int transition5Frame;
        public int transition5Counter;
        public override void AI()
        {
            if (transition2B == true)
            {
                transition2Counter++;
                if (transition2Counter > 4)
                {
                    transition2Frame++;
                    transition2Counter = 0;
                }
                if (transition2Frame >= 11)
                {
                    transition2Frame = 0;
                    transition2B = false;
                    transition3B = true;
                }
            }
            if (transition3B == true)
            {
                transition3Counter++;
                if (transition3Counter > 4)
                {
                    transition3Frame++;
                    transition3Counter = 0;
                }
                if (transition3Frame >= 11)
                {
                    transition3Frame = 0;
                    transition3B = false;
                    transition5B = true;
                }
            }

            if (transition5B == true)
            {
                transition5Counter++;
                if (transition5Counter > 4)
                {
                    transition5Frame++;
                    transition5Counter = 0;
                }
                if (transition5Frame >= 12)
                {
                    transition5Frame = 0;
                    transition5B = false;
                }
            }
            npc.ai[1]++;
            dedTimer++;
            {
                if (npc.ai[1] == 46)
                {
                    transition2B = true;
                }
                if (npc.ai[0] == 0)
                {
                    npc.velocity.Y += 0.01f;
                    if (npc.velocity.Y > .3f)
                    {
                        npc.ai[0] = 1f;
                        npc.netUpdate = true;
                    }
                }
                else if (npc.ai[0] == 1)
                {
                    npc.velocity.Y -= 0.01f;
                    if (npc.velocity.Y < -.3f)
                    {
                        npc.ai[0] = 0f;
                        npc.netUpdate = true;
                    }
                }
                if (dedTimer >= 200)
                {
                    Vector2 usePos = npc.position; // Position to use for dusts
                    Vector2 rotVector = (npc.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
                    usePos += rotVector * 16f;
                    // Create a new dust
                    Dust dust = Dust.NewDustDirect(usePos, npc.width, npc.height, 16);
                    Dust dust2 = Dust.NewDustDirect(usePos, npc.width * 2, npc.height * 2, 16);
                    Dust dust3 = Dust.NewDustDirect(usePos, npc.width * 1, npc.height * 1, 16);
                    dust.position = (dust.position + npc.Center) / 2f;
                    dust.velocity += rotVector * 2f;
                    dust.velocity *= 0.5f;
                    dust.noGravity = true;
                    dust2.velocity *= 0.8f;
                    dust2.noGravity = true;
                    dust3.noGravity = true;
                    dust3.scale *= 1.2f;
                    dust3.velocity *= 1f;
                    Main.PlaySound(SoundID.NPCDeath1, (int)npc.position.X, (int)npc.position.Y);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore1"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore2"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore3"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore4"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore5"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore6"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore7"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore8"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SKTransition/SKGore9"), 1f);
                    npc.SetDefaults(mod.NPCType("SunkenKingPhase2New"));
                }
                return;
            }
        }
    }
}