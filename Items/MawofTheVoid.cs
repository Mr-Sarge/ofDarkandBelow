using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items
{
	public class MawofTheVoid : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Maw of The Void");
			Tooltip.SetDefault("'Consume Thy Enemy'"
			+ "\nAll Attacks inflict Cosmic Flame"
			+ "\n15% Increase to All Damage");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 9;
			item.expert = true;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeDamage += .15f;
			player.thrownDamage += .15f;
			player.rangedDamage += .15f;
			player.magicDamage += .15f;
			player.minionDamage += .15f;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().cosmicInfliction = true;
	}
}}