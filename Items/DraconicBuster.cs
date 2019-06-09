using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using ofDarkandBelow;
namespace ofDarkandBelow.Items
{
	public class DraconicBuster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Draconic Buster Blade");
			Tooltip.SetDefault("Hate into Power.");
		}
		public override void SetDefaults()
		{
			item.damage = 60;
			item.melee = true;
			item.width = 100;
			item.height = 100;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 100000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		    item.shoot = 295;
			item.shootSpeed = 15f;
		}
	}
}
