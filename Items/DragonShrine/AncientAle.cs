using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 namespace ofDarkandBelow.Items.DragonShrine
{
    public class AncientAle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Ale");
            Tooltip.SetDefault("Throws an ancient bottle of Ale that explodes into sparks."
            + "\nNot Consumable");
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
            item.ranged = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(gold: 5);
            item.shoot = mod.ProjectileType("AncientAleProj");
        }
    }
}