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

namespace ofDarkandBelow.NPCs
{
    public class SGlobalNPC : GlobalNPC
    {
	private bool bronzeDrop;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public bool horrorHemorrhage = false;
        public bool dracarniumFlames = false;
        public bool eelSpiked = false;
        public bool cosmicFlame = false;
		public bool tainted = false;
		public bool belowZero = false;
        public bool hidepierced = false;
        public override void ResetEffects(NPC npc)
        {
            dracarniumFlames = false;
            eelSpiked = false;
            cosmicFlame = false;
			tainted = false;
            belowZero = false;
            horrorHemorrhage = false;
            hidepierced = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (hidepierced)
            {
                npc.defense -= 25;
            }
            if (cosmicFlame)
            {
				int DustID2 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("CosmicDust"), npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 20, default(Color), 2f);
                Main.dust[DustID2].noGravity = true;
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 25;
                if (damage < 1)
                {
                    damage = 3;
                }
			}
            if (tainted)
			{
 				int DustID3 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("TaintedDust"), npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[DustID3].noGravity = true;
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 30;
                if (damage < 1)
                {
                    damage = 5;
                }
            }
            if (belowZero)
            {
                int DustID3 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("NullFire"), npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[DustID3].noGravity = true;
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 18;
                if (damage < 1)
                {
                    damage = 1;
                }
            }
            if (horrorHemorrhage)
            {
            int DustID4 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("HorrorHemorrhageDust"), npc.velocity.X * 0.6f, npc.velocity.Y * 0.2f, 20, default(Color), 2f);
            Main.dust[DustID4].noGravity = true;
            npc.defense -= 45;
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
                npc.lifeRegen -= 48;
                if (damage < 1)
            {
                damage = 8;
                }
            }
            if (dracarniumFlames)
            {
                npc.defense -= 8;
                int DustID2 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("DracarniumFlamesDust"), npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 20, default(Color), 1f);
                Main.dust[DustID2].noGravity = true;
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
                if (damage < 1)
                {
                    damage = 2;
                }
            }
            if (eelSpiked)
            {
                npc.defense -= 6;
                int DustID2 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("DracarniumFlamesDust"), npc.velocity.X * 0.45f, npc.velocity.Y * 0.3f, 20, default(Color), 0.7f);
                Main.dust[DustID2].noGravity = true;
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 46;
                if (damage < 1)
                {
                    damage = 4;
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (hidepierced)
            {
                drawColor = Color.Violet;
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("CosmicDust"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, drawColor, .5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
        }
    }
}