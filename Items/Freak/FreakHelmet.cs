using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Freak
{
    [AutoloadEquip(EquipType.Head)]
    public class FreakHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freak Head");
            Tooltip.SetDefault("2% increased ranged damage"
                + "\n4% increased ranged critical strike chance"
                + "\n'Your head feels a tad malformed.'");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 29;
            item.value = 10000;
            item.rare = 2;
            item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("FreakBody") && legs.type == mod.ItemType("FreakLegs");
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 7;
            player.rangedDamage += 0.02f;
        }
        private int critTimer;
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Tap your Armor Ability Key to activate."
                + "\nWhen activated, you will gain the 'Freaky Critical' buff."
                + "\nThis buff grants increased ranged damage and crit chance."
                + "\nOne minute cooldown.";
            player.GetModPlayer<SModPlayer>().freakyCritActive = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(mod.ItemType("FreakMaterial"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 5);
            recipe2.AddIngredient(ItemID.TissueSample, 5);
            recipe2.AddIngredient(ItemID.Bone, 20);
            recipe2.AddIngredient(mod.ItemType("FreakMaterial"), 20);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}