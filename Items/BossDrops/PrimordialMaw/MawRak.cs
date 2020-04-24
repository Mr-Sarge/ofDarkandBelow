using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow.Items.BossDrops.PrimordialMaw
{
	public class MawRak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Maw-Rak");
			Tooltip.SetDefault("Bring Cosmic Retribution!"
			+ "\nThrows out up to 4 boomerang-like swords.");
		}
		public override void SetDefaults()
		{
			item.damage = 42;
			item.melee = true;
			item.width = 40;
			item.height = 44;
            item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 10;
            item.value = Item.sellPrice(gold: 2);
            item.rare = 3;
			item.UseSound = SoundID.Item1;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MawRakProj");
            item.shootSpeed = 20f;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 4;
        }
	}
}