using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using System.Collections.Specialized;

namespace ofDarkandBelow.Items.FishStash
{
    public class ShootingStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shooting Star");
            Tooltip.SetDefault("Converts Wooden Arrows into Holy Arrows."
            + "\n'When she falls then I'll be waiting...'");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.crit = 5;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 42;
            item.useTime = 32;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shootSpeed = 25f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ProjectileID.HolyArrow;
            }
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                int num121 = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[num121].noDropItem = true;
            }
            return false;
        }
    }
}