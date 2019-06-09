using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DraconicHateHelmet : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Draconic Horned Helm");
			Tooltip.SetDefault("You are the DragonSlayer.");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
			item.value = 100000;
			item.rare = 4;
			item.defense = 26;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("DraconicHateArmor") && legs.type == mod.ItemType("DraconicHateLeggings");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "15% increased Melee Damage and 15% increased movement speed.";
			player.meleeDamage += 0.15f;
			player.moveSpeed += 0.15f;
		}
	}
}