using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Null
{
	public class Amalgamate : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Amalgamate");
			Tooltip.SetDefault("'Woof. Woof.'");
		}

		public override void SetDefaults() {
			item.damage = 23;
			item.magic = true;
			item.mana = 10;
			item.width = 46;
			item.height = 46;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
            item.value = Item.sellPrice(gold: 2);
            item.rare = 3;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/woofamalg");
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NullBolt");
			item.shootSpeed = 20f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    float numberProjectiles = 2;
    float rotation = MathHelper.ToRadians(10);
    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
    for (int i = 0; i < numberProjectiles; i++)
    {
        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
		float scale = 1f - (Main.rand.NextFloat() * .3f);
		perturbedSpeed = perturbedSpeed * scale; 
    }
    return false;
	}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}