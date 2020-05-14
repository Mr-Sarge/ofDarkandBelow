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
			item.width = 32;
			item.height = 32;
			item.rare = 9;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.QuickSpawnItem(mod.ItemType("SunkenCrown"));
            player.QuickSpawnItem(mod.ItemType("FallenFragment"), 35);
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
            if (Main.rand.NextBool(2))
            {
                player.QuickSpawnItem(mod.ItemType("FallenRoyaltyWings"));
            }
            if (Main.rand.NextBool(6)) {
				player.QuickSpawnItem(mod.ItemType("SunkenKingTrophy"));
			}
			if (Main.rand.NextBool(6)) {
				player.QuickSpawnItem(mod.ItemType("SunkenKingMask"));
			}
		}
        public override int BossBagNPC => mod.NPCType("SunkenKingPhase2");
    }
}