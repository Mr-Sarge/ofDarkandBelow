using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items.Accessories.Misc
{
    public class HarasserAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amulet of The Harasser");
            Tooltip.SetDefault("'Terrors of the night envy your strength'"
            + "\nCritical Hits restore life"
            + "\nDeveloper Item: Jsoull");

        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 46;
            item.value = Item.sellPrice(platinum: 5);
            item.rare = 9;
            item.expert = true;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SModPlayer modPlayer = (SModPlayer)player.GetModPlayer(mod, "SModPlayer");
            player.GetModPlayer<SModPlayer>().harasserHeal = true;
        }
    }
}