using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items     //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    [AutoloadEquip(EquipType.Shield)]
    public class OdysseusShield : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Odysseus' Shield");
			Tooltip.SetDefault("4 defense"
            + "\n10% increased melee damage"
            + "\n15% increased thrown damage"
            + "\n'The shield that allows one to scare a cyclops.'");
        }
        public override void SetDefaults()
        {
            item.width = 46;   //The size in width of the sprite in pixels.
            item.height = 62;    //The size in height of the sprite in pixels
            item.value = Item.buyPrice(0, 14, 0, 0); //  How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 2 gold)
            item.rare = 5;          //The color the title of your Weapon when hovering over it ingame        
            item.accessory = true;  //this make the item an accessory, so you can equip it
 
        }
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeDamage += .10f;
			player.thrownDamage += .15f;
            player.statDefense += 4;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SpartanShield"), 1);
            recipe.AddIngredient(mod.ItemType("OdyesseusBar"), 12);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
	    }
    }
}