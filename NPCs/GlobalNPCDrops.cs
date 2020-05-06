using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.NPCs
{
    public class GlobalNPCDrops : GlobalNPC
    {
	public override void NPCLoot(NPC npc)
	{
        if (npc.type == 439)
            {
                if (Main.rand.Next(150) < 2)
                    Item.NewItem(npc.getRect(), mod.ItemType("CatastrophicRedemption"), 1);
            }
        if(NPC.downedBoss3 && npc.type == NPCID.CaveBat)
		{
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"));
                }
		}
            if (NPC.downedBoss3 && npc.type == NPCID.GiantWormHead)
            {
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"));
                }
            }
            if (NPC.downedBoss3 && npc.type == NPCID.Crawdad)
            {
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"), 3);
                }
            }
            if (NPC.downedBoss3 && npc.type == NPCID.Salamander)
            {
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"), 3);
                }
            }
            if (NPC.downedBoss3 && npc.type == NPCID.GiantShelly)
            {
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"), 3);
                }
            }
            if (NPC.downedBoss3 && npc.type == NPCID.RedSlime)
		{
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"));
                }
            }
		      	if(NPC.downedBoss3 && npc.type == NPCID.Skeleton)
		{
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"));
                }
            }
		      	if(NPC.downedBoss3 && npc.type == NPCID.GreekSkeleton)
		{
                if (Main.rand.NextFloat() < .5f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"), 3);
                }
            }
		      	if(NPC.downedBoss3 && npc.type == NPCID.UndeadMiner)
		{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"), 7);
		}
	}
}}