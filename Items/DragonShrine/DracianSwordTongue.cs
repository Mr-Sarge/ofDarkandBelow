using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class DracianSwordTongue : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracian Sword-Tongue");
            Tooltip.SetDefault("'An aggressive terror to those who wade in the shrine's waters.'"
               + "\nSpits Burning Tongue teeth.");

        }
		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 9;
            item.value = Item.sellPrice(0, 5, 10, 0);
            item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("SwordTongueShard");
            item.shootSpeed = 17f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12 + Main.rand.Next(6)));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage / 2, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
