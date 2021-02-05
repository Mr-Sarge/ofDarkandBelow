using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using ofDarkandBelow.Projectiles.Dracarnium;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class Hidepiercer : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hidepiercer");
            Tooltip.SetDefault("Fires Dracarnium Arrows."
                + "\nCharging the bow increases damage."
                + "\nFully charging the bow, will release a Black Arrow."
                + "\n'My armour is like tenfold shields, my teeth are swords...'");

                /* Theoretical damage is that in a perfect scenario:
                *  No Charge = 262.5 DPS
                *  60 Frames Charge = 210 DPS
                *  90 Frames Charge = 280 DPS
                *  120 Frames Charge = 315 DPS
                *  180 Frames Charge = 350 DPS
                */
        }
        public override void SetDefaults()
		{
			item.damage = 105;
			item.ranged = true;
			item.width = 46;
            item.crit = 12;
			item.height = 66;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
            item.value = Item.sellPrice(0, 20, 00, 0);
            item.rare = 8;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 33f;
            item.useAmmo = AmmoID.Arrow;
            item.channel = true;
            item.noUseGraphic = false;
            item.autoReuse = true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.useTime >= 0)
            {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<HidepiercerProj>(), damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
