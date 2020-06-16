using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Freak
{
	public class FreakKnifePlayer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freak Knife");
			Tooltip.SetDefault("'Perfect for stabbing townsfolk... Not saying you should.'");
		}
		public override void SetDefaults()
		{
            item.CloneDefaults(1809);
			item.damage = 18;
			item.shoot = mod.ProjectileType("FreakKnifePlayerProj");
		    item.shootSpeed = 30f;
			item.width = 40;
			item.height = 40;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 50;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
