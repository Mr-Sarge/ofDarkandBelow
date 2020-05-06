using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class Zura : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zura");
            Tooltip.SetDefault("Saps life on hits."
            + "\nAnd I say,"
            + "\nAll fall in the end."
            + "\nFor heroes die and villains rise,"
            + "\nYet even the mightiest of the mighty succumb to death. Death of the mind,"
            + "\nDeath of the Soul, and Death of the Life.");
		}
		public override void SetDefaults()
		{
			item.damage = 320;
			item.melee = true;
			item.width = 68;
			item.height = 80;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(platinum: 5);
            item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient((ItemID.BreakerBlade), 1);
			recipe.AddIngredient((ItemID.ChlorophyteClaymore), 1);
            recipe.AddIngredient((ItemID.ChlorophyteSaber), 1);
            recipe.AddIngredient((ItemID.PsychoKnife), 1);
            recipe.AddIngredient((ItemID.Cutlass), 1);
            recipe.AddIngredient((3458), 35);
			recipe.AddIngredient((ItemID.LunarBar), 35);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)  
		{
            if (target.immortal == false)
            {
                player.statLife += 60;
                player.HealEffect(60, true);
            }
        }
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Color.Aqua.R, Color.Aqua.G, Color.Aqua.B);
                }
            }
		}
	}
}