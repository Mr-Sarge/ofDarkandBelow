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
    public class NullSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Slime");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 44;
            npc.height = 30;
            npc.alpha = 80;
            npc.friendly = false;
            npc.damage = 25;
            npc.defense = 5;
            npc.lifeMax = 110;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 120f;
            npc.knockBackResist = 0.75f;
            npc.noGravity = false;
            npc.aiStyle = 1;
            aiType = 1;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 || npc.life == 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NullEnemies/NullSlimeEyeGore"), 1f);
                for (int i = 0; i < 8; i++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("NullDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 20, default, 0.75f);
                }
                Projectile.NewProjectile((int)npc.Center.X, (int)npc.Center.Y - 30, 0f, 0f, mod.ProjectileType("NullSlime_Explosion"), 30, 0f, 0);
            }
            for (int i = 0; i < 4; i++)
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, mod.DustType("NullDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 20, default, 0.75f);
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
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.1;
            npc.frameCounter %= 2;
            int frame = (int)(npc.frameCounter);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Texture2D eyeAni = mod.GetTexture("NPCs/Null/NullSlime_Eye");
            Texture2D glowMask = mod.GetTexture("NPCs/Null/NullSlime_Glowmask");
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(eyeAni, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            spriteBatch.Draw(glowMask, npc.Center - Main.screenPosition, npc.frame, npc.GetAlpha(Color.White), npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return true;
        }
        public override void AI()
        {
            Lighting.AddLight(npc.position, 0f, 0.6f, 0.6f);
        }
    }
}