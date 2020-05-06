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

namespace ofDarkandBelow.NPCs.SunkenKing
{
    public class SunkenGoliath: ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunken Goliath");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.width = 52;
            npc.height = 68;
            npc.friendly = false;
            npc.damage = 25;
            npc.defense = 45;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit41;
            npc.DeathSound = SoundID.NPCDeath41;
            npc.value = 0f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 3;
            npc.scale = 1.2f;
			aiType = NPCID.GoblinScout;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 1f, npc.velocity.Y * 2f);
                for (int i = 0; i < 20; i++)
                {
                    Vector2 usePos = npc.position; // Position to use for dusts
                    Vector2 rotVector = (npc.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
                    usePos += rotVector * 16f;
                    // Create a new dust
                    Dust dust = Dust.NewDustDirect(usePos, npc.width, npc.height, 16);
                    Dust dust2 = Dust.NewDustDirect(usePos, npc.width, npc.height, 16);
                    Dust dust3 = Dust.NewDustDirect(usePos, npc.width, npc.height, 16);
                    dust.position = (dust.position + npc.Center) / 2f;
                    dust.velocity += rotVector * 2f;
                    dust.velocity *= 0.5f;
                    dust.noGravity = true;
                    dust2.velocity *= 0.8f;
                    dust2.noGravity = true;
                    dust3.noGravity = true;
                    dust3.scale *= 1.2f;
                    dust3.velocity *= 1f;
                }
            }
        }
        public bool charge1;
        public bool rest;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Texture2D chargeAni = mod.GetTexture("NPCs/SunkenKing/SunkenGoliath_charge");
            Texture2D restAni = mod.GetTexture("NPCs/SunkenKing/SunkenGoliath_rest");
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (!charge1 && !rest)
            {
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (charge1)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = chargeAni.Height / 4;
                int y6 = num214 * chargeFrame;
                Main.spriteBatch.Draw(chargeAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, chargeAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)chargeAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (rest)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = restAni.Height / 9;
                int y6 = num214 * restFrame;
                Main.spriteBatch.Draw(restAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, restAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)restAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            return false;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25;
            npc.frameCounter %= 12;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        public int chargeFrame;
        public int chargeCounter;
        public int restFrame;
        public int restCounter;
        private int chargeTimer;
        private int shroomTimer;
        public override void AI()
        {
            if (Main.player[npc.target].dead)
            {
                npc.timeLeft = 0;
            }
            if (charge1 == true)
            {
                chargeCounter++;
                if (chargeCounter > 6)
                {
                    chargeFrame++;
                    chargeCounter = 0;
                }
                if (chargeFrame >= 4)
                {
                    chargeFrame = 0;
                }
            }
            if (rest == true)
            {
                restCounter++;
                if (restCounter > 6)
                {
                    restFrame++;
                    restCounter = 0;
                }
                if (restFrame >= 9)
                {
                    restFrame = 0;
                }
            }
            return;
        }
        public override bool PreAI()
        {
            Player player = Main.player[npc.target];
            if (npc.velocity.X >= 0)
            {
                npc.spriteDirection = 1;
            }
            else if (npc.velocity.X < 0)
            {
                npc.spriteDirection = -1;
            }
            chargeTimer++;
            shroomTimer++;
            if (shroomTimer == 120)
            {
                Projectile.NewProjectile((int)npc.Center.X, (int)npc.Center.Y, 0f, 0f, mod.ProjectileType("tinyshroom"), 10, 0f, 0);
                shroomTimer = 0;
            }
            if (chargeTimer >= 340)
            {
                charge1 = true;
                if (npc.velocity.X < 0)
                {
                    npc.damage = 70;
                    npc.velocity.X -= 0.15f;
                    npc.velocity.Y += 20f;
                }
                if (npc.velocity.X > 0)
                {
                    npc.damage = 45;
                    npc.velocity.X += 0.15f;
                    npc.velocity.Y += 20f;
                }
            }
            if (chargeTimer >= 410)
            {
                charge1 = false;
                npc.velocity.X *= 0;
                npc.defense = 0;
                npc.damage = 12;
                rest = true;
            }
            if (chargeTimer == 570)
            {
                rest = false;
                if (npc.life >= npc.lifeMax * 0.50)
                {
                    chargeTimer = 100;
                }
                else
                {
                    chargeTimer = 0;
                }
                npc.defense = 45;
            }
            return true;
        }
    }
}