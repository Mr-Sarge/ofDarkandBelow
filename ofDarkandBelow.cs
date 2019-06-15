using ofDarkandBelow.NPCs;
using ofDarkandBelow.NPCs.SunkenKing;
using ofDarkandBelow.NPCs.Null;
using ofDarkandBelow.NPCs.EndlessMaw;
using ofDarkandBelow.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace ofDarkandBelow
{
    class ofDarkandBelow : Mod
    {
        public static ofDarkandBelow instance = null;

        public ofDarkandBelow()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }
        public override void Load()
        {
            instance = this;

            ModTranslation text = CreateTranslation("SkeletronBronzeMessage");
            text.SetDefault("The enemies in the underground hold Bronze!");
            AddTranslation(text);
        }
        public override void Unload()
        {
            instance = null;
        }
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "The Sunken King", 4.1451f, (Func<bool>)(() => MyWorld.downedSunkenKing), "Use a [i:" + ItemType("SunkenScroll") + "] in the Glowing Mushroom Biome, and face off against the King!");
                bossChecklist.Call("AddBossWithInfo", "The Amalgamation", 5.1451f, (Func<bool>)(() => MyWorld.downedAmalgamation), "Spawns randomly in the Dungeon... Prepare for Horror.");
                bossChecklist.Call("AddBossWithInfo", "The Primordial Maw", 5.7f, (Func<bool>)(() => MyWorld.downedAmalgamation), "Use a [i:" + ItemType("PrimordialFragment") + "] anywhere. Fear the Maw.");
            }
        }
    }
}
