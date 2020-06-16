using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ZeroGhostHood : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Zero Ghost Hood");
            Tooltip.SetDefault("Increases your maximum minions by 1"
                +"\nIncreases maximum mana by 15"
				+"\n'Your mind eye has opened to all of reality.'");

		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 24;
			item.value = 10000;
			item.rare = 2;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 15;
			player.maxMinions++;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("ZeroGhostCloak") && legs.type == mod.ItemType("ZeroGhostRobe");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "25% increased minion and magic damage" 
				+ "\nIncreases your maximum minions by 1" 
				+ "\nIncreases your maximum mana by 25";
			player.statManaMax2 += 25;
			player.maxMinions++;
			player.magicDamage += 0.2f;
			player.minionDamage += 0.2f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 20);
			recipe.AddIngredient(mod.ItemType("ZeroSpirit"), 1);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}