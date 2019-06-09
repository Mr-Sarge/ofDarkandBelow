using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class GobblerBiteStaff : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Staff of Gluttony");
			Tooltip.SetDefault("Cast a bitting gobbler maw.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
			item.damage = 86;
			item.magic = true;
			item.mana = 15;
			item.width = 100;
			item.height = 104;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GobblerBite");
			item.shootSpeed = 10f;
		}
	}
}
