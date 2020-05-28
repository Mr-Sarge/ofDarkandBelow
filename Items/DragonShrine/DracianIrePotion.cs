using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ofDarkandBelow.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class DracianIrePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Dracian Ire Potion");
            Tooltip.SetDefault("5% Increase to Damage and Critical Strike Chance,"
                + "\nAttackers take damage and are set ablaze with Dracarnium Flames.");
        }

		public override void SetDefaults()
		{
            item.UseSound = SoundID.Item3;             //this is the sound that plays when you use the item
            item.useStyle = ItemUseStyleID.EatingUsing;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.consumable = true;
            item.width = 20;
            item.height = 32;
            item.maxStack = 30;
            item.value = Item.sellPrice(0, 0, 22, 0);
            item.rare = 3;
            item.buffType = mod.BuffType("IreBuff");    //this is where you put your Buff name
            item.buffTime = 15300;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.alchemy = true;
            recipe.AddIngredient(mod.ItemType("DracianSpikeFish"));
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
