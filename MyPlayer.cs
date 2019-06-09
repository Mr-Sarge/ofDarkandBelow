using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using ofDarkandBelow.Buffs;

namespace ofDarkandBelow
{
    public class MyPlayer : ModPlayer
    {
	   public bool cosmicFlame;
	   public bool tainted;
	   public bool riftspiritMinion;

	public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
			if (cosmicFlame) {
				if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
					 int DustID2 = Dust.NewDust(player.position, player.width, player.height, 21, player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 20, default(Color), 1f);
                     Main.dust[DustID2].noGravity = true;
                }
			}
			if (tainted) {
				if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
					 int DustID2 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("TaintedDust"), player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 20, default(Color), 1f);
                     Main.dust[DustID2].noGravity = false;
                }
			}
	}
}}