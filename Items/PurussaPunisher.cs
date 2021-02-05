using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class PurussaPunisher : ModItem
    {
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purussa-Punisher");
			Tooltip.SetDefault("'God of the Lake.'"
                + "\nEvery third shot fires out homing rockets.");
		}
        private int breathBlast;
        public override void SetDefaults()
        {
            item.damage = 48;
            item.noMelee = true;
            item.ranged = true;
            item.width = 90;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 7;
            item.value = Item.sellPrice(gold: 30);
            item.rare = 10;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PurussaItem");
            item.autoReuse = true;
            item.shootSpeed = 62f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            breathBlast++;
            if (breathBlast == 3)
            {
                type = mod.ProjectileType("CrocoRocket");
                int numberProjectiles = 2 + Main.rand.Next(3); // 4 or 5 shots
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(14));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1.5f), (int)(knockBack * 1.5f), player.whoAmI);
                }
                breathBlast = 0;
            }
            else
            {
                int numberProjectiles = 9 + Main.rand.Next(3); // 4 or 5 shots
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(6));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 16f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(533);
			recipe.AddIngredient(mod.ItemType("DeinoDevastator"));
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(3456, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}