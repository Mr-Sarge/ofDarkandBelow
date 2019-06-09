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
    public class SunkenDragon : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunken Dragon");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.width = 60;
            npc.height = 66;
            npc.friendly = false;
            npc.damage = 20;
            npc.defense = 6;
            npc.lifeMax = 120;
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
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * 1f, npc.velocity.Y * 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenDragonGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenDragonGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenDragonGore3"), 1f);
            }
        }
		public override bool PreAI()
        {
		Player player = Main.player[npc.target];
		if (player.Center.X > npc.Center.X)
		{
   		    npc.spriteDirection = 1;
		}
		else
		{
   		    npc.spriteDirection = -1;
		}
		npc.ai[1]++;
if (npc.ai[1] >= 300)
{
    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
    {
        float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + 
(Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
        npc.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
        npc.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
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
    }
}