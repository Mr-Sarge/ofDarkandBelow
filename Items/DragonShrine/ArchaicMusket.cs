using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ofDarkandBelow;

namespace ofDarkandBelow.Items.DragonShrine
{
    public class ArchaicMusket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Archaic Musket");
            Tooltip.SetDefault("'This thing is an unreliable mess!'"
                + "\nFiring speed randomizes each shot."
                + "\nReplaces Musket Balls with Archaic Bullets.");
        }
        private int randTime;
        private int shootTimeRand;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            randTime++;
            if (randTime == 1)
            {
                shootTimeRand = 20 + Main.rand.Next(12);
                randTime = 0;
                item.useTime = shootTimeRand;
                item.useAnimation = shootTimeRand;
            }
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("ArchaicBullet");
            }
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
        public override void SetDefaults()
        {
            item.damage = 33;
            item.noMelee = true;
            item.ranged = true;
            item.width = 66;
            item.height = 30;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 1;
            item.value = Item.sellPrice(gold: 5);
            item.rare = 3;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/ArchaicGunItem");
            item.autoReuse = true;
            item.shootSpeed = 40f;
            item.useTime = 30;
            item.useAnimation = 30;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }
    }
}