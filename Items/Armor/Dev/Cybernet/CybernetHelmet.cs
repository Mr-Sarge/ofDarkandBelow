using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ofDarkandBelow.Projectiles;

namespace ofDarkandBelow.Items.Armor.Dev.Cybernet
{
    [AutoloadEquip(EquipType.Head)]
    public class CybernetHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cybernet Protovisor");
            Tooltip.SetDefault("10% increased minion damage"
            + "\nIncreases maximum mana by 45"
            + "\nIncreases your maximum minions by 1"
            + "\n'It's like they are looking at the sky, just put 'em on the ground.'"
            + "\nDev Helmet: Fishcookie");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(gold: 7);
            item.rare = 7;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 45;
            player.maxMinions++;
            player.minionDamage += 0.10f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("CybernetChestplate") && legs.type == mod.ItemType("CybernetLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Tap your Armor Ability Key to activate."
                + "\nWhen activated, a power orb will come to assist you."
                + "\nHowever, you will overload and begin to take rapid damage in return."
                + "\nOne minute cooldown.";
            player.GetModPlayer<SModPlayer>().powerOrbBuff = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BatteredCybernetics"), 4);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}