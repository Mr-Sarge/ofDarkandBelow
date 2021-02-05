using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace ofDarkandBelow.Items.Misc.BoneItems
{
	public class BoneBrand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bonebrand");
			Tooltip.SetDefault("Throws a bouncing bone that splits apart."
            +"\n'An eerie sword made of living bone.'");
        }
		public override void SetDefaults()
		{
			item.damage = 42;
			item.melee = true;
			item.width = 48;
			item.height = 50;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(gold: 10);
            item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BoneFemurProjectile");
			item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BoneSword, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.Bone, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
