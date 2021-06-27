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

namespace ofDarkandBelow.NPCs.Null
{
    public class NullWalker : ModNPC
    {
        private bool jump;
        private int jumpFrame;
        private int jumpCounter;
        public bool definitelyBalled;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Walker");
            Main.npcFrameCount[npc.type] = 10;
        }
        public override void SetDefaults()
        {
            npc.friendly = false;
            npc.damage = 40;
            npc.defense = 4;
            npc.lifeMax = 150;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 3;
			aiType = NPCID.GoblinScout;
            npc.width = 36;
            npc.height = 66;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		if(NPC.downedQueenBee)
            if (Main.hardMode)
            {
                return SpawnCondition.Dungeon.Chance * 0.03f;
				return SpawnCondition.Underworld.Chance * 0.03f;
            }
            else
            {
                return SpawnCondition.Dungeon.Chance * 0.07f;
				return SpawnCondition.Underworld.Chance * 0.07f;
            }
		else
		    if (Main.hardMode)
            {
            return SpawnCondition.Dungeon.Chance * 0.03f;
			return SpawnCondition.Underworld.Chance * 0.03f;
            } 
            else
            {
            return SpawnCondition.Dungeon.Chance * 0.07f;
			return SpawnCondition.Underworld.Chance * 0.07f;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 || npc.life == 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NullEnemies/NullWalker_BalledWringly"), 1f);
            }
        }
        public int intoBallFrame;
        public int intoBallCounter;
		public override bool PreAI()
        {
            if (balledYet != true && intoBall != true)
            {
                if (npc.velocity.X >= 0)
                {
                    npc.spriteDirection = -1;
                }
                else if (npc.velocity.X < 0)
                {
                    npc.spriteDirection = 1;
                }
            }
            if (intoBall == true)
            {
                intoBallCounter++;
                if (intoBallCounter > 3)
                {
                    intoBallFrame++;
                    intoBallCounter = 0;
                }
            }
            if (intoBallFrame >= 12)
            {
                balledYet = true;
                intoBall = false;
            }
            return true;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.5;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter) / 2;
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        public bool intoBall;
        public bool balled;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Texture2D intoBallAni = mod.GetTexture("NPCs/Null/NullWalker_Ballin");
            Texture2D balledAni = mod.GetTexture("NPCs/Null/NullWalker_Balled");
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            if (!intoBall && !balled)
            {
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (intoBall)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y - 20);
                int num214 = intoBallAni.Height / 12; // 12 = # of Frames
                int y6 = num214 * intoBallFrame;
                Main.spriteBatch.Draw(intoBallAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, intoBallAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)intoBallAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (balled)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = balledAni.Height / 2;
                int y6 = num214 * 1;
                Main.spriteBatch.Draw(balledAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, balledAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)balledAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            return false;
        }
        public bool balledYet;
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (npc.life < npc.lifeMax * 0.45 && balledYet == false)
            {
                intoBall = true;
                aiType = 0;
                npc.aiStyle = 0;
                npc.width = 28;
                npc.height = 26;
            }
            if (balledYet == true)
            {
                balled = true;
                npc.width = 28;
                npc.height = 26;
                aiType = 26;
                npc.aiStyle = 26;
                npc.rotation += 0.02f * npc.velocity.X;
                npc.knockBackResist = 0.4f;
            }
            return;
        }
    }
}