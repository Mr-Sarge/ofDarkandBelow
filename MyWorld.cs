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
using Terraria.Utilities;

using ofDarkandBelow.Items;
using ofDarkandBelow.Items.FishStash;
using ofDarkandBelow.Items.Thrower;

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

        public override void PostWorldGen() {

			int[] itemsToPlaceInSkywareChests = {ModContent.ItemType<ShootingStar>(), ItemID.None};
			int itemsToPlaceInSkywareChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 13 * 36) {
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
						if (chest.item[inventoryIndex].type == ItemID.None) {
							chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInSkywareChests));
							itemsToPlaceInSkywareChestsChoice = (itemsToPlaceInSkywareChestsChoice + 1) % itemsToPlaceInSkywareChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInSkywareChests));
							break;
						}
					}
				}
			}
            int[] itemsToPlaceInDungeonChests = {ModContent.ItemType<Tanto>(), ItemID.None, ItemID.None, ItemID.None, ItemID.None, ItemID.None};
			int itemsToPlaceInDungeonChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36) {
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
						if (chest.item[inventoryIndex].type == ItemID.None) {
							chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInDungeonChests));
							itemsToPlaceInDungeonChestsChoice = (itemsToPlaceInDungeonChestsChoice + 1) % itemsToPlaceInDungeonChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInDungeonChests));
							break;
						}
					}
				}
            }
		}

        public override void ResetNearbyTileEffects()
        {
            shrineBiome = 0;
        }
    }
}