using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class HeroesAlloy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heroes' Alloy");
            Tooltip.SetDefault("'Pulsing with mythical energies and legendary power...'");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = Item.sellPrice(gold: 2);
            item.rare = 4;
            item.maxStack = 999;
            item.material = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.SoulofNight, 1);
            recipe1.AddIngredient(ItemID.SoulofLight, 1);
            recipe1.AddIngredient(ItemID.CobaltBar, 2);
            recipe1.AddTile(TileID.Hellforge);
            recipe1.SetResult(this, 2);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.SoulofNight, 1);
            recipe2.AddIngredient(ItemID.SoulofLight, 1);
            recipe2.AddIngredient(ItemID.PalladiumBar, 2);
            recipe2.AddTile(TileID.Hellforge);
            recipe2.SetResult(this, 2);
            recipe2.AddRecipe();
        }
    }
}
