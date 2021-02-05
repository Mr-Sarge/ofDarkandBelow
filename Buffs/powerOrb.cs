using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ofDarkandBelow.Buffs;
using ofDarkandBelow.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ofDarkandBelow.Buffs
{
    public class powerOrb : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            DisplayName.SetDefault("Overcharged");
            Description.SetDefault("Movement speed increased significantly."
               + "\n'You are overloaded with power... no literally, it hurts.'");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = -15;
            player.moveSpeed += 0.55f;
            if (player.ownedProjectileCounts[mod.ProjectileType("powerOrbProj")] < 1)
            {
                float screenPosX = Main.screenPosition.X + (Main.screenWidth / 2);
                float screenPosY = Main.screenPosition.Y + (Main.screenHeight / 2);
                Projectile.NewProjectile(screenPosX, screenPosY, 0, 0, mod.ProjectileType("powerOrbProj"), 0, 0, Main.myPlayer);

            }
        }
    }
}