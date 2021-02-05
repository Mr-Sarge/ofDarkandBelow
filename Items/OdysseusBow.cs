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

namespace ofDarkandBelow.Items
{
    public class OdysseusBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Odysseus' Greatbow");
            Tooltip.SetDefault("'None of the suitors possessed the strength to string it, but you do.'"
                + "\nChanges wooden arrows into Odysseus Arrows. Speeds up while firing.");
        }
        private int increaseTime;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            increaseTime++;
            if (increaseTime == 1)
            {
                if (item.useTime <= 12)
                {
                    item.useTime = 30;
                    item.useAnimation = 30;
                }
                else
                {
                    item.useTime -= 2;
                    item.useAnimation -= 2;
                }
                increaseTime = 0;
            }
            if (type == 1)
            {
                type = mod.ProjectileType("OdysseusArrowProj");
                item.shootSpeed = 30f;
            }
            else
            {
                item.shootSpeed = 25f;
            }
            return true;
        }
        public override void SetDefaults()
        {
            item.damage = 54;
            item.crit = 15;
            item.noMelee = true;
            item.ranged = true;
            item.width = 36;
            item.height = 72;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 2);
            item.rare = 5;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 25f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod.ItemType("HeroesAlloy"), 9);
            recipe1.AddIngredient(ItemID.DemonBow, 44);
            recipe1.AddIngredient(3380, 10);
            recipe1.AddIngredient(ItemID.Bone, 20);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("HeroesAlloy"), 9);
            recipe2.AddIngredient(796, 1);
            recipe2.AddIngredient(3380, 10);
            recipe2.AddIngredient(ItemID.Bone, 20);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}