using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	[AutoloadEquip(EquipType.Head)]
	public class DracarniumHelm : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Dracarnium Horned Helm");
			Tooltip.SetDefault("'Foes shudder to imagine what lay behind this helm...'"
                + "\n5% Increased Melee Speed and 7% Increased Movement Speed");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 29;
            item.value = Item.sellPrice(0, 2, 25, 0);
            item.rare = 4;
			item.defense = 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("DracarniumChestplate") && legs.type == mod.ItemType("DracarniumLeggings");
		}
        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.05f;
            player.moveSpeed += 0.07f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = "15% increased movement speed."
                + "\nUpon reaching 25% Health, you burst into flames with great stat boosts"
                + "\nand cause all attacks by you to inflict Dracarnium Flames. However you lose 10 Defense.";
			player.moveSpeed += 0.15f;
            if (player.statLife <= player.statLifeMax * 0.25f)
            {
                player.AddBuff(mod.BuffType("DracarniumInfusion"), 60);
                SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
                player.GetModPlayer<SModPlayer>().dracarniumInfusion = true;
            }
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}