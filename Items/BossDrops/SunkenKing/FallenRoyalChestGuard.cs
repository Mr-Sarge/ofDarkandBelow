using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	[AutoloadEquip(EquipType.Body)]
	public class FallenRoyalChestGuard : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Fallen Royalty's Chestguard");
			Tooltip.SetDefault("5% increased melee damage"
                + "\n5% increased ranged damage"
                + "\n'Bare scraps of powerless metal barely clinging to existence.'");
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.05f;
            player.magicDamage += 0.05f;
        }
        public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
            item.value = Item.sellPrice(silver: 90);
            item.rare = 3;
			item.defense = 8;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FallenFragment"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}