using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class ScalibaarHome : ModProjectile
    {
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Scalibaar Smashed");
		}
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.ranged = false;
			projectile.magic = false;
			projectile.melee = true;
            projectile.tileCollide = false;
            projectile.alpha = 120;
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 200; //The amount of time the projectile is alive for
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 11f)
            {
                vector *= 10f / magnitude;
            }
        }
        public override void AI()
        {
		projectile.rotation += 1.2f;
            Vector2 move = Vector2.Zero;
            float distance = 300f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && !Main.npc[k].immortal)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }
	    }
    }
}