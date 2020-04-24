using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class OdyesseusChestArmor : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Odysseus' Armor");
			Tooltip.SetDefault("Nothing may stop you, whether fire or wind."
            + "\nImmune to On Fire, Cursed Inferno, Ichor, Chilled, and Mighty Wind!");
        }

		public override void SetDefaults() {
			item.width = 30;
			item.height = 18;
			item.value = 100000;
			item.rare = 5;
			item.defense = 16;
        }
        public override void UpdateEquip(Player player)
        {
            player.buffImmune[24] = true;
            player.buffImmune[39] = true;
            player.buffImmune[46] = true;
            player.buffImmune[69] = true;
            player.buffImmune[194] = true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("OdyesseusBar"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}