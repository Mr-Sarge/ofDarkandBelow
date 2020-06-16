using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	[AutoloadEquip(EquipType.Head)]
	public class FallenRoyalMask : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Fallen Royalty's Mask");
			Tooltip.SetDefault("4% increased melee speed"
                +"\nIncreases maximum mana by 15"
                +"\n'A battered remain of a once great helmet.'");
        }

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
            item.value = Item.sellPrice(silver: 80);
            item.rare = 3;
			item.defense = 4;
		}
        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.04f;
            player.statManaMax2 += 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("FallenRoyalChestGuard") && legs.type == mod.ItemType("FallenRoyalGreaves");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Upon striking an enemy, you are granted the Sovereign's Power buff."
                    +"\nThis buff provides a variety of melee, magic and defense bonuses for a short time."
                    +"\nThis buff has a cooldown of 30 seconds.";
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().fallenRoyaltySetBonus = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FallenFragment"), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}