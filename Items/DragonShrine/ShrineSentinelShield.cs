using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items.DragonShrine
{
    [AutoloadEquip(EquipType.Shield)]
    public class ShrineSentinelShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shrine Sentinel Shield");
			Tooltip.SetDefault("'Tank mighty blows like a dragon once could.'"
                + "\n+6 Defense"
                + "\nYou gain defense and damage reduction scaled off of your max life."
                + "\nKnockBack Immunity."
                + "\nUpon reaching 40% Life you gain 12 more Defense and 7% Damage Reduction.");
        }

		public override void SetDefaults() {
			item.width = 22;
			item.height = 28;
            item.value = Item.sellPrice(gold: 6);
            item.rare = 3;
			item.expert = false;
			item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statDefense += 6;
            player.noKnockback = true;
            int dragscalereduction = player.statLifeMax / 600;
            player.endurance += dragscalereduction;
            int dragscaledefense = player.statLifeMax / 30;
            player.statDefense += dragscaledefense;
            if (player.statLife <= player.statLifeMax * 0.40f)
            {
                player.statDefense += 12;
                player.endurance += 0.07f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DragonScale"), 1);
            recipe.AddIngredient(mod.ItemType("ShrineGuardShield"), 1);
            recipe.AddIngredient(ItemID.CobaltShield, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}