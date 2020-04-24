using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ofDarkandBelow.Projectiles;

namespace ofDarkandBelow.Items
{
    public class SunkenScroll : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunken Scroll");
			Tooltip.SetDefault("'Saying the words on this gives you a sense of dread...'"
			+ "\nOnly Usuable in the Glowing Mushroom Biome"
			+ "\nSummons the Sunken King");
		}
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.maxStack = 1;
            item.value = Item.sellPrice(copper: 0);
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {           
            return player.ZoneGlowshroom && !NPC.AnyNPCs(mod.NPCType("SunkenKing"));
        }
        public override bool UseItem(Player player)
        {
        int num = NPC.NewNPC((int)(player.position.X + (float)(Main.rand.Next(200, 300))), (int)(player.position.Y + 40f), mod.NPCType("SunkenKing"), 0, 0f, 0f, 0f, 0f, 255);
        if (Main.netMode == 2 && num < 200)
        {
            NetMessage.SendData(23, -1, -1, null, num, 0f, 0f, 0f, 0, 0, 0);
        }
        Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
        Main.NewText("The Sunken King has Awoken from His Slumber!", Color.MediumPurple.R, Color.MediumPurple.G, Color.MediumPurple.B);

         return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ItemID.ShadowScale, 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 15);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Silk, 5);
            recipe2.AddIngredient(ItemID.TissueSample, 1);
            recipe2.AddIngredient(ItemID.GlowingMushroom, 15);
            recipe2.AddIngredient(ItemID.Wood, 5);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
