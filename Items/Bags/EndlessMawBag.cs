using Terraria;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;

namespace ofDarkandBelow.Items.Bags
{
	public class EndlessMawBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag (Primordial Maw)");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
            player.QuickSpawnItem(mod.ItemType("CosmicClusterFragment"), 45);
			if (Main.rand.NextBool(3)) {
          	   player.QuickSpawnItem(mod.ItemType("Celestra"));
			}
			if (Main.rand.NextBool(3)) {
         	   player.QuickSpawnItem(mod.ItemType("EyeofTheMaw"));
			}
			if (Main.rand.NextBool(3)) {
           	   player.QuickSpawnItem(mod.ItemType("MawRak"));
			}
			if (Main.rand.NextBool(6)) {
         	   player.QuickSpawnItem(mod.ItemType("EndlessMawMask"));
			}
			if (Main.rand.NextBool(6)) {
         	   player.QuickSpawnItem(mod.ItemType("EndlessMawTrophy"));
			}
			if (Main.rand.NextBool(160)) {
         	   player.QuickSpawnItem(mod.ItemType("DeceivingTruth"));
			}
		}
        public override int BossBagNPC => mod.NPCType("EndlessMawHead");
    }
}