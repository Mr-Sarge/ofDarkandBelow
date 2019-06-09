using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class CatastrophicRedemption : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Catastrophic Redemption");
			Tooltip.SetDefault("'Blessed with the Randomness of the Noob King Himself...'"
			+ "\nDeveloper Item: Hallam");
		}
		public override void SetDefaults()
		{
			item.damage = 190;
			item.melee = true;
			item.width = 98;
			item.height = 88;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.shoot = 254;
			item.shootSpeed = 90f;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 9;
			item.expert = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
        float numberProjectiles = 3;
        float rotation = MathHelper.ToRadians(10);
        position += Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;
        for (int i = 0; i < numberProjectiles; i++)
        {
           Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
		   float scale = 1f - (Main.rand.NextFloat() * .3f);
		   perturbedSpeed = perturbedSpeed * scale; 
           Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
	   	   Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 483, damage, knockBack, player.whoAmI);
		   Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 451, damage, knockBack, player.whoAmI);
        }
        return false;
		}
	}
}