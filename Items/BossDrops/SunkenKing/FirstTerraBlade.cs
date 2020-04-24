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
			item.damage = 22;
			item.shoot = (mod.ProjectileType("SunkenBeam"));
			item.melee = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/OldTerraSwing");
            item.width = 46;
			item.height = 50;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 3;
            item.value = Item.sellPrice(silver: 50);
            item.rare = 2;
			item.autoReuse = true;
		}
	}
}
