using Microsoft.Xna.Framework;
using ofDarkandBelow.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	public class FirstTerraBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The First Terra-Blade");
			Tooltip.SetDefault("'The blade is still sharp, even after all these years...'");
		}
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.TerraBlade);
			item.damage = 26;
			item.shoot = (mod.ProjectileType("SunkenBeam"));
			item.melee = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/OldTerraSwing");
            item.width = 46;
			item.height = 50;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 4;
            item.value = Item.sellPrice(silver: 50);
            item.rare = 3;
			item.autoReuse = true;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FallenFragment"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
