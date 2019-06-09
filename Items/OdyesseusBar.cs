using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class OdyesseusBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Odyesseus' Bar");
			Tooltip.SetDefault("Bar of a Hero");
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 43;
			item.value = 10000;
			item.rare = 4;
			item.maxStack = 999;
			item.material = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.SoulofMight, 1);
			recipe1.AddIngredient(ItemID.CobaltBar, 1);
			recipe1.AddTile(TileID.Anvils);
			recipe1.SetResult(this);
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.SoulofMight, 1);
			recipe2.AddIngredient(ItemID.PalladiumBar, 1);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}}}
