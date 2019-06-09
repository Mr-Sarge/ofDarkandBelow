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
			item.width = 46;
			item.height = 54;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 1000;
			item.rare = 2;
			item.autoReuse = true;
		}
	}
}
