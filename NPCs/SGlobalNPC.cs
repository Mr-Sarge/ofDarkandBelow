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
        public bool cosmicFlame = false;
		public bool tainted = false;
		public bool belowZero = false;
        public override void ResetEffects(NPC npc)
        {
            dracarniumFlames = false;
            cosmicFlame = false;
			tainted = false;
            belowZero = false;
            horrorHemorrhage = false;
    }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
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
        }
    }
}