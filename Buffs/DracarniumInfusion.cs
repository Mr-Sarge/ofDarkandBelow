using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Buffs
{
    public class DracarniumInfusion : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Dracarnium Infusion");
			Description.SetDefault("'Rage of fallen dragons compel you!'");
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.meleeCrit += 15;
            player.meleeDamage += 0.22f;
            player.meleeSpeed += 0.30f;
            player.statDefense -= 10;
            player.moveSpeed += 0.55f;
            player.jumpSpeedBoost += 1.8f;

            int DustID2 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("DracarniumFlamesDust"), player.velocity.X * 0.55f, player.velocity.Y * 0.25f, 20, default(Color), 0.9f);
            Main.dust[DustID2].noGravity = true;
            int DustID3 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("DracarniumFlamesDust"), player.velocity.X * 0.25f, player.velocity.Y * 0.1f, 20, default(Color), 1.1f);
            Main.dust[DustID3].noGravity = true;
        }
    }
}