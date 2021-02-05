using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items
{
    public class EokaPistol : ModItem
    {
        public int BLP;
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eoaker");
			Tooltip.SetDefault("'It ain't much, but it's honest work.'");

        }
        public override void SetDefaults()
        {
            item.damage = 5;
            item.crit = 4;
            item.noMelee = true;
            item.ranged = true;
            item.width = 46;
            item.height = 24;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 5;
            item.value = Item.sellPrice(silver: 14, copper: 50);
            item.rare = 0;
            item.autoReuse = true;
            item.shootSpeed = 40f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if ((Main.rand.Next(0, 100) + BLP) >= 90)
            {
                int numberProjectiles = Main.rand.Next(4, 8);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    int num121 = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    Main.projectile[num121].noDropItem = true;
                }
                BLP = 0;
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SarcoItem"), (int)player.position.X, (int)player.position.Y);
            }
            else
            {
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 4);
                Dust.NewDust(player.position, 20, 20, 6, 1, 1, 100, default(Color), 1.5f);
                Dust.NewDust(player.position, 20, 20, 6, 1, 1, 100, default(Color), 1.5f);
                Dust.NewDust(player.position, 20, 20, 6, 1, 1, 100, default(Color), 1.5f);
                if (BLP <= 100)
                {
                    BLP += 20;
                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.CopperBar, 8);
            recipe1.AddIngredient(ItemID.Wood, 12);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.TinBar, 8);
            recipe2.AddIngredient(ItemID.Wood, 12);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}