using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
	public class EyeofTheMaw : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Eye of The Maw");
			Tooltip.SetDefault("Fires a cosmic-flaming spike ball from Maw's power.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
			item.damage = 32;
			item.magic = true;
			item.mana = 5;
			item.width = 48;
			item.height = 46;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("EndlessBall");
			item.shootSpeed = 20f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)  
		{
			target.AddBuff(mod.BuffType("CosmicFlame"), 200);
	    }
	}
}
