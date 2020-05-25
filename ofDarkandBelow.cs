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
using ofDarkandBelow;
using static ofDarkandBelow.MyPlayer;
using static ofDarkandBelow.MNet;

namespace ofDarkandBelow
{
    class ofDarkandBelow : Mod
    {
        public static ofDarkandBelow instance = null;
        public static ofDarkandBelow inst = null;
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
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.gameMenu)
                return;
            if (priority > MusicPriority.Environment)
                return;
            Player player = Main.LocalPlayer;
            if (!player.active)
                return;
            if (Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().ZoneShrine == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/OnceWas");

                priority = MusicPriority.Environment;
            }
        }
        public override void Load()
        {
            instance = this;
            inst = this;

            ModTranslation text = CreateTranslation("SkeletronBronzeMessage");
            text.SetDefault("The enemies in the underground hold Bronze!");
            AddTranslation(text);

            Mod yabhb = ModLoader.GetMod("FKBossHealthBar");
            if (yabhb != null)
            {
                yabhb.Call("hbStart");
                yabhb.Call("hbSetTexture",
                    GetTexture("UI/PrimordialBarStart"),
                    GetTexture("UI/PrimordialBarMiddle"),
                    GetTexture("UI/PrimordialBarEnd"),
                    GetTexture("UI/oDaBBarFill"));
                yabhb.Call("hbSetBossHeadCentre", 79, 34);
                yabhb.Call("hbSetFillDecoOffset", 5);
                yabhb.Call("hbSetColours",
                        new Color(0.5f, 0f, 0.5f), // 100%
                        new Color(0.75f, 0f, 0.25f), // 50%
                        new Color(1f, 0f, 0f));// 0%
                yabhb.Call("hbFinishSingle", NPCType("EndlessMawHead"));

                yabhb.Call("hbStart");
                yabhb.Call("hbSetTexture",
                    GetTexture("UI/SunkenBarStart"),
                    GetTexture("UI/SunkenBarMiddle"),
                    GetTexture("UI/SunkenBarEnd"),
                    GetTexture("UI/oDaBBarFill"));
                yabhb.Call("hbSetBossHeadCentre", 3, 34);
                yabhb.Call("hbSetFillDecoOffset", 5);
                yabhb.Call("hbSetColours",
                        new Color(0f, 0.45f, 0.55f), // 100%
                        new Color(0.25f, 0.3f, 0.45f), // 50%
                        new Color(1f, 0f, 0f));// 0%
                yabhb.Call("hbFinishPhases",
                   NPCType("SunkenKing"),
                   NPCType("SunkenKingPhase2"));
            }
        }
        public override void Unload()
        {
            instance = null;
        }
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "The Sunken King", 4.1451f, (Func<bool>)(() => MyWorld.downedSunkenKing), "Use a [i:" + ItemType("SunkenScroll") + "] in the Glowing Mushroom Biome, and face off against the King!");
                bossChecklist.Call("AddBossWithInfo", "The Amalgamation", 5.1451f, (Func<bool>)(() => MyWorld.downedAmalgamation), "Use a [i:" + ItemType("NeiroplasmicCore") + "] at night or spawns randomly in the Dungeon. Prepare for horror.");
                bossChecklist.Call("AddBossWithInfo", "The Primordial Maw", 5.7f, (Func<bool>)(() => MyWorld.downedAmalgamation), "Use a [i:" + ItemType("PrimordialFragment") + "] anywhere. Fear the Maw.");
            }
        }
    }
}
