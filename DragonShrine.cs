using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ofDarkandBelow.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using Terraria.ModLoader.IO;
using System.Linq;
using ofDarkandBelow.WorldGeneration;
using ofDarkandBelow;

namespace ofDarkandBelow
{
    public class DragonShrine : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex3 = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            tasks.Insert(ShiniesIndex3 + 0, new PassLegacy("Getting ready for Shrine", delegate (GenerationProgress progress)
            {
                PreShrine();
            }));
            tasks.Insert(ShiniesIndex3 + 1, new PassLegacy("Makin' Dragon Shrine", delegate (GenerationProgress progress)
            {
                Shrine();
            }));
        }
        public static int GetWorldSize()
        {
            if (Main.maxTilesX <= 4200) { return 1; }
            else if (Main.maxTilesX <= 6400) { return 2; }
            else if (Main.maxTilesX <= 8400) { return 3; }
            return 1;
        }
        public void Shrine()
        {
            Point origin = new Point((int)(Main.maxTilesX * 0.60f), (int)(Main.maxTilesY * 0.034f));
            DragonShrineBiome biome = new DragonShrineBiome();
            DragonShrineClear delete = new DragonShrineClear();
            delete.Place(origin, WorldGen.structures);
            biome.Place(origin, WorldGen.structures);
        }
        public void PreShrine()
        {
            Point origin = new Point((int)(Main.maxTilesX * 0.60f), (int)(Main.maxTilesY * 0.05f));
            origin.Y = BaseWorldGen.GetFirstTileFloor(origin.X, origin.Y, true);
            WorldUtils.Gen(origin, new Shapes.Rectangle(80, 50), Actions.Chain(new GenAction[] //remove all fluids in rectangle
            {
                new Actions.SetLiquid(0, 0)
            }));
        }
    }
}