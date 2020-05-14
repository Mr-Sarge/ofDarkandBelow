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
			Tooltip.SetDefault("'A battered remain of a once great helmet.'"
                + "\n4% Increased Melee Speed."
                +"\n+15 Max Mana.");
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
			player.setBonus = "The power of the Sunken King flows through you... Or at least what's left of it."
                + "\nUpon striking an enemy, grant the Sovereign's Power buff."
                + "\nThis buff grants +15 Melee Crit Chance, +25 Magic Crit,"
                + "\n+20% Melee Damage, +25% Magic Damage, Increased Melee Speed and +8 defense."
                + "\nThis buff has a cooldown of 30 seconds after being applied."
                + "\nFall Damage Immunity and More Jump Speed.";
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().fallenRoyaltySetBonus = true;
            player.jumpSpeedBoost += 1.7f;
            player.noFallDmg = true;
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