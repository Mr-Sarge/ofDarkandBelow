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
	public class BoneBite1 : ModProjectile
	{
        public override void SetDefaults()
        {
			projectile.width = 22;
			projectile.height = 22;
			projectile.alpha = 60;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.melee = false;
			projectile.thrown = false;
			projectile.timeLeft = 400;
        }
		public override void AI() {
		projectile.rotation += 0.6f;
	}
}}