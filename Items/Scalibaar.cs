using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class Scalibaar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scalibaar");
            Tooltip.SetDefault("Right-Click for an alternate attack."
                + "\n'An ancient and powerful sword.'");
        }
        public override void SetDefaults()
        {
            item.damage = 85;
            item.shoot = (mod.ProjectileType("ScalibaarProj"));
            item.shootSpeed = 15f;
            item.melee = true;
            item.width = 66;
            item.height = 70;
            item.useTime = 37;
            item.useAnimation = 37;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(gold: 8);
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(mod.ItemType("ChildofScalibaar"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            position += muzzleOffset;
            if (player.altFunctionUse == 2)
            {
                float numberProjectiles = 2;
                float rotation = MathHelper.ToRadians(8);
            }
        return true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)     //2 is right click
            {
                item.damage = 85;
                item.shoot = (mod.ProjectileType("ScalibaarHome"));
                item.shootSpeed = 17f;
                item.melee = true;
                item.useTime = 24;
                item.useAnimation = 24;
                item.useStyle = 3;
                item.knockBack = 6;
                item.UseSound = SoundID.Item1;
                item.autoReuse = true;
            }
            else
            {
                item.damage = 85;
                item.shoot = (mod.ProjectileType("ScalibaarProj"));
                item.shootSpeed = 15f;
                item.melee = true;
                item.useTime = 37;
                item.useAnimation = 37;
                item.useStyle = 1;
                item.knockBack = 6;
                item.UseSound = SoundID.Item1;
                item.autoReuse = true;
            }
            return base.CanUseItem(player);
        }
    }
}
