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
            Main.npcFrameCount[npc.type] = 3;
        }
        public override void SetDefaults()
        {
		    npc.lifeMax = 2200;
            npc.width = 92;
            npc.height = 162;
            npc.friendly = false;
            npc.damage = 45;
            npc.defense = 4;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 44;
			aiType = NPCID.Harpy;
			npc.boss = true;
			npc.noTileCollide = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SunkenBelowMadness");
            bossBag = mod.ItemType("SunkenKingBag");
        }
		private int shootTimer;
		private int shootTimer2;
		private int chunkTimer;
		private int dragonTimer;
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.25f * bossLifeScale);
            npc.defense = 7;
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
            npc.frameCounter += 0.4;
            npc.frameCounter %= 10;
            int frame = (int)(npc.frameCounter / 4.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        public override bool PreAI()
        {
            if (Main.expertMode)
            {
               dragonTimer++;
			}
            npc.TargetClosest(true);
            shootTimer++;
			shootTimer2++;
			chunkTimer++;
			npc.ai[1]++;
            Player player = Main.player[npc.target];
	     	if (player.Center.X > npc.Center.X)
	     	{
   		        npc.spriteDirection = 1;
	     	}
	     	else
	     	{
   		        npc.spriteDirection = -1;
	     	}
            if (shootTimer >= 240)
            {
                Main.PlaySound(SoundID.Item71, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 7f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 15;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("MushSpike");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer = 0; //resets the timer
            }
            if (shootTimer2 >= 260)
            {
                Main.PlaySound(SoundID.Item71, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 7.5f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 15;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("MushSpike");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer2 = 0; //resets the timer
			}
            if (chunkTimer >= 360)
            {
                Main.PlaySound(SoundID.Item71, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 4.5f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 25;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("SunkenChunk");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                chunkTimer = 0; //resets the timer
            }
            if (Main.expertMode && dragonTimer >=400 && NPC.CountNPCS(mod.NPCType("SunkenDragon")) <= 3)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SunkenDragon"));
                dragonTimer = 0;
			}
			if (npc.ai[1] >= 240)
			{
    			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
    			{
    			    float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + 
			(Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
     			   npc.velocity.X = (float)(Math.Cos(rotation) * 13) * -1;
     			   npc.velocity.Y = (float)(Math.Sin(rotation) * 13) * -1;
   			 }
   			 npc.ai[0] %= (float)Math.PI * 2f;
   			 Vector2 offset = new Vector2((float)Math.Cos(npc.ai[0]), (float)Math.Sin(npc.ai[0]));
    			Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
   			 Color color = new Color();
   			 Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
  			  int count = 30;
    			for (int i = 1; i <= count; i++)
   			 {
   					int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 14, 0, 0, 100, color, 1.2f);
    			    Main.dust[dust].noGravity = false;
  			 }
			npc.ai[1] = 0;
		}
		return true;
	    }
        public override void NPCLoot()
        {
            Vector2 position = npc.position;
            Vector2 center = Main.player[npc.target].Center;
            float num4 = 1E+08f;
            Vector2 position2 = center;
            if (Main.expertMode)
            {
                npc.DropBossBags();
				npc.position = position;
            }
            else
            {
				if (Main.rand.NextBool()) {
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FirstTerraBlade"));
				}
				if (Main.rand.NextBool(3)) {
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KinglyKnife"));
				}
				if (Main.rand.NextBool(3)) {
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KingsHarvest"));
				}
				npc.position = position;
          	}
		}
    }
}