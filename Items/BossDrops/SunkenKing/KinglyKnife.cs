using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
	public class KinglyKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kingly Knife");
			Tooltip.SetDefault("'A king's deathly blade.'");
		}
		public override void SetDefaults()
		{
            item.CloneDefaults(1809);
			item.damage = 24;
			item.shoot = mod.ProjectileType("KinglyKnifeProj");
		    item.shootSpeed = 25f;
			item.maxStack = 1;
			item.width = 20;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 50;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.consumable = false;
			item.autoReuse = true;
		}
	}
}
