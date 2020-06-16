using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Null
{
    public class NeiroplasmicCore : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neiroplasmic Core");
			Tooltip.SetDefault("Summons the Amalgamation."
            + "\nOnly usable at night.."
            + "\n'An amalgamted mess of neiroplasm.'");
		}
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.value = 100;
            item.rare = 2;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {           
            return !Main.dayTime && !NPC.AnyNPCs(mod.NPCType("Amalgamation"));
        }
        public override bool UseItem(Player player)
        {
            int num = NPC.NewNPC((int)(player.position.X + (float)(Main.rand.Next(200, 300))), (int)(player.position.Y - 0f), mod.NPCType("Amalgamation"), 0, 0f, 0f, 0f, 0f, 255);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Neiroplasm"), 40);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
