using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor.Dev
{
    [AutoloadEquip(EquipType.Body)]
    public class BehemothChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Behemoth Plate Chestplate");
            Tooltip.SetDefault("Grants Knockback Immunity and a Huge Array of Debuff Immunity."
            + "\nIncreases Max Life by 75."
            + "\nDev Armor: Jsoull");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 18;
            item.value = Item.sellPrice(gold: 25);
            item.rare = 11;
            item.defense = 40;
        }
        public override void UpdateEquip(Player player)
        {
            player.noKnockback = true;
            player.statLifeMax2 += 75;
            player.buffImmune[20] = true;
            player.buffImmune[24] = true;
            player.buffImmune[30] = true;
            player.buffImmune[31] = true;
            player.buffImmune[32] = true;
            player.buffImmune[33] = true;
            player.buffImmune[35] = true;
            player.buffImmune[36] = true;
            player.buffImmune[39] = true;
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
            player.buffImmune[69] = true;
            player.buffImmune[61] = true;
            player.buffImmune[70] = true;
            player.buffImmune[144] = true;
            player.buffImmune[145] = true;
            player.buffImmune[194] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BeserkerCrystal"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}