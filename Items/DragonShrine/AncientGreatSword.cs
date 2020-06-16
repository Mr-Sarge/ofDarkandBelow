using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class AncientGreatSword : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Greatsword");
            Tooltip.SetDefault("Throws a burning, scythe-slashing ball."
               + "\n'An easily forgotten sword of a once great era...'");

        }
		public override void SetDefaults()
		{
			item.damage = 42;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 9;
            item.value = Item.sellPrice(0, 5, 10, 0);
            item.rare = 3;
			item.UseSound = SoundID.Item68;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("DracarniumOrb");
            item.shootSpeed = 17f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8 + Main.rand.Next(8)));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage / 2, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
