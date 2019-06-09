using System;
using ofDarkandBelow.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Utilities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ofDarkandBelow.Projectiles;

namespace ofDarkandBelow.NPCs.Friendly
{
    [AutoloadHead]
	public class FreakMerchant : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "ofDarkandBelow/NPCs/Friendly/FreakMerchant";
            }
        }
        public override bool Autoload(ref string name)
        {
            name = "FreakMerchant";
            return mod.Properties.Autoload;
        }

		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}
		public override void SetDefaults() {
			npc.friendly = true;
			npc.width = 42;
			npc.townNPC = true;
			npc.height = 46;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 0;
			npc.lifeMax = 600;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
			}
		}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Grusk";
				case 1:
					return "Gronk";
				case 2:
					return "Blark";
				case 3:
					return "Paurg";
				case 4:
					return "Urch";
				case 5:
					return "Kresch";
				default:
					return "Freak Merchant";
			}
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("You Build? Me have wood! Me have stone!");
			chat.Add("Me get dark wood from icy land! Is cold there.");
			chat.Add("What coin? Me no need coin.");
			chat.Add("Me sell weird thing! M-me not know how get it. Human get this if Human give me a copper!", 0.4);
			chat.Add("Me get have things thrown at me. Wanna see what me got?");
			chat.Add("Me find Seed! Me give to you in case.");
			chat.Add("I get copper, you get item!", 2.0);
			chat.Add("Me heard Vegemite crystals be infecting people! Or is me remembering wrong...", 0.1961751);
			chat.Add("Me not can live with humans. Humans kick always me out!", 0.5);
			chat.Add("Me saw broken fly snake with horns once!", 0.01);
			return chat;
		}

        public override void SetChatButtons(ref string button, ref string button2) 
        {
            button = "Buy Junk";
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool openShop)
        {
 
            if (firstButton)
            {
                openShop = true;
            }
        }
 
		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemID.Wood);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.BorealWood);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Seed);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.BlinkrootSeeds);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.StoneBlock);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.StrangeBrew);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("MysteriousDrink"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("FreakKnifePlayer"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("FreakMaterial"));
			nextSlot++;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 25;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = mod.ProjectileType("FreakKnife");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.Dungeon.Chance * 0.017f;
				return SpawnCondition.Cavern.Chance * 0.017f;
            }
            else
            {
                return SpawnCondition.Dungeon.Chance * 0.01f;
				return SpawnCondition.Cavern.Chance * 0.01f;
			}
        }
	}
}