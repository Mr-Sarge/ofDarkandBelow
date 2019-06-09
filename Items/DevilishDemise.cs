using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class DevilishDemise : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devilish Demise");
			Tooltip.SetDefault("'Become a Herald of The Underworld'");
		}
		public override void SetDefaults()
		{
			item.damage = 75;
			item.melee = true;
			item.width = 108;
			item.height = 104;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 1000000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 274;
			item.shootSpeed = 60f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DevilishTainter"));
			recipe.AddIngredient(mod.ItemType("IcyDemise"));
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(ItemID.DeathSickle);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    float numberProjectiles = 4;
    float rotation = MathHelper.ToRadians(10);
    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
    for (int i = 0; i < numberProjectiles; i++)
    {
        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
    }
    return false;
	}
    public override Vector2? HoldoutOffset()
    {
     return new Vector2(10, 0);
    }
}}