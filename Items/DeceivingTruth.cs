using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 namespace ofDarkandBelow.Items
{
	public class DeceivingTruth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deceiving Truth");
			Tooltip.SetDefault("'Forged from the souls of countless creatures...'"
			+ "\nFires a spread of homing 'Deceitful Pellets'."
            + "\nDeveloper Item: Darkpuppey");
        }
		public override void SetDefaults() {
			item.damage = 28;
			item.crit = 20;
			item.magic = true;
			item.mana = 10;
			item.width = 56;
			item.height = 60;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 2;
            item.value = Item.sellPrice(gold: 25);
            item.rare = 12;
			item.UseSound = SoundID.Item63;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DeceitfulPellet");
			item.shootSpeed = 20f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}