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
namespace ofDarkandBelow.Projectiles.ThrowerProjectiles
{
    public class TrueAnelaceProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(182);
            projectile.width = 40;
            projectile.height = 44;
            projectile.penetrate = -1;
            projectile.scale = 0.85f;
            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 3;
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
            {
                projectile.rotation += 0.4f * (float)projectile.direction;
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 20, default(Color), 1f);
                projectile.rotation += 0.2f;
                projectile.rotation += 1.2f;
                Vector2 move = Vector2.Zero;
                float distance = 600f;
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
        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            int radius = 7;

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 32.0f);
                    int yPosition = (int)(y + position.Y / 32.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.2)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 20, default(Color), 1f);
                    }
                }
            }
        }
    }
}