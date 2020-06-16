using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.JungleProtector
{
	public class JungleFlintlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Flintlock");
			Tooltip.SetDefault("40% chance to not consume ammo"
			+ "\n'Fastest seeder in the world.'"
			+ "\n...wait a minute, you're not supposed to have this!");
		}
		public override void SetDefaults()
		{
            item.CloneDefaults(281);
			item.damage = 22;
		    item.shootSpeed = 70f;
			item.width = 64;
			item.height = 30;
			item.useTime = 8;
			item.useAnimation = 8;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.autoReuse = true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .40f;
		}
	}
}
