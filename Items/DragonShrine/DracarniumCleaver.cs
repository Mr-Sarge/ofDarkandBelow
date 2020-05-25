using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class DracarniumCleaver : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarnium Cleaver");
            Tooltip.SetDefault("'Cleave a Dragon in half!'"
               + "\nThrows Dracarnium Sparks");

        }
		public override void SetDefaults()
		{
			item.damage = 32;
			item.melee = true;
			item.width = 38;
			item.height = 44;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 7;
            item.value = Item.sellPrice(0, 3, 10, 0);
            item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("DracarniumSpark");
            item.shootSpeed = 9f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
