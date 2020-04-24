using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class TheRapture : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Rapture");
			Tooltip.SetDefault("'And in Rapture... We fall.'");
		}
		public override void SetDefaults()
		{
			item.damage = 190;
			item.shoot = 9;
			item.shootSpeed = 90f;
			item.melee = true;
			item.width = 64;
			item.height = 70;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 50);
            item.rare = 11;
			item.UseSound = SoundID.Item100;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient((ItemID.LunarBar), 10);
			recipe.AddIngredient(mod.ItemType("EdgeofTheUniverse"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
        float numberProjectiles = 6;
        float rotation = MathHelper.ToRadians(10);
        position += Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;
        for (int i = 0; i < numberProjectiles; i++)
        {
           Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
		   float scale = 1f - (Main.rand.NextFloat() * .3f);
		   perturbedSpeed = perturbedSpeed * scale; 
        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
		Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 503, damage, knockBack, player.whoAmI);
		Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 424, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 1.6f, perturbedSpeed.Y * 1.6f, mod.ProjectileType("StarDeath"), damage, knockBack, player.whoAmI);
            }
    return false;
	}
}}