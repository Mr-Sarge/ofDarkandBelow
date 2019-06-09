using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
    public class AstralArrow : ModItem
    {
			public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Arrow");
			Tooltip.SetDefault("Make them Burn!");
		}
        public override void SetDefaults()
        {
            item.damage = 10;    //The damage stat for the Weapon.
            item.ranged = true;  //This defines if it does Ranged damage and if its effected by Ranged increasing Armor/Accessories.
            item.width = 8;  //The size of the width of the hitbox in pixels.
            item.height = 8;   //The size of the height of the hitbox in pixels.
            item.maxStack = 999; //This defines the items max stack
            item.consumable = true;  //Tells the game that this should be used up once fired
            item.knockBack = 1.5f;  //Added with the weapon's knockback
            item.value = Item.buyPrice(0, 0, 20, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 20silvers)
            item.rare = 2;   //The color the title of your Weapon when hovering over it ingame  
            item.shoot = mod.ProjectileType("AstralArrowProj");  //This defines what type of projectile this weapon will shoot	
            item.shootSpeed = 2f; //Added to the weapon's shoot speed
            item.ammo = 40;    //This defines what type of ammo is. 40 is arrow
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 40);
			recipe.AddRecipe();
        }
    }
}