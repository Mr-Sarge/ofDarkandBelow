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
    public class SunkenKing : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Sunken King");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
		    npc.lifeMax = 4200;
            npc.width = 218;
            npc.height = 260;
            npc.friendly = false;
            npc.damage = 0;
            npc.defense = 4;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            aiType = 0;
			npc.noTileCollide = false; 
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SunkenBelowMadness");
        }
		private int shootTimer;
		private int shootTimer2;
		private int shootTimer3;
		private int shootTimer4;
		private int chunkTimer;
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunk1"), 1f);
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SunkenKingPhase2"));
			}
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.25f);
            npc.defense = 6;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.8;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 4.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        public override bool PreAI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            shootTimer++;
			shootTimer2++;
			shootTimer3++;
			shootTimer4++;
			chunkTimer++;
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
            if (shootTimer3 >= 280)
            {
                Main.PlaySound(SoundID.Item71, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 8f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 15;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("MushSpike");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer3 = 0; //resets the timer
            }
            if (shootTimer4 >= 300)
            {
                Main.PlaySound(SoundID.Item71, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 8.5f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 15;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("MushSpike");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer4 = 0; //resets the timer
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
		return false;
		}
    }
}