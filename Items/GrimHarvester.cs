using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace ofDarkandBelow.Items
{
	public class GrimHarvester : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grim-Harvester");
			Tooltip.SetDefault("'Consume the Soul.'");
		}
		public override void SetDefaults()
		{
			item.damage = 85;
			item.melee = true;
			item.width = 66;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 17);
            item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SoulShred");
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 25);
			recipe.AddIngredient(ItemID.DeathSickle, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
