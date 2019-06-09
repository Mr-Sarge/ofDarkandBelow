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
              	if(NPC.downedBoss3 && npc.type == NPCID.CaveBat)
		{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"));
		}
		      	if(NPC.downedBoss3 && npc.type == NPCID.RedSlime)
		{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"));
		}
		      	if(NPC.downedBoss3 && npc.type == NPCID.Skeleton)
		{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"));
		}
		      	if(NPC.downedBoss3 && npc.type == NPCID.GreekSkeleton)
		{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"), 3);
		}
		      	if(NPC.downedBoss3 && npc.type == NPCID.UndeadMiner)
		{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BronzeShards"), 5);
		}
	}
}}