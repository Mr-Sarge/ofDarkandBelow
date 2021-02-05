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
using ofDarkandBelow.Items.Null;
using ofDarkandBelow.Items.FishStash;
using ofDarkandBelow.Tiles.NullBlocks;
using ofDarkandBelow.Tiles;
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

		public class NullBiomeGen : TileRunner
		{
			public NullBiomeGen(Vector2 pos, Vector2 speed, Point16 hRange, Point16 vRange, double strength, int steps, ushort type, bool addTile, bool overRide) : base(pos, speed, hRange, vRange, strength, steps, type, addTile, overRide)
			{

			}
			public override bool ValidTile(Tile tile)
			{
				return tile.type == TileID.GreenDungeonBrick || tile.type == TileID.BlueDungeonBrick || tile.type == TileID.PinkDungeonBrick;
			}
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			//int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			int ShiniesIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Dungeon"));
			if (ShiniesIndex2 != -1)
			{
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex2 + 1, new PassLegacy("Generate Null Biome", NullBiomeGeneration));
			}

			int ShiniesIndex3 = tasks.FindIndex(genpass => genpass.Name.Equals("Dungeon"));
			if (ShiniesIndex3 != -1)
			{
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex3 + 2, new PassLegacy("Generate Null Chests", NullChestGeneration));
			}
		}

		private void NullBiomeGeneration(GenerationProgress progress)
		{
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Conjuring the Null";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
			{
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.active() && tile.type == TileID.PinkDungeonBrick)
				{
						new NullBiomeGen(new Vector2(x, y), Vector2.Zero, new Point16(-12, 12), new Point16(-3, 3), WorldGen.genRand.Next(100, 140), WorldGen.genRand.Next(40, 60), (ushort)ModContent.TileType<NullifiedBrick>(), false, true).Start();
				}
				if (tile.active() && tile.type == TileID.GreenDungeonBrick)
				{	
						new NullBiomeGen(new Vector2(x, y), Vector2.Zero, new Point16(-12, 12), new Point16(-3, 3), WorldGen.genRand.Next(100, 140), WorldGen.genRand.Next(40, 60), (ushort)ModContent.TileType<NullifiedBrick>(), false, true).Start();
				}

				if (tile.active() && tile.type == TileID.BlueDungeonBrick)
				{
						new NullBiomeGen(new Vector2(x, y), Vector2.Zero, new Point16(-12, 12), new Point16(-3, 3), WorldGen.genRand.Next(100, 140), WorldGen.genRand.Next(40, 60), (ushort)ModContent.TileType<NullifiedBrick>(), false, true).Start();
				}


				// Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
				// Tile tile = Framing.GetTileSafely(x, y);
				// if (tile.active() && tile.type == TileID.SnowBlock)
				// {
				// 	WorldGen.TileRunner(.....);
				// }
			}
		}
		
		private void NullChestGeneration(GenerationProgress progress)
        {
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-03); k++)
			{
				progress.Message = "Putting loot in the Null";
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.type == ModContent.TileType<NullifiedBrick>() || tile.type == TileID.PinkDungeonBrick || tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick)
				{
					for (int upDog = 0; upDog == 20; upDog++)
                    {
						tile = Framing.GetTileSafely(x, y);
						if (!tile.active())
                        {
                            break;
                        }
                        else
                        {
							y += 1;
                        }
                    }

					Mod mod = ofDarkandBelow.inst;
					int PlacementSuccess = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<FreakChestTile>(), false);

					// Main Loot
					int[] NullChestLootMain =
					{
						ModContent.ItemType<NeiroplasmicCore>(),
						ModContent.ItemType<ZeroSpirit>(),
						ModContent.ItemType<Tanto>(),
						ItemID.WaterBolt
					};
					// Uncommon Loot
					int[] NullChestLootUncommon =
					{
						ItemID.Dynamite,
						ItemID.GoldCoin,
						ItemID.GoldBar,
						ItemID.PlatinumBar,
						ItemID.GoldenKey,
						ModContent.ItemType<Neiroplasm>()
					};
					// Common Loot
					int[] NullChestLootCommon =
					{
						ItemID.Torch,
						ItemID.SilverCoin,
						ItemID.Glowstick,
						ModContent.ItemType<PhantomFemurs>(),
						ItemID.JestersArrow,
						ItemID.Bone,
						ItemID.Bomb,
						ItemID.TungstenBar,
						ItemID.SilverBar
					};
					// Potions
					int[] NullChestPotions =
					{
						ItemID.SpelunkerPotion,
						ItemID.FeatherfallPotion,
						ItemID.NightOwlPotion,
						ItemID.WaterWalkingPotion,
						ItemID.ArcheryPotion,
						ItemID.GravitationPotion,
						ItemID.ThornsPotion,
						ItemID.InvisibilityPotion,
						ItemID.HunterPotion,
						ItemID.TrapsightPotion,
						ItemID.TeleportationPotion,
						ItemID.RecallPotion,
						ItemID.SpelunkerPotion,
						ItemID.HealingPotion
					};
					
					// Chest Loot - Intentional Clusterfuck Below

					if (PlacementSuccess >= 0)
					{
						Chest chest = Main.chest[PlacementSuccess];

						// Main Loot
						chest.item[0].SetDefaults(Main.rand.Next(NullChestLootMain));


						// Common Loot
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								if (Main.rand.Next(4) == 2)
								{
									chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestLootCommon));
									if (chest.item[inventoryIndex].type == ItemID.Bomb || chest.item[inventoryIndex].type == ItemID.SilverBar || chest.item[inventoryIndex].type == ItemID.TungstenBar)
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
										break;
									}
									else
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
										break;
									}
								}
								break;
							}
						}

						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								if (Main.rand.Next(3) == 2)
								{
									chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestLootCommon));
									if (chest.item[inventoryIndex].type == ItemID.Bomb || chest.item[inventoryIndex].type == ItemID.SilverBar || chest.item[inventoryIndex].type == ItemID.TungstenBar)
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
										break;
									}
									else
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
										break;
									}
								}
								break;
							}
						}

						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestLootCommon));
								if (chest.item[inventoryIndex].type == ItemID.Bomb)
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
									break;
								}
								else
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
									break;
								}
							}
						}

						// Potions
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestPotions));
								if (chest.item[inventoryIndex].type == ItemID.HealingPotion)
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
									break;
								}
								else
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
									break;
								}
							}
						}

						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestPotions));
								if (chest.item[inventoryIndex].type == ItemID.HealingPotion)
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
									break;
								}
								else
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
									break;
								}
							}
						}

						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								if (Main.rand.Next(4) == 2)
								{
									chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestPotions));
									if (chest.item[inventoryIndex].type == ItemID.HealingPotion)
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
										break;
									}
									else
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
										break;
									}
								}
								break;
							}
						}
						
						// Uncommon Loot
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestLootUncommon));
								if (chest.item[inventoryIndex].type == ItemID.PlatinumBar || chest.item[inventoryIndex].type == ItemID.GoldBar || chest.item[inventoryIndex].type == ModContent.ItemType<Neiroplasm>())
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 11);
									break;
								}
								else if (chest.item[inventoryIndex].type == ItemID.GoldenKey)
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
									break;
								}
								else
								{
									chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 5);
									break;
								}
							}
						}

						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								if (Main.rand.Next(4) == 2)
								{
									chest.item[inventoryIndex].SetDefaults(Main.rand.Next(NullChestLootUncommon));
									if (chest.item[inventoryIndex].type == ItemID.PlatinumBar || chest.item[inventoryIndex].type == ItemID.GoldBar || chest.item[inventoryIndex].type == ModContent.ItemType<Neiroplasm>())
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 11);
										break;
									}
									else if (chest.item[inventoryIndex].type == ItemID.GoldenKey)
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
										break;
									}
									else
									{
										chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 5);
										break;
									}
								}
								break;
							}
						}

					}
				}
			}
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