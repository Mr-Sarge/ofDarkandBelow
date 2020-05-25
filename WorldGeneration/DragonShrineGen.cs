using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using ofDarkandBelow.Tiles.DragonShrine;

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

            TexGen gen = BaseWorldGenTex.GetTexGenerator(mod.GetTexture("WorldGeneration/DragShrineClear"), colorToTile);
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
            return true;
        }
    }
}
