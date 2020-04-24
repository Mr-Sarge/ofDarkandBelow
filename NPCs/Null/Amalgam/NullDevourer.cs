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

namespace ofDarkandBelow.NPCs.Null.Amalgam
{
    public class NullDevourer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null Devourer");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.width = 52;
            npc.height = 42;
            npc.friendly = false;
            npc.damage = 20;
            npc.defense = 0;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0f;
			npc.noTileCollide = true;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 44;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.5;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 1f, npc.velocity.Y * 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NullDevourerGore1"), 1f);
            }
        }
        private int shootTimer;
        private int shootTimer2;
        public override bool PreAI()
        {
        shootTimer++;
        shootTimer2++;
		Player player = Main.player[npc.target];
		if (player.Center.X > npc.Center.X)
		{
   		    npc.spriteDirection = -1;
		}
		else
		{
   		    npc.spriteDirection = 1;
		}
		npc.ai[1]++;
if (npc.ai[1] >= 400)
{
    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
    {
        float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + 
(Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
        npc.velocity.X = (float)(Math.Cos(rotation) * 15) * -1;
        npc.velocity.Y = (float)(Math.Sin(rotation) * 15) * -1;
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
            if (shootTimer >= 200)
            {
                Main.PlaySound(SoundID.Item8, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 8f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 6;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("PhantomFemurHostile");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer = 0;
            }
            if (shootTimer2 >= 240)
            {
                Main.PlaySound(SoundID.Item8, (int)npc.position.X, (int)npc.position.Y);
                float Speed = 8f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                int damage = 6;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                int type = mod.ProjectileType("PhantomFemurHostile");  //put your projectile
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                shootTimer2 = 0;
            }
            return true;
		}
    }
}