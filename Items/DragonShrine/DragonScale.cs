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
	public class DragonScale : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chipped Dragon Scale");
			Tooltip.SetDefault("Grants damage reduction and defense based upon your max life."
            + "\n'A scale from an ancient dragon... It's still quite warm.'");
        }

		public override void SetDefaults() {
			item.width = 22;
			item.height = 28;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 3;
			item.expert = false;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
            int dragscalereduction = player.statLifeMax / 600;
            player.endurance += dragscalereduction;
            int dragscaledefense = player.statLifeMax / 40;
            player.statDefense += dragscaledefense;

        }
	}
}