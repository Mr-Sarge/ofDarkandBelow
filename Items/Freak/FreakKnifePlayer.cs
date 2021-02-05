using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Freak
{
	public class FreakKnifePlayer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freak Knife");
			Tooltip.SetDefault("'Perfect for stabbing townsfolk... Not saying you should.'");
		}
		public override void SetDefaults()
		{
            item.CloneDefaults(1809);
			item.damage = 18;
			item.shoot = mod.ProjectileType("FreakKnifePlayerProj");
		    item.shootSpeed = 15f;
			item.width = 12;
			item.height = 28;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 50;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
    }
}
