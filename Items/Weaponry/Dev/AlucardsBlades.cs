using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Weaponry.Dev
{
    public class AlucardsBlades : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alucard's Blades");
            Tooltip.SetDefault("Fires a spread of Life-Stealing Blades,"
            +"\nBlades inflict Venom and Shadowflame."
            + "\n'Drink the Blood of God!'"
            + "\nDev Weapon: Jsoull");
        }

        public override void SetDefaults()
        {
            item.damage = 150;
            item.melee = true;
            item.width = 76;
            item.height = 76;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = Item.sellPrice(gold: 40);
            item.rare = 10;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AlucardBite");
            item.shootSpeed = 22f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BeserkerCrystal"), 10);
            recipe.AddIngredient(ItemID.MagicDagger);
            recipe.AddIngredient(ItemID.ShadowFlameKnife, 1);
            recipe.AddIngredient(ItemID.ThrowingKnife, 100);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
