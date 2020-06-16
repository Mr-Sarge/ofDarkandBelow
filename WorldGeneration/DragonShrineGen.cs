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

            // Tables
            WorldGen.PlaceObject(origin.X + 202, origin.Y + 73, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 202, origin.Y + 73, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 240, origin.Y + 74, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 240, origin.Y + 74, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 252, origin.Y + 74, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 252, origin.Y + 74, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 237, origin.Y + 18, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 237, origin.Y + 18, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 132, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 132, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 156, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 156, origin.Y + 170, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 36, origin.Y + 162, (ushort)ModContent.TileType<DragonTableTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 36, origin.Y + 162, (ushort)ModContent.TileType<DragonTableTile>(), 0, 0, -1, -1);

            // Candles
            WorldGen.PlaceObject(origin.X + 202, origin.Y + 71, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 202, origin.Y + 71, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 252, origin.Y + 72, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 252, origin.Y + 72, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 156, origin.Y + 168, (ushort)ModContent.TileType<DragonCandleTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 156, origin.Y + 168, (ushort)ModContent.TileType<DragonCandleTile>(), 0, 0, -1, -1);

            // Lamps
            WorldGen.PlaceObject(origin.X + 112, origin.Y + 49, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 112, origin.Y + 49, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 119, origin.Y + 50, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 119, origin.Y + 50, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 100, origin.Y + 51, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 100, origin.Y + 51, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 136, origin.Y + 52, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 136, origin.Y + 52, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 147, origin.Y + 55, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 147, origin.Y + 55, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 86, origin.Y + 54, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 86, origin.Y + 54, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 157, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 157, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 241, origin.Y + 114, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 241, origin.Y + 114, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 229, origin.Y + 17, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 229, origin.Y + 17, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 72, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 72, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 100, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 100, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 270, origin.Y + 168, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 270, origin.Y + 168, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 204, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 204, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 207, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 207, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 210, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 210, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 219, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 219, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 222, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 222, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 225, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 225, origin.Y + 108, (ushort)ModContent.TileType<DragonLampTile>(), 0, 0, -1, -1);

            // Lanterns
            WorldGen.PlaceObject(origin.X + 118, origin.Y + 86, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 118, origin.Y + 86, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 206, origin.Y + 92, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 206, origin.Y + 92, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 35, origin.Y + 155, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 35, origin.Y + 155, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 125, origin.Y + 161, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 125, origin.Y + 161, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 247, origin.Y + 12, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 247, origin.Y + 12, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 206, origin.Y + 92, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 206, origin.Y + 92, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 88, origin.Y + 100, (ushort)ModContent.TileType<DragonLanternTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 88, origin.Y + 100, (ushort)ModContent.TileType<DragonLanternTile>(), 0, 0, -1, -1);

            // clocks
            WorldGen.PlaceObject(origin.X + 272, origin.Y + 69, (ushort)ModContent.TileType<DragonGrandClockTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 272, origin.Y + 69, (ushort)ModContent.TileType<DragonGrandClockTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 106, origin.Y + 105, (ushort)ModContent.TileType<DragonGrandClockTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 106, origin.Y + 105, (ushort)ModContent.TileType<DragonGrandClockTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 243, origin.Y + 164, (ushort)ModContent.TileType<DragonGrandClockTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 243, origin.Y + 164, (ushort)ModContent.TileType<DragonGrandClockTile>(), 0, 0, -1, -1);

            // Pillars

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

            //chests top
            DragonChest(origin.X + 52, origin.Y + 70);
            DragonChest(origin.X + 97, origin.Y + 52);
            DragonChest(origin.X + 180, origin.Y + 71);
            DragonChest(origin.X + 210, origin.Y + 73);
            DragonChest(origin.X + 246, origin.Y + 74);
            DragonChest(origin.X + 303, origin.Y + 75);
            DragonChest(origin.X + 313, origin.Y + 75);

            DragonChest(origin.X + 247, origin.Y + 18);

            //chests middle
            DragonChest(origin.X + 52, origin.Y + 70);
            DragonChest(origin.X + 117, origin.Y + 108);
            DragonChest(origin.X + 174, origin.Y + 107);
            DragonChest(origin.X + 184, origin.Y + 107);
            DragonChest(origin.X + 174, origin.Y + 107);

            //chests bottom
            DragonChest(origin.X + 44, origin.Y + 162);
            DragonChest(origin.X + 52, origin.Y + 164);
            DragonChest(origin.X + 142, origin.Y + 170);
            DragonChest(origin.X + 151, origin.Y + 170);
            DragonChest(origin.X + 141, origin.Y + 170);
            DragonChest(origin.X + 201, origin.Y + 191);
            DragonChest(origin.X + 251, origin.Y + 168);

            return true;
        }
        public void DragonChest(int x, int y)
        {
            Mod mod = ofDarkandBelow.inst;
            int PlacementSuccess = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<DragonChestTile>(), false);

            int[] DragonChestLoot = new int[]
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianIrePotion>()
            };
            int[] DragonChestLoot2 = new int[]
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianSpikeFish>()
            };
            int[] DragonChestLoot3 = new int[]
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianSpikeFish>()
            };
            int[] DragonChestLoot4 = new int[]
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianSpikeFish>()
            };
            int[] DragonChestLoot5 = new int[]
            {
                ModContent.ItemType<DracarniumIngot>(),
                ModContent.ItemType<DracianIrePotion>()
            };
            if (PlacementSuccess >= 0)
            {
                Chest chest = Main.chest[PlacementSuccess];

                Item item0 = chest.item[0];
                UnifiedRandom genRand0 = WorldGen.genRand;
                int[] array0 = new int[]
                {
                    ModContent.ItemType<AncientAle>(), ModContent.ItemType<DragonScale>(), ModContent.ItemType<ShrineGuardShield>(), ModContent.ItemType<ArchaicMusket>(), ModContent.ItemType<AncientGreatSword>()
                };
                item0.SetDefaults(Utils.Next(genRand0, array0), false);

                // Dracarnium Bars
                chest.item[1].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot));
                chest.item[1].stack = WorldGen.genRand.Next(5, 10);

                chest.item[1].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot2));
                chest.item[1].stack = WorldGen.genRand.Next(5, 10);

                chest.item[1].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot3));
                chest.item[1].stack = WorldGen.genRand.Next(5, 10);

                chest.item[1].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot4));
                chest.item[1].stack = WorldGen.genRand.Next(5, 10);

                chest.item[1].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot5));
                chest.item[1].stack = WorldGen.genRand.Next(5, 10);

                //Fish and Ire Potions
                chest.item[2].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot));
                chest.item[2].stack = WorldGen.genRand.Next(1, 3);

                chest.item[2].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot2));
                chest.item[2].stack = WorldGen.genRand.Next(2, 6);

                chest.item[2].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot3));
                chest.item[2].stack = WorldGen.genRand.Next(2, 6);

                chest.item[2].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot4));
                chest.item[2].stack = WorldGen.genRand.Next(2, 6);

                chest.item[2].SetDefaults(Utils.Next(WorldGen.genRand, DragonChestLoot5));
                chest.item[2].stack = WorldGen.genRand.Next(1, 3);
            }
        }
    }
}

