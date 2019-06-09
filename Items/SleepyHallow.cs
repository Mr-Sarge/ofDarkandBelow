using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class SleepyHallow : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Sleepy Hallow");
			Tooltip.SetDefault("'Raise the Nightmare of Ichabod Crane.'");
		}

		public override void SetDefaults() {
			item.damage = 240;
			item.magic = true;
			item.mana = 60;
			item.width = 28;
			item.height = 38;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 7;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("TheHorseman");
			item.shootSpeed = 15f;
	    }
	}
}