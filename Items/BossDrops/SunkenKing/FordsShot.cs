using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossDrops.SunkenKing
{
    public class FordsShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ford's Shot");
            Tooltip.SetDefault("For use with the Wet Derringer");
        }
        public override void SetDefaults()
        {
            item.damage = 26;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 2;
            item.shoot = mod.ProjectileType("FordsShotBullet");
            item.ammo = item.type;
        }
    }
}
