using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
	public class EyeofTheMaw : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Eye of The Maw");
			Tooltip.SetDefault("Fires a cosmic-flaming spike ball.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
			item.damage = 36;
			item.magic = true;
			item.mana = 7;
            item.width = 62;
			item.height = 62;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
            item.value = Item.sellPrice(gold: 2);
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
