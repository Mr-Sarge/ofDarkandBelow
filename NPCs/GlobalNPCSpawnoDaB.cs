using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ofDarkandBelow.NPCs
{
    public class GlobalNPCSpawnoDaB : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<MyPlayer>().ZoneShrine)
            {
                if (spawnInfo.player.ZoneSkyHeight)
                {
                    pool.Clear();

                    pool.Add(mod.NPCType("DracarneServant"), 0.65f);
                    pool.Add(mod.NPCType("DracarneHatchling"), 0.4f);
                }
            }
        }
    }
}