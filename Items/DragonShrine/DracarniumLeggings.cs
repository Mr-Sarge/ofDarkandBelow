using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Items;

namespace ofDarkandBelow.Items.DragonShrine
{
	[AutoloadEquip(EquipType.Legs)]
	public class DracarniumLeggings : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Dracarnium Leggings");
			Tooltip.SetDefault("'Power flows into your leg muscles...'"
                + "\n+6% Movement Speed and Greatly Increased Jump Speed.");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
            item.value = Item.sellPrice(0, 2, 5, 0);
            item.rare = 4;
			item.defense = 6;
		}
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.06f;
            player.jumpSpeedBoost += 3.1f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}