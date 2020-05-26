using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	[AutoloadEquip(EquipType.Body)]
	public class DracarniumChestplate : ModItem
	{
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Dracarnium Chestplate");
            Tooltip.SetDefault("'A chestpiece of pure Dracarnium...'"
                + "\n+5 Melee Crit Chance"
                + "\nImmunity to Dracarnium Flames.");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
            item.value = Item.sellPrice(0, 2, 5, 0);
            item.rare = 4;
			item.defense = 8;
		}
        public override void UpdateEquip(Player player)
        {
            player.buffImmune[mod.BuffType("DracarniumFlames")] = true;
            player.meleeCrit += 5;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 22);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}