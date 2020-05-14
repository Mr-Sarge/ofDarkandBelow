using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	public class KingsHarvest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King's Harvest");
			Tooltip.SetDefault("'Reap the Benefits of Royalty'"
                + "\nBrings a slash down wherever the cursor is.");
        }
		public override void SetDefaults()
		{
			item.damage = 19;
			item.crit = 4;
			item.magic = true;
            item.mana = 10;
			item.width = 52;
			item.height = 44;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(silver: 25);
            item.rare = 2;
            item.shoot = 10;
            item.shootSpeed = 0f;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 vectorCursor = Main.MouseWorld;
            Projectile.NewProjectile(vectorCursor.X, vectorCursor.Y, speedX, speedY, mod.ProjectileType("KingReap"), damage, knockBack, player.whoAmI);
            return false;
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
