using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items.DragonShrine
{
    public class DracarniumFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarnium Flail");
            Tooltip.SetDefault("'Strike them down with fiery essence!'"
                + "\nThis Flail inflicts Dracarnium Flames!");
		}
        public override void SetDefaults()
        {
            item.width = 46;
            item.height = 40;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = 3;
            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 40;
            item.knockBack = 7.5F;
            item.damage = 45;
            item.noUseGraphic = true; // Do not use the item graphic when using the item (we just want the ball to spawn).
            item.shoot = mod.ProjectileType("DracarniumFlailProj");
            item.shootSpeed = 22F;
            item.UseSound = SoundID.Item1;
            item.melee = true; // Deals melee damage.
            item.channel = true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}