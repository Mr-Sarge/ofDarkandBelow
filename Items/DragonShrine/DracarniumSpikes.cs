using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.DragonShrine
{
	public class DracarniumSpikes : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dracarnium Spikes");
			Tooltip.SetDefault("Low durability, highly volatile. Why would you hold this?"
				+ "\n Active Time: 8 Seconds"
				+ "\n Durability: 4 Hits");
		}
		public override void SetDefaults()
		{
			item.damage = 18;
			item.crit = 4;
			item.width = 38;
			item.height = 38;
			item.useTime = 28;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = Item.sellPrice(copper: 28);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.shoot = mod.ProjectileType("DracarniumSpikesProj");
            item.shootSpeed = 15f;
			item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 75);
			recipe.AddRecipe();
		}
	}
}



