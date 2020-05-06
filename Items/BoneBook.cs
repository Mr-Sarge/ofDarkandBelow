using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
	public class BoneBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grim Reaper's Tome");
			Tooltip.SetDefault("Left click to fire 3 skulls, right click to fire 3 spinning bone blades.");
		}
        public override void SetDefaults()
        {
            item.damage = 60;
			item.mana = 20;
            item.width = 28;
            item.height = 30;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100;
            item.rare = 3;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.useTurn = true;
			item.shoot = 270;
			item.shootSpeed = 50f;
			item.useStyle = 5;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    float numberProjectiles = 3;
    float rotation = MathHelper.ToRadians(10);
    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
    for (int i = 0; i < numberProjectiles; i++)
    {
        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
    }
    return false;
	}
        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BookofSkulls, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddIngredient(ItemID.Bone, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
 
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)     //2 is right click
            {
 
                item.useTime = 40;
                item.useAnimation = 40;
                item.damage = 110;
                item.UseSound = SoundID.Item20;
				item.shoot = mod.ProjectileType("BoneScythe");
				item.shootSpeed = 40;
				item.mana = 40;
				item.useStyle = 5;
            }
            else
            {
 
                item.useTime = 30;
                item.useAnimation = 30;
                item.damage = 60;
                item.UseSound = SoundID.Item20;
				item.shoot = 270;
				item.mana = 20;
				item.useStyle = 5;
            }
            return base.CanUseItem(player);
        }
 
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.altFunctionUse == 2)          //here you see an example of how to add a buff when you hit a npc with the right click attack
            {
                target.AddBuff(BuffID.Ichor, 60);
            }
            else
            {             //buff when you hit a npc with lift click
                target.AddBuff(BuffID.OnFire, 60);
            }
        }
 
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                if (player.altFunctionUse == 2)       //this is the melee effenct when you use the right click
                {
                    int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity.X += player.direction * 2f;
                    Main.dust[dust].velocity.Y += 0.2f;
                }
                else
                {                                            //and this is the melee effect when you use left click
                    int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
                    Main.dust[dust].noGravity = true;
                }
            }
        }
 
 
    }
}