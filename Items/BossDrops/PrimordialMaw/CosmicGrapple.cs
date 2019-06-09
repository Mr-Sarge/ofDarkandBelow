using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
    public class CosmicGrapple : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Grapple");
			Tooltip.SetDefault("'Grapple the Stars'");
		}
        public override void SetDefaults()
        {
            //clone and modify the ones we want to copy
            item.CloneDefaults(ItemID.DiamondHook);
			item.height = 34;
			item.width = 26;
            item.shootSpeed = 24f; // how quickly the hook is shot.
            item.shoot = mod.ProjectileType("CosmicGrappleProj");
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 15);
			recipe.AddIngredient(ItemID.GrapplingHook);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}