using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class EdgeofTheUniverse : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Edge of The Universe");
			Tooltip.SetDefault("Linked to the Essence of the Universe.");
		}
		public override void SetDefaults()
		{
			item.damage = 100;
			item.shoot = 9;
			item.shootSpeed = 90f;
			item.melee = true;
			item.width = 64;
			item.height = 68;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient((ItemID.SoulofFright), 20);
			recipe.AddIngredient((ItemID.SoulofMight), 20);
			recipe.AddIngredient((ItemID.SoulofSight), 20);
			recipe.AddIngredient(mod.ItemType("CosmosEdge"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    float numberProjectiles = 6;
    float rotation = MathHelper.ToRadians(10);
    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
    for (int i = 0; i < numberProjectiles; i++)
    {
        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
    }
    return false;
	}
}}