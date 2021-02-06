using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class MeatBow : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meat Bow");
			Tooltip.SetDefault("'Good for when you're hunting and out of food! ...wait.'");
		}
        public override void SetDefaults()
        {
            item.damage = 9;
            item.noMelee = true;
            item.ranged = true;
            item.width = 26;
            item.height = 58;
            item.useTime = 49;
            item.useAnimation = 49;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 2;
            item.value = Item.sellPrice(copper: 60);
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shootSpeed = 10f;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RawMeat"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
    }
}}