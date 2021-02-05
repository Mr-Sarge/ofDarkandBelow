using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class OrichalcumDirk : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orichalcum Dirk");
			Tooltip.SetDefault("Spawns one to three petals upon hit.");
		}
		public override void SetDefaults()
		{
			item.damage = 43;
			item.crit = 4;
			item.width = 24;
			item.height = 22;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = Item.sellPrice(silver: 22);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("OrichalcumDirkProj");
            item.shootSpeed = 23f;
			item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1191, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 75);
			recipe.AddRecipe();
		}
	}
}



