using ofDarkandBelow.Items;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.Fishing
{
    public class DragonShrineCrate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Shrine Crate");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}


        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.rare = 3;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.createTile = ModContent.TileType<DragonShrineCrateTile>();
            item.maxStack = 999;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
		    item.consumable = true;

        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("DragonScale"));
            }
            {
                player.QuickSpawnItem(mod.ItemType("ShrineGuardShield"));
            }
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("DracarneKey"));
            }
            if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("DracarneKey"));
            }

            int choice2 = Main.rand.Next(6);
            if (choice2 == 0)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumIngot"), Main.rand.Next(1, 3));
            }
            if (choice2 == 1)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumCleaver"), 1);
            }
            if (choice2 == 2)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumIngot"), Main.rand.Next(2, 4));
            }
            if (choice2 == 3)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumIngot"), Main.rand.Next(3, 4));
            }
            if (choice2 == 4)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumDualBow"), 1);
            }
            if (choice2 == 5)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumIngot"), Main.rand.Next(4, 5));
            }
            if (choice2 == 6)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumGlaive"), 1);
            }
            if (choice2 == 7)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumIngot"), Main.rand.Next(1, 5));
            }
            if (choice2 == 8)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumStaff"), 1);
            }
            if (choice2 == 9)
            {
                player.QuickSpawnItem(mod.ItemType("DracarniumFlail"), 1);
            }
        }
    }
}
