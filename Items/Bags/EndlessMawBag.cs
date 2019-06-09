using Terraria;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;

namespace ofDarkandBelow.Items.Bags
{
	public class EndlessMawBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag (Endless Maw)");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("EndlessMawHead");
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
			if (Main.rand.NextBool(7)) {
				player.QuickSpawnItem(mod.ItemType("EndlessMawMask"));
			}
			player.QuickSpawnItem(mod.ItemType("MawRak"));
			player.QuickSpawnItem(mod.ItemType("Celestra"));
			player.QuickSpawnItem(mod.ItemType("CosmicClusterFragment"), 50);
			player.QuickSpawnItem(mod.ItemType("HeartofTheVoid"));
			player.QuickSpawnItem(mod.ItemType("EyeofTheMaw"));
		}
	}
}