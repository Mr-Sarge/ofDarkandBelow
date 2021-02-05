using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace ofDarkandBelow.Items
{
	public class GrimHarvester : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grim Harvester");
			Tooltip.SetDefault("Throws a soul-shreding, homing flame scythe."
                + "\n'Harvest the souls of your enemies.'");
        }
		public override void SetDefaults()
		{
			item.damage = 70;
            item.crit = 7;
			item.melee = true;
			item.width = 46;
			item.height = 41;
            item.scale = 1.15f;
            item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 17);
            item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/GrimHarvest");
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("SoulShred");
			item.shootSpeed = 10f;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 25);
			recipe.AddIngredient(ItemID.DeathSickle, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            position += muzzleOffset;
            return true;
        }
    }
}
