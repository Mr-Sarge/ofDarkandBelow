using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using ofDarkandBelow.Tiles.DragonShrine;
using ofDarkandBelow.Tiles.DragonShrine.Pillars;
using ofDarkandBelow.Items;
using ofDarkandBelow.Items.Fishing;
using ofDarkandBelow.Items.DragonShrine;
using ofDarkandBelow.Items.Placeable.DragonShrine;
using Terraria.Utilities;

namespace ofDarkandBelow.WorldGeneration
{
    public class DragonShrineClear : MicroBiome
    {
        public override bool Place(Point origin, StructureMap structures)
        {
            Mod mod = ofDarkandBelow.inst;
            Dictionary<Color, int> colorToTile = new Dictionary<Color, int>();
            colorToTile[new Color(150, 150, 150)] = -2; //turn into air
            colorToTile[Color.Black] = -1; //don't touch when genning

            Dictionary<Color, int> colorToWall = new Dictionary<Color, int>();
            colorToWall[new Color(150, 150, 150)] = -2; //turn into air
            colorToWall[Color.Black] = -1; //don't touch when genning

            TexGen gen = BaseWorldGenTex.GetTexGenerator(mod.GetTexture("WorldGeneration/DragShrineClear"), colorToTile, mod.GetTexture("WorldGeneration/DragShrineClearWall"), colorToWall);
            gen.Generate(origin.X, origin.Y, true, true);
            return true;
        }
    }
    public class DragonShrineBiome : MicroBiome
    {
        public override bool Place(Point origin, StructureMap structures)
        {
            Mod mod = ofDarkandBelow.inst;
            Dictionary<Color, int> colorToTile = new Dictionary<Color, int>();
            colorToTile[new Color(139, 174, 55)] = mod.TileType("DragonSoilTile");
            colorToTile[new Color(70, 83, 40)] = mod.TileType("DragonStoneATile");
            colorToTile[new Color(187, 204, 148)] = mod.TileType("AncientCloudTile");

            Dictionary<Color, int> colorToWall = new Dictionary<Color, int>();
            colorToWall[new Color(48, 52, 37)] = mod.WallType("DragonStoneWallTile");
            colorToWall[new Color(150, 150, 150)] = -2; //turn into air
            colorToWall[Color.Black] = -1; //don't touch when genning

            TexGen gen = BaseWorldGenTex.GetTexGenerator(mod.GetTexture("WorldGeneration/DragShrine"), colorToTile, mod.GetTexture("WorldGeneration/DragShrineWall"), colorToWall, mod.GetTexture("WorldGeneration/DragShrineLiquids"));
            gen.Generate(origin.X, origin.Y, true, true);

            // Tables Old
            WorldGen.PlaceObject(origin.X + 237, origin.Y + 18, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 237, origin.Y + 18, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 132, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 132, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 156, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 156, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 36, origin.Y + 162, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 36, origin.Y + 162, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            // Candles

            WorldGen.PlaceObject(origin.X + 252, origin.Y + 72, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 252, origin.Y + 72, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 130, origin.Y + 78, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 130, origin.Y + 78, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 261, origin.Y + 50, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 261, origin.Y + 50, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);



            // Lanterns New
            WorldGen.PlaceObject(origin.X + 218, origin.Y + 67, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 218, origin.Y + 67, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 60, origin.Y + 105, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 60, origin.Y + 105, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 79, origin.Y + 83, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 79, origin.Y + 83, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 87, origin.Y + 26, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 87, origin.Y + 26, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 129, origin.Y + 93, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 129, origin.Y + 93, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 144, origin.Y + 26, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 144, origin.Y + 26, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 163, origin.Y + 120, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 163, origin.Y + 120, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 288, origin.Y + 45, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 288, origin.Y + 45, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);


            // Lamps New
            WorldGen.PlaceObject(origin.X + 101, origin.Y + 93, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 101, origin.Y + 93, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 103, origin.Y + 122, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 103, origin.Y + 122, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);
           
            WorldGen.PlaceObject(origin.X + 112, origin.Y + 49, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 112, origin.Y + 49, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 150, origin.Y + 105, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 150, origin.Y + 105, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 168, origin.Y + 80, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 168, origin.Y + 80, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 271, origin.Y + 83, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 271, origin.Y + 83, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 280, origin.Y + 83, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 280, origin.Y + 83, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 167, origin.Y + 60, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 187, origin.Y + 60, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            // Pillars New

            // Small
            WorldGen.PlaceObject(origin.X + 257, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarABrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 257, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarABrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 66, origin.Y + 92, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 66, origin.Y + 92, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 199, origin.Y + 74, (ushort)ModContent.TileType<DragonPillarAChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 199, origin.Y + 74, (ushort)ModContent.TileType<DragonPillarAChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 195, origin.Y + 107, (ushort)ModContent.TileType<DragonPillarAChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 195, origin.Y + 107, (ushort)ModContent.TileType<DragonPillarAChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 236, origin.Y + 107, (ushort)ModContent.TileType<DragonPillarABrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 236, origin.Y + 107, (ushort)ModContent.TileType<DragonPillarABrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 207, origin.Y + 50, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 207, origin.Y + 50, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 285, origin.Y + 97, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 285, origin.Y + 97, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);


            // Medium
            WorldGen.PlaceObject(origin.X + 76, origin.Y + 90, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 76, origin.Y + 90, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 187, origin.Y + 77, (ushort)ModContent.TileType<DragonPillarBBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 187, origin.Y + 77, (ushort)ModContent.TileType<DragonPillarBBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 202, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 202, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 223, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 223, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 230, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 230, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 234, origin.Y + 51, (ushort)ModContent.TileType<DragonPillarBBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 234, origin.Y + 51, (ushort)ModContent.TileType<DragonPillarBBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 289, origin.Y + 67, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 289, origin.Y + 67, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);


            // Large
            WorldGen.PlaceObject(origin.X + 261, origin.Y + 101, (ushort)ModContent.TileType<DragonPillarCTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 261, origin.Y + 101, (ushort)ModContent.TileType<DragonPillarCTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 210, origin.Y + 103, (ushort)ModContent.TileType<DragonPillarCTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 210, origin.Y + 103, (ushort)ModContent.TileType<DragonPillarCTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 216, origin.Y + 103, (ushort)ModContent.TileType<DragonPillarCBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 216, origin.Y + 103, (ushort)ModContent.TileType<DragonPillarCBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 211, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarCChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 211, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarCChippedTile>(), 0, 0, -1, -1);


            // Tables New
            WorldGen.PlaceObject(origin.X + 163, origin.Y + 126, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 163, origin.Y + 126, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 130, origin.Y + 80, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 130, origin.Y + 80, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 261, origin.Y + 52, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 261, origin.Y + 52, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);


            // Lanterns

            WorldGen.PlaceObject(origin.X + 35, origin.Y + 155, (ushort)ModContent.TileType<DragonLanternTile>()); // Good.
            NetMessage.SendObjectPlacment(-1, origin.X + 35, origin.Y + 155, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 125, origin.Y + 161, (ushort)ModContent.TileType<DragonLanternTile>()); // Good.
            NetMessage.SendObjectPlacment(-1, origin.X + 125, origin.Y + 161, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 247, origin.Y + 12, (ushort)ModContent.TileType<DragonLanternTile>()); // Good
            NetMessage.SendObjectPlacment(-1, origin.X + 247, origin.Y + 12, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            // Clocks

            WorldGen.PlaceObject(origin.X + 106, origin.Y + 105, (ushort)ModContent.TileType<DragonGrandClockTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 106, origin.Y + 105, (ushort)ModContent.TileType<DragonGrandClockTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 243, origin.Y + 164, (ushort)ModContent.TileType<DragonGrandClockTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 243, origin.Y + 164, (ushort)ModContent.TileType<DragonGrandClockTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 175, origin.Y + 56, (ushort)ModContent.TileType<DragonGrandClockTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 175, origin.Y + 56, (ushort)ModContent.TileType<DragonGrandClockTile>(), 0, 0, -1, -1);

            // Pillars - These are just the old ones. New ones will be above these. I wasn't interested in locating the ID of every single one.

            // Small Pillars
            WorldGen.PlaceObject(origin.X + 220, origin.Y + 15, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 220, origin.Y + 15, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 297, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 297, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 142, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 142, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 145, origin.Y + 53, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 145, origin.Y + 53, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 156, origin.Y + 56, (ushort)ModContent.TileType<DragonPillarAChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 156, origin.Y + 56, (ushort)ModContent.TileType<DragonPillarAChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 318, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 318, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 318, origin.Y + 72, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 318, origin.Y + 72, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 279, origin.Y + 72, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 279, origin.Y + 72, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 318, origin.Y + 71, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 318, origin.Y + 71, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 316, origin.Y + 59, (ushort)ModContent.TileType<DragonPillarAChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 316, origin.Y + 59, (ushort)ModContent.TileType<DragonPillarAChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 235, origin.Y + 63, (ushort)ModContent.TileType<DragonPillarABrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 235, origin.Y + 63, (ushort)ModContent.TileType<DragonPillarABrokenTile>(), 0, 0, -1, -1);

            // Medium Pillars
            WorldGen.PlaceObject(origin.X + 125, origin.Y + 168, (ushort)ModContent.TileType<DragonPillarBTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 125, origin.Y + 168, (ushort)ModContent.TileType<DragonPillarBTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 228, origin.Y + 70, (ushort)ModContent.TileType<DragonPillarBTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 228, origin.Y + 70, (ushort)ModContent.TileType<DragonPillarBTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 165, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 165, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 46, origin.Y + 68, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 46, origin.Y + 68, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 154, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 154, origin.Y + 105, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 102, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 102, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 72, origin.Y + 55, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 72, origin.Y + 55, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 264, origin.Y + 71, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 264, origin.Y + 71, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 215, origin.Y + 60, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 215, origin.Y + 60, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 162, origin.Y + 169, (ushort)ModContent.TileType<DragonPillarBBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 162, origin.Y + 169, (ushort)ModContent.TileType<DragonPillarBBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 132, origin.Y + 51, (ushort)ModContent.TileType<DragonPillarBBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 132, origin.Y + 51, (ushort)ModContent.TileType<DragonPillarBBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 282, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarBBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 282, origin.Y + 73, (ushort)ModContent.TileType<DragonPillarBBrokenTile>(), 0, 0, -1, -1);
           
            // Large Pillars
            WorldGen.PlaceObject(origin.X + 185, origin.Y + 185, (ushort)ModContent.TileType<DragonPillarCTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 185, origin.Y + 185, (ushort)ModContent.TileType<DragonPillarCTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 258, origin.Y + 163, (ushort)ModContent.TileType<DragonPillarCTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 258, origin.Y + 163, (ushort)ModContent.TileType<DragonPillarCTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 27, origin.Y + 69, (ushort)ModContent.TileType<DragonPillarCChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 27, origin.Y + 69, (ushort)ModContent.TileType<DragonPillarCChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 274, origin.Y + 164, (ushort)ModContent.TileType<DragonPillarCChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 274, origin.Y + 164, (ushort)ModContent.TileType<DragonPillarCChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 112, origin.Y + 89, (ushort)ModContent.TileType<DragonPillarCChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 112, origin.Y + 89, (ushort)ModContent.TileType<DragonPillarCChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 191, origin.Y + 188, (ushort)ModContent.TileType<DragonPillarCBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 191, origin.Y + 188, (ushort)ModContent.TileType<DragonPillarCBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 117, origin.Y + 91, (ushort)ModContent.TileType<DragonPillarCBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 117, origin.Y + 91, (ushort)ModContent.TileType<DragonPillarCBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 90, origin.Y + 52, (ushort)ModContent.TileType<DragonPillarCBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 90, origin.Y + 52, (ushort)ModContent.TileType<DragonPillarCBrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 214, origin.Y + 106, (ushort)ModContent.TileType<DragonPillarCBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 214, origin.Y + 106, (ushort)ModContent.TileType<DragonPillarCBrokenTile>(), 0, 0, -1, -1);

            // Cups
            WorldGen.PlaceObject(origin.X + 259, origin.Y + 164, (ushort)ModContent.TileType<DragonCupTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 259, origin.Y + 164, (ushort)ModContent.TileType<DragonCupTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 132, origin.Y + 168, (ushort)ModContent.TileType<DragonCupTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 132, origin.Y + 168, (ushort)ModContent.TileType<DragonCupTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 145, origin.Y + 52, (ushort)ModContent.TileType<DragonCupTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 145, origin.Y + 52, (ushort)ModContent.TileType<DragonCupTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 155, origin.Y + 104, (ushort)ModContent.TileType<DragonCupTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 155, origin.Y + 104, (ushort)ModContent.TileType<DragonCupTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 112, origin.Y + 88, (ushort)ModContent.TileType<DragonCupTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 112, origin.Y + 88, (ushort)ModContent.TileType<DragonCupTile>(), 0, 0, -1, -1);

            // Cups - New

            WorldGen.PlaceObject(origin.X + 164, origin.Y + 124, (ushort)ModContent.TileType<DragonCupTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 164, origin.Y + 124, (ushort)ModContent.TileType<DragonCupTile>(), 0, 0, -1, -1);

            //chests top
            DragonChest(origin.X + 52, origin.Y + 70); 
            DragonChest(origin.X + 170, origin.Y + 60);
            DragonChest(origin.X + 272, origin.Y + 52);
            DragonChest(origin.X + 234, origin.Y + 18);
            /*
            DragonChest(origin.X + 97, origin.Y + 52);
            DragonChest(origin.X + 180, origin.Y + 71);
            DragonChest(origin.X + 210, origin.Y + 73);
            DragonChest(origin.X + 246, origin.Y + 74);
            DragonChest(origin.X + 303, origin.Y + 75);
            DragonChest(origin.X + 313, origin.Y + 75);

            DragonChest(origin.X + 247, origin.Y + 18);
            */

            //chests middle
            DragonChest(origin.X + 60, origin.Y + 111);
            DragonChest(origin.X + 97, origin.Y + 94);
            DragonChest(origin.X + 130, origin.Y + 126);
            DragonChest(origin.X + 158, origin.Y + 106);
            DragonChest(origin.X + 164, origin.Y + 80);
            DragonChest(origin.X + 258, origin.Y + 105);
            DragonChest(origin.X + 260, origin.Y + 75);
            DragonChest(origin.X + 286, origin.Y + 70);
            DragonChest(origin.X + 288, origin.Y + 99);
            /*
            DragonChest(origin.X + 117, origin.Y + 108);
            DragonChest(origin.X + 174, origin.Y + 107);
            DragonChest(origin.X + 184, origin.Y + 107);
            DragonChest(origin.X + 174, origin.Y + 107);
            */

            //chests bottom
            DragonChest(origin.X + 44, origin.Y + 162);
            DragonChest(origin.X + 138, origin.Y + 170);
            DragonChest(origin.X + 250, origin.Y + 168);
            /*
            DragonChest(origin.X + 52, origin.Y + 164);
            DragonChest(origin.X + 142, origin.Y + 170);
            DragonChest(origin.X + 151, origin.Y + 170);
            DragonChest(origin.X + 141, origin.Y + 170);
            DragonChest(origin.X + 201, origin.Y + 191);
            DragonChest(origin.X + 251, origin.Y + 168);
            */

            // Hidepiercer Chest
            BiomeDragonChest(origin.X + 275, origin.Y + 81);
            return true;
        }
        public void BiomeDragonChest(int x, int y)
        {
            Mod mod = ofDarkandBelow.inst;
            int PlacementSuccess = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<DragonShrineBiomeChestTile>(), false);
            // Random Rare Dragon Chest Loot
            int[] DragonChestLoot =
       {
                ModContent.ItemType<AncientAle>(),
                ModContent.ItemType<DragonScale>(),
                ModContent.ItemType<ShrineGuardShield>(),
                ModContent.ItemType<ArchaicMusket>(),
                ModContent.ItemType<AncientGreatSword>(),
            };
            // Random Uncommon Dragon Chest Loot
            int[] DragonChestLoot2 =
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianIrePotion>(),
                ModContent.ItemType<DracianSpikeFish>(),
                ModContent.ItemType<DragonShrineCrate>()
            };
            // High-Tier Common Loot
            int[] DragonChestLootTier3 =
            {
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar,
                ModContent.ItemType<HeroesAlloy>()
            };
            // Mid-Tier Common Loot
            int[] DragonChestLootTier2 =
            {
                ItemID.IchorArrow,
                ItemID.GoldCoin,
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            };
            // Low-Tier Common Loot
            int[] DragonChestLootTier1 =
            {
                ItemID.SpelunkerGlowstick,
                ModContent.ItemType<DracarniumSpikes>(),
                ItemID.HolyArrow,
                ItemID.CobaltBar,
                ItemID.PalladiumBar
            };
            // Potions
            int[] DragonChestPotions =
            {
                ItemID.GreaterManaPotion,
                ItemID.GreaterHealingPotion,
                ItemID.LifeforcePotion,
                ItemID.EndurancePotion,
                ItemID.WrathPotion,
                ItemID.RagePotion
            };
            if (PlacementSuccess >= 0)
            {
                Chest chest = Main.chest[PlacementSuccess];

                // Hidepiercer First Slot
                Item item0 = chest.item[0];
                item0.SetDefaults(ModContent.ItemType<Hidepiercer>(), false);

                // Second Chest Slot
                chest.item[1].SetDefaults(Main.rand.Next(DragonChestLoot));

                // Third Chest Slot
                chest.item[2].SetDefaults(Main.rand.Next(DragonChestLoot2));
                if (chest.item[2].type == ModContent.ItemType<DracarniumIngot>())
                {
                    chest.item[2].stack = WorldGen.genRand.Next(10, 22);
                }
                else if (chest.item[2].type == ModContent.ItemType<DracianIrePotion>())
                {
                    chest.item[2].stack = WorldGen.genRand.Next(2, 8);
                }
                else if (chest.item[2].type == ModContent.ItemType<DracianSpikeFish>())
                {
                    chest.item[2].stack = WorldGen.genRand.Next(4, 8);
                }
                else
                {
                    chest.item[2].stack = WorldGen.genRand.Next(2, 5);
                }

                // Potion Generation 100% 1
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestPotions));
                        if (chest.item[inventoryIndex].type == ItemID.GreaterHealingPotion || chest.item[inventoryIndex].type == ItemID.GreaterManaPotion)
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
                            break;
                        }
                        else
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
                            break;
                        }
                        break;
                    }
                }

                // Potion Generation 100% 2
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestPotions));
                        if (chest.item[inventoryIndex].type == ItemID.GreaterHealingPotion || chest.item[inventoryIndex].type == ItemID.GreaterManaPotion)
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
                            break;
                        }
                        else
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
                            break;
                        }
                        break;
                    }
                }

                // Potion Generation 100% 3
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestPotions));
                        if (chest.item[inventoryIndex].type == ItemID.GreaterHealingPotion || chest.item[inventoryIndex].type == ItemID.GreaterManaPotion)
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
                            break;
                        }
                        else
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(1, 3);
                            break;
                        }
                        break;
                    }
                }

                // Tier 1 100%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier1));
                        if (chest.item[inventoryIndex].type == ItemID.SpelunkerGlowstick || chest.item[inventoryIndex].type == ModContent.ItemType<DracarniumSpikes>() || chest.item[inventoryIndex].type == ItemID.HolyArrow)
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 31);
                            break;
                        }
                        else
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(5, 11);
                            break;
                        }
                        break;
                    }
                }

                // Tier 1 50%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(3) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier1));
                            if (chest.item[inventoryIndex].type == ItemID.SpelunkerGlowstick || chest.item[inventoryIndex].type == ModContent.ItemType<DracarniumSpikes>() || chest.item[inventoryIndex].type == ItemID.HolyArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 31);
                                break;
                            }
                            else
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(5, 11);
                                break;

                            }
                        }
                        break;
                    }
                }

                // Tier 1 33%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(4) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier1));
                            if (chest.item[inventoryIndex].type == ItemID.SpelunkerGlowstick || chest.item[inventoryIndex].type == ItemID.PoisonedKnife || chest.item[inventoryIndex].type == ItemID.JestersArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
                                break;
                            }
                            else
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(5, 11);
                                break;
                            }
                        }
                        break;
                    }
                }

                // Tier 2 50%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(3) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier2));
                            if (chest.item[inventoryIndex].type == ItemID.OrichalcumBar || chest.item[inventoryIndex].type == ItemID.MythrilBar)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 11);
                                break;
                            }
                            else if (chest.item[inventoryIndex].type == ItemID.IchorArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
                                break;
                            }
                            else
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 16);
                                break;
                            }
                        }
                        break;
                    }
                }

                // Tier 2 33%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(4) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier2));
                            if (chest.item[inventoryIndex].type == ItemID.OrichalcumBar || chest.item[inventoryIndex].type == ItemID.MythrilBar)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 11);
                                break;
                            }
                            else if (chest.item[inventoryIndex].type == ItemID.IchorArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
                                break;
                            }
                            else
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 16);
                                break;
                            }
                        }
                        break;
                    }
                }

                // Tier 3 33%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(4) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier3));
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 11);
                            break;
                        }
                        break;
                    }
                }
            }
        }
        public void DragonChest(int x, int y)
        {
            Mod mod = ofDarkandBelow.inst;
            int PlacementSuccess = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<DragonChestTile>(), false);
            // Uncommon Loot 1 
            int[] DragonChestLoot =
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianIrePotion>(),
                ModContent.ItemType<DracianSpikeFish>()
            };
            // Uncommon Loot 2
            int[] DragonChestLoot2 =
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianIrePotion>(),
                ModContent.ItemType<DracianSpikeFish>()
            };
            // High-Tier Common Loot
            int[] DragonChestLootTier3 =
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar,
            };
            // Mid-Tier Common Loot
            int[] DragonChestLootTier2 =
            {
                ItemID.HellfireArrow,
                ItemID.Dynamite,
                ItemID.GoldCoin,
                ItemID.GoldBar,
                ItemID.PlatinumBar
            };
            // Low-Tier Common Loot
            int[] DragonChestLootTier1 =
            {
                ItemID.Torch,
                ItemID.PoisonedKnife,
                ItemID.JestersArrow,
                ItemID.Bomb
            };
            int[] DragonChestPotions =
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
                ItemID.HealingPotion
            };

            if (PlacementSuccess >= 0)
            {
                Chest chest = Main.chest[PlacementSuccess];

                // Rare Loot
                Item item0 = chest.item[0];
                UnifiedRandom genRand0 = WorldGen.genRand;
                int[] array0 = new int[]
                {
                    ModContent.ItemType<AncientAle>(), ModContent.ItemType<DragonScale>(), ModContent.ItemType<ShrineGuardShield>(), ModContent.ItemType<ArchaicMusket>(), ModContent.ItemType<AncientGreatSword>()
                };
                item0.SetDefaults(Utils.Next(genRand0, array0), false);

                // Second Chest Slot
                chest.item[1].SetDefaults(Main.rand.Next(DragonChestLoot));
                if (chest.item[1].type == ModContent.ItemType<DracarniumIngot>())
                {
                    chest.item[1].stack = WorldGen.genRand.Next(5, 11);
                }
                else if (chest.item[1].type == ModContent.ItemType<DracianIrePotion>())
                {
                    chest.item[1].stack = WorldGen.genRand.Next(1, 4);
                }
                else if (chest.item[1].type == ModContent.ItemType<DracianSpikeFish>())
                {
                    chest.item[1].stack = WorldGen.genRand.Next(2, 4);
                }

                // Third Chest Slot
                chest.item[2].SetDefaults(Main.rand.Next(DragonChestLoot2));
                if (chest.item[2].type == ModContent.ItemType<DracarniumIngot>())
                {
                    chest.item[2].stack = WorldGen.genRand.Next(5, 11);
                }
                else if (chest.item[2].type == ModContent.ItemType<DracianIrePotion>())
                {
                    chest.item[2].stack = WorldGen.genRand.Next(1, 4);
                }
                else if (chest.item[2].type == ModContent.ItemType<DracianSpikeFish>())
                {
                    chest.item[2].stack = WorldGen.genRand.Next(2, 4);
                }

                // Potion Generation 100%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestPotions));
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
                        break;
                    }
                }

                // Potion Generation 50%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(3) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestPotions));
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

                // Potion Generation 33%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(4) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestPotions));
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

                // Tier 1 100%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier1));
                        if (chest.item[inventoryIndex].type == ItemID.Torch || chest.item[inventoryIndex].type == ItemID.PoisonedKnife || chest.item[inventoryIndex].type == ItemID.JestersArrow)
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 31);
                            break;
                        }
                        else
                        {
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
                            break;
                        }
                        break;
                    }
                }

                // Tier 1 50%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(3) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier1));
                            if (chest.item[inventoryIndex].type == ItemID.Torch || chest.item[inventoryIndex].type == ItemID.PoisonedKnife || chest.item[inventoryIndex].type == ItemID.JestersArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 31);
                                break;
                            }
                            else
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
                                break;

                            }
                        }
                        break;
                    }
                }

                // Tier 1 33%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(4) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier1));
                            if (chest.item[inventoryIndex].type == ItemID.Torch || chest.item[inventoryIndex].type == ItemID.PoisonedKnife || chest.item[inventoryIndex].type == ItemID.JestersArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 31);
                                break;
                            }
                            else
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 6);
                                break;

                            }
                        }
                        break;
                    }
                }

                // Tier 2 50%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(3) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier2));
                            if (chest.item[inventoryIndex].type == ItemID.PlatinumBar || chest.item[inventoryIndex].type == ItemID.GoldBar)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 11);
                                break;
                            }
                            else if (chest.item[inventoryIndex].type == ItemID.HellfireArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
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

                // Tier 2 33%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(4) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier2));
                            if (chest.item[inventoryIndex].type == ItemID.PlatinumBar || chest.item[inventoryIndex].type == ItemID.GoldBar)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 11);
                                break;
                            }
                            else if (chest.item[inventoryIndex].type == ItemID.HellfireArrow)
                            {
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(15, 51);
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

                // Tier 3 33%
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        if (Main.rand.Next(4) == 2)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(DragonChestLootTier3));
                            chest.item[inventoryIndex].stack = WorldGen.genRand.Next(3, 10);
                            break;
                        }
                        break;
                    }
                }
            }
        }
    }
}

