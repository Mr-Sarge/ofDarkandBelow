using Terraria;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs.Null;

namespace ofDarkandBelow.Items.Bags
{
	public class AmalgaBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag (Amalgamation)");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 32;
			item.height = 34;
			item.rare = 9;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
            player.QuickSpawnItem(mod.ItemType("Neiroplasm"), 40);
            player.QuickSpawnItem(mod.ItemType("GhostSlayersSkull"), 1);
            player.QuickSpawnItem(mod.ItemType("ZeroSpirit"), 3 + Main.rand.Next(6));
			if (Main.rand.NextBool(2)) {
          	   player.QuickSpawnItem(mod.ItemType("Amalgamate"));
			}
			if (Main.rand.NextBool(2)) {
         	   player.QuickSpawnItem(mod.ItemType("GhostSlayer"));
			}
			if (Main.rand.NextBool(6)) {
         	   player.QuickSpawnItem(mod.ItemType("NullEaterEgg"));
			}
            if (Main.rand.NextBool(130))
            {
                player.QuickSpawnItem(mod.ItemType("ReganoxClaymore"));
            }
        }
        public override int BossBagNPC => mod.NPCType("AmalgamationAngry");
    }
}