using Terraria;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;

namespace ofDarkandBelow.Items.Bags
{
	public class SunkenKingBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag (Sunken King)");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("SunkenKingPhase2");
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.QuickSpawnItem(mod.ItemType("SunkenCrown"));
			player.TryGettingDevArmor();
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(mod.ItemType("FirstTerraBlade"));
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(mod.ItemType("KinglyKnife"));
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(mod.ItemType("KingsHarvest"));
			}
		}
	}
}