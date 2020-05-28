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
    public class ShrineGuardShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shrine Guard's Shield");
			Tooltip.SetDefault("'This ancient shield of Dracarnium will serve you until death.'"
                + "\n+5 Defense" 
                + "\nUpon reaching 35% Life you gain 10 more Defense and 7% Damage Reduction.");
        }

		public override void SetDefaults() {
			item.width = 22;
			item.height = 28;
            item.value = Item.sellPrice(gold: 2);
            item.rare = 3;
			item.expert = false;
			item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statDefense += 5;
            if (player.statLife <= player.statLifeMax * 0.35f)
            {
                player.statDefense += 10;
                player.endurance += 0.07f;
            }
        }
	}
}