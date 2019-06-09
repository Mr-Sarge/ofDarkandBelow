using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ofDarkandBelow.Projectiles;
namespace ofDarkandBelow.Projectiles
{
	public class FreakKnifePlayerProj : ModProjectile
	{
        public override void SetDefaults()
        {
            projectile.CloneDefaults(318);
			projectile.width = 12;
			projectile.height = 28;
		}
	}
}