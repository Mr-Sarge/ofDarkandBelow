using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Weaponry.Dev
{
	public class SanguisCaedis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sanguis Caedis");
			Tooltip.SetDefault("Rapid-swinging, Bloody Vengeance."
            + "\n'Inspire terror that burns the blood.'"
            + "\nDev Weapon: Jsoull");
        }
		public override void SetDefaults()
		{
			item.damage = 700;
            item.crit = 15;
			item.melee = true;
            item.noMelee = true;
			item.width = 38;
			item.height = 38;
            item.useTime = 4;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("BloodBarrage");
            item.shootSpeed = 20f;
            item.value = Item.sellPrice(gold: 40);
            item.knockBack = 4;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.channel = true;
            item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BeserkerCrystal"), 10);
            recipe.AddIngredient(ItemID.Arkhalis);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
