using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ofDarkandBelow.Items.Weaponry.Dev
{
	public class ReganoxClaymore : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reganox Claymore");
            Tooltip.SetDefault("'Wear your mask well, and it shall serve you well.'"
                + "\nFires a projectile that bounces thrice before exploding into shards."
                + "\nDeveloper Item: Maskano");
		}
		public override void SetDefaults()
		{
			item.damage = 23;
			item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 7;
            Item.sellPrice(gold: 18);
            item.rare = 4;
            item.expert = true;
            item.shoot = mod.ProjectileType("ReganoxProj");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shootSpeed = 15f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
	}
}
