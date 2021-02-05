using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.Thrower
{
	public class TrueShadTip : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Shadow's Tip");
			Tooltip.SetDefault("'Do you trust the whispers yet? Have you accepted madness?'");
		}
		public override void SetDefaults()
		{
			item.damage = 64;
			item.crit = 5;
			item.width = 38;
			item.height = 42;
			item.useTime = 33;
			item.useAnimation = 33;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = Item.sellPrice(gold: 10);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("TrueShadTipProj");
			item.shootSpeed = 20f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(mod.ItemType("ShadTip"));
			recipe1.AddIngredient(1570);
			recipe1.AddTile(TileID.MythrilAnvil);
			recipe1.SetResult(this);
			recipe1.AddRecipe();
		}
	}
}



