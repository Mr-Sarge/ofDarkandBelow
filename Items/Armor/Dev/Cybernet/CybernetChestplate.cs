using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor.Dev.Cybernet
{
    [AutoloadEquip(EquipType.Body)]
    public class CybernetChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cybernet Protoplate");
            Tooltip.SetDefault("10% increased minion damage"
            + "\nImmunity to Electrified."
            + "\nIncreases your maximum minions by 2"
            + "\n'Nearly exploding with energy, it is a wonder how this armor is stable.'"
            + "\nDev Armor: Fishcookie");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 18;
            item.value = Item.sellPrice(gold: 5);
            item.rare = 7;
            item.defense = 13;
        }
        public override void UpdateEquip(Player player)
        {
            player.buffImmune[144] = true;
            player.minionDamage += 0.10f;
            player.maxMinions++;
            player.maxMinions++;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BatteredCybernetics"), 2);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}