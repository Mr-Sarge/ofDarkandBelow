using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Null
{
	public class NullEaterEgg : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Null Eater's Egg");
			Tooltip.SetDefault("Summons a lil' baby Null Eater");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("BabyNullEaterPet");
			item.buffType = mod.BuffType("BabyNullEaterPetBuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}