using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items
{
    public class StoneBuckshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Shot");
        }
        public override void SetDefaults()
        {
            item.damage = 3;
            item.ranged = true;
            item.width = 10;
            item.height = 12;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 0;
            item.shoot = mod.ProjectileType("StoneBuckshotProj");
            item.ammo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.StoneBlock, 1);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this, 10);
            recipe1.AddRecipe();
        }
    }
}
