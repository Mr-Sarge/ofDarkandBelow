using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	public class KinglyKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Knife");
			Tooltip.SetDefault("'A king's deathly blade.'");
		}
		public override void SetDefaults()
		{
            item.CloneDefaults(1809);
			item.damage = 19;
			item.shoot = mod.ProjectileType("KinglyKnifeProj");
		    item.shootSpeed = 25f;
			item.maxStack = 1;
			item.width = 20;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 2;
            item.value = Item.sellPrice(silver: 25);
            item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.autoReuse = true;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FallenFragment"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
