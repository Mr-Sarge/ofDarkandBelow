using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class CosmosEdge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmos' Edge");
			Tooltip.SetDefault("'Linked to the essence of the cosmos.'");
		}
		public override void SetDefaults()
		{
			item.damage = 22;
			item.shoot = 9;
			item.shootSpeed = 60f;
			item.melee = true;
			item.width = 44;
			item.height = 48;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient((ItemID.MeteoriteBar), 20);
			recipe.AddIngredient((ItemID.HellstoneBar), 20);
			recipe.AddIngredient((ItemID.DemoniteBar), 20);
			recipe.AddIngredient((ItemID.Bone), 20);
			recipe.AddIngredient((ItemID.JungleSpores), 20);
			recipe.AddIngredient(mod.ItemType("CosmicClusterFragment"), 35);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    float numberProjectiles = 3;
    float rotation = MathHelper.ToRadians(10);
    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
    for (int i = 0; i < numberProjectiles; i++)
    {
        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
    }
    return false;
	}
}}