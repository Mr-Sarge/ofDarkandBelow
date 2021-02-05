using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Misc
{
    public class AncientBrassColt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Brass Colt");
            Tooltip.SetDefault("Has a 10% chance to explode into shrapnel on firing."
            + "\n'You loaded the bullets backwards.'");
        }
        public override void SetDefaults()
        {
            item.damage = 9;
            item.ranged = true;
            item.width = 58;
            item.height = 24;
            item.useTime = 24;
            item.useAnimation = 24;
            item.knockBack = 1;
            item.value = 1400;
            item.rare = 2;
            item.useStyle = 5;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Bullet;
            item.UseSound = SoundID.Item98;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.NextBool(10))
            {
                Main.PlaySound(SoundID.Item14, player.position);
                item.noUseGraphic = true;
                int numberProjectiles = 2 + Main.rand.Next(1);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    type = mod.ProjectileType("AncientBrassShrapnel");
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X / 2, perturbedSpeed.Y / 2, type, damage / 2, knockBack, player.whoAmI);
                }
            }
            else
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;
                item.noUseGraphic = false;
            }
            return true;
        }
        public override void AddRecipes()
        {
            // ModRecipe recipe = new ModRecipe(mod);
            // recipe.AddIngredient(null, "AncientBrassIngot", 15);
            // recipe.AddTile(TileID.Anvils);
            // recipe.SetResult(this, 1);
            // recipe.AddRecipe();
        }
    }
    public class AncientBrassShrapnel : ModProjectile
    {
        public override string Texture => "ofDarkandBelow/Items/Misc/AncientBrassShrapnel";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Brass Shrapnel");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 500;
        }
        public override void AI()
        {
            projectile.rotation += 0.25f;
            projectile.velocity.Y += 0.25f;
        }
    }
}
