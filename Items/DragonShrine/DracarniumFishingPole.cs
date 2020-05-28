using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.DragonShrine
{
    public class DracarniumFishingPole : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarnium Fishing Pole");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.HotlineFishingHook);  //This defines the fishing pole you want to clone
            item.width = 48;
            item.height = 42;
            item.fishingPole = 28; //this defines the fishing pole fishing power          
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 3;
            item.shoot = mod.ProjectileType("DracarniumPoleProj");  //This defines what type of projectile this item will shot
            item.shootSpeed = 13f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DracarniumIngot"), 10);
            recipe.AddIngredient(ItemID.ReinforcedFishingPole, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}