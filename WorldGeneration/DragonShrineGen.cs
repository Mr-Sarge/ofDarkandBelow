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

            // Pillars

            WorldGen.PlaceObject(origin.X + 214, origin.Y + 70, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 214, origin.Y + 70, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 162, origin.Y + 167, (ushort)ModContent.TileType<DragonPillarATile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 162, origin.Y + 167, (ushort)ModContent.TileType<DragonPillarATile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 125, origin.Y + 171, (ushort)ModContent.TileType<DragonPillarABrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 125, origin.Y + 171, (ushort)ModContent.TileType<DragonPillarABrokenTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 132, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarBTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 132, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarBTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 219, origin.Y + 13, (ushort)ModContent.TileType<DragonPillarBTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 219, origin.Y + 13, (ushort)ModContent.TileType<DragonPillarBTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 95, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarBChippedTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 95, origin.Y + 48, (ushort)ModContent.TileType<DragonPillarBChippedTile>(), 0, 0, -1, -1);

            WorldGen.PlaceObject(origin.X + 113, origin.Y + 90, (ushort)ModContent.TileType<DragonPillarCBrokenTile>());
            NetMessage.SendObjectPlacment(-1, origin.X + 113, origin.Y + 90, (ushort)ModContent.TileType<DragonPillarCBrokenTile>(), 0, 0, -1, -1);

            return true;
        }
    }
}

