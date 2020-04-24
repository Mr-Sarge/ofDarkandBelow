using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.NPCs.Null
{
    public class NullWalker : ModNPC
    {
        private bool jump;
        private int jumpFrame;
        private int jumpCounter;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Walker");
            Main.npcFrameCount[npc.type] = 10;
        }
        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 68;
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
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Neiroplasm"), 4);
		}
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
		public override bool PreAI()
        {
            if (npc.velocity.X >= 0)
            {
                npc.spriteDirection = -1;
            }
            else if (npc.velocity.X < 0)
            {
                npc.spriteDirection = 1;
            }
            return true;
        }
        public override void AI()
        {
            if (npc.velocity.Y == 0)
            {
                jump = false;
            }
            else
            {
                jump = true;
            }
            return;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Texture2D jumpAni = mod.GetTexture("NPCs/Null/NullWalker_Jump");
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (jump == false)
            {
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (jump == true)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = jumpAni.Height / 1;
                int y6 = num214 * jumpFrame;
                Main.spriteBatch.Draw(jumpAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, jumpAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)jumpAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            return false;
        }
    }
}