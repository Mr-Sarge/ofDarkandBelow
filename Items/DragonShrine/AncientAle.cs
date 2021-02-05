using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ofDarkandBelow.Buffs;
using Microsoft.Xna.Framework.Graphics;

namespace ofDarkandBelow.Items.DragonShrine
{
    public class AncientAle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Ale");
            Tooltip.SetDefault("Throws an ancient bottle of ale that explodes into sparks."
                + "\n'Smells worse than Strange Brew and the Mysterious Drink combined!'");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 9f;
            item.damage = 28;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 26;
            item.useTime = 26;
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.rare = 3;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.value = Item.sellPrice(gold: 5);
            item.shoot = mod.ProjectileType("AncientAleProj");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (!player.HasBuff(mod.BuffType("AncientAleBuff")) == true)
            {
                item.useAnimation = 26;
                item.useTime = 26;
            }
            else
            {
                item.useAnimation = 16;
                item.useTime = 16;
            }
            if (player.altFunctionUse == 2)     //2 is right click
            {
                if (!player.HasBuff(mod.BuffType("AncientAleBuffCoolDown")))
                {
                    item.noUseGraphic = false;
                    player.AddBuff(mod.BuffType("AncientAleBuff"), 600);
                    player.AddBuff(mod.BuffType("AncientAleBuffCoolDown"), 2400);
                    Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 3);
                    return false;
                }
                else
                {
                    CombatText.NewText(player.getRect(), Colors.CoinSilver, "NOT READY YET", true, false);
                    return false;
                }
            }
            else
            {
                item.noUseGraphic = true;
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                float scale = 1f;
                if (player.HasBuff(mod.BuffType("AncientAleBuff")))
                {
                    scale = 3f;
                    item.useAnimation = 16;
                    item.useTime = 16;
                }
                else
                {
                    scale = 1f;
                    item.useAnimation = 26;
                    item.useTime = 26;
                }
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 1);
                return false;
            }
            return base.CanUseItem(player);
        }
    }
}