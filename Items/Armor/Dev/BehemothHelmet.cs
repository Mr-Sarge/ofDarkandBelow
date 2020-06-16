using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Armor.Dev
{
    [AutoloadEquip(EquipType.Head)]
    public class BehemothHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Behemoth Plate Helmet");
            Tooltip.SetDefault("Increases maximum health by 50"
            + "\nDev Helmet: Jsoull");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 20;
            item.value = Item.sellPrice(gold: 20);
            item.rare = 11;
            item.defense = 29;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("BehemothChestplate") && legs.type == mod.ItemType("BehemothLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.statLifeMax2 += 50;
            player.setBonus = "You have embraced darkness. All attacks inflict 'Horror Hemorrhage', Powerful Thorns effect, All damage boosted by 25%.";
            player.thorns = 1f;
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().behemothEffect = true;
            player.meleeDamage += 0.25f;
            player.thrownDamage += 0.25f;
            player.rangedDamage += 0.25f;
            player.magicDamage += 0.25f;
            player.minionDamage += 0.25f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BeserkerCrystal"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}