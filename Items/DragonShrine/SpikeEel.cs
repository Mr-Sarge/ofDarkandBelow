using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace ofDarkandBelow.Items.DragonShrine
{
	public class SpikeEel : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracian Spike Eel");
            Tooltip.SetDefault("Fires a bone spike that sticks to enemies."
                + "\n'A creature known for launching high-velocity spikes of bone.'");
        }
        public override void SetDefaults()
		{
			item.damage = 28;
			item.ranged = true;
			item.width = 70;
			item.height = 28;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
            item.value = Item.sellPrice(0, 3, 10, 0);
            item.rare = 3;
			item.UseSound = SoundID.Item95;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("EelSpike");
			item.shootSpeed = 23f;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9, 0);
        }
    }
}
