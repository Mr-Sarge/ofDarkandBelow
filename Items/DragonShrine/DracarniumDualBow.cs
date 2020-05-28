using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class DracarniumDualBow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarnium Great Dual-Bow");
            Tooltip.SetDefault("'The world shall know a dastardly pain.'"
                + "\nQuickly Fires 2 arrows at once."
                + "\nReplaces Wooden Arrows with Dracarnium Arrows.");
        }
        public override void SetDefaults()
		{
			item.damage = 21;
			item.ranged = true;
			item.width = 36;
			item.height = 66;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
            item.value = Item.sellPrice(0, 3, 10, 0);
            item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 33f;
			item.useAmmo = AmmoID.Arrow;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
           if (type == ProjectileID.WoodenArrowFriendly)
           {
                type = mod.ProjectileType("DracarniumArrow");
           }
            Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
            float num117 = 0.314159274f;
            int num118 = 2;
            Vector2 vector7 = new Vector2(speedX, speedY);
            vector7.Normalize();
            vector7 *= 40f;
            bool flag11 = Collision.CanHit(vector2, 0, 0, vector2 + vector7, 0, 0);
            for (int num119 = 0; num119 < num118; num119++)
            {
                float num120 = (float)num119 - ((float)num118 - 1f) / 2f;
                Vector2 value9 = vector7.RotatedBy((double)(num117 * num120), default(Vector2));
                if (!flag11)
                {
                    value9 -= vector7;
                }
                int num121 = Projectile.NewProjectile(vector2.X + value9.X, vector2.Y + value9.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0.0f, 0.0f);
                Main.projectile[num121].noDropItem = true;
            }
            float SpeedX = speedX + (float)Main.rand.Next(-25, 26) * 0.05f;
            float SpeedY = speedY + (float)Main.rand.Next(-25, 26) * 0.05f;

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
