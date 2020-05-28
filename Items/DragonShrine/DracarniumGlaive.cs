using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ofDarkandBelow.Projectiles.Dracarnium;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class DracarniumGlaive : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarnium Great-Glaive");
            Tooltip.SetDefault("'Tear opponents asunder!'"
                + "\nSwings a glaive that inflicts Dracarnium Flames.");
		}
		
        public override void SetDefaults()
        {
            item.width = 84;
            item.height = 88;
            item.damage = 29;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 25, 0);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 30;
            item.useTime = 30;
            item.UseSound = SoundID.Item1;
            item.knockBack = 6;
            item.melee = true;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("DracarniumGlaiveProj");
            item.shootSpeed = 3f;
            item.rare = 3;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1; // This is to ensure the spear doesn't bug out when using autoReuse = true
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DracarniumIngot", 17);
            recipe.AddTile(TileID.Anvils); //makes that you craft these,at a Workbench
            recipe.SetResult(this, 1); //you get 1 Sword at Crafting
            recipe.AddRecipe();
        }

    }
}