using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
	public class MawRak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Maw-Rak");
			Tooltip.SetDefault("Bring Cosmic Retribution!"
			+ "\nInflicts Cosmic Flame'");
		}
		public override void SetDefaults()
		{
			item.damage = 42;
			item.melee = true;
			item.width = 80;
			item.height = 86;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)  
		{
			target.AddBuff(mod.BuffType("CosmicFlame"), 200);
		}
	}
}