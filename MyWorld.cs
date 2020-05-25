using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace ofDarkandBelow
{
    public class MyWorld : ModWorld
    {
        public static bool skeletronBronzeMessage;
        public static bool downedSunkenKing;
        public static bool downedAmalgamation;
        public static bool downedPrimordialMaw;
        public static int shrineBiome = 0;
        public override void PostUpdate()
        {
            if (NPC.downedBoss3 && !skeletronBronzeMessage)
            {
                skeletronBronzeMessage = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
                string key = "Mods.ofDarkandBelow.SkeletronBronzeMessage";
                Color messageColor = Color.Orange;
                if (Main.netMode == 2) // Server
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromKey(key), messageColor);
                }
                else if (Main.netMode == 0) // Single Player
                {
                    Main.NewText(Language.GetTextValue(key), messageColor);
                }
            }
        }

        public override void Initialize()
        {
            skeletronBronzeMessage = false;
			downedSunkenKing = false;
			downedAmalgamation = false;
			downedPrimordialMaw = false;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();
            bool skebronze = false;
            if (skeletronBronzeMessage) skebronze = true;
			if (downedSunkenKing) {
				downed.Add("sunkenking");
			}
			if (downedAmalgamation) {
				downed.Add("amalgamation");
			}
			if (downedPrimordialMaw) {
				downed.Add("primordialmaw");
			}
            return new TagCompound {
                {"downed", downed},
                {"skeleM", skebronze },
            };
        }
        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            skeletronBronzeMessage = tag.GetBool("skeleM");
			downedSunkenKing = downed.Contains("sunkenking");
			downedAmalgamation = downed.Contains("amalgamation");
			downedPrimordialMaw = downed.Contains("primordialmaw");
        }

		public override void NetSend(BinaryWriter writer) {
			BitsByte flags = new BitsByte();
			flags[0] = downedSunkenKing;
			flags[1] = downedAmalgamation;
			flags[2] = downedPrimordialMaw;
			writer.Write(flags);
		}
        public override void TileCountsAvailable(int[] tileCounts)
        {
            shrineBiome = tileCounts[mod.TileType("DragonStoneATile")];
        }
        public override void ResetNearbyTileEffects()
        {
            shrineBiome = 0;
        }
    }
}