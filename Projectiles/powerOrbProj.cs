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
    public class powerOrbProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            DisplayName.SetDefault("Tesla Coil");
        }
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 58;
            projectile.penetrate = -1;
            projectile.scale = 1.0f;
            projectile.friendly = true;
            projectile.light = 0.2f;
            projectile.timeLeft = 900;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;

            if (++projectile.frameCounter >= 3)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
        }
        private int canYouLikeNotInstaKillOmega;
        public override void AI()
        {

            Lighting.AddLight(projectile.Center, 0.0f, 0.0f, 0.3f);

            if (++projectile.frameCounter >= 3)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }

            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (target.active && !target.friendly)
                {
                    float shootToX = target.Center.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.Center.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 480f && !target.friendly && target.active)
                    {
                        canYouLikeNotInstaKillOmega++;
                        if (canYouLikeNotInstaKillOmega == 60)
                        {
                            distance = 3f / distance;
                            shootToX *= distance * 5;
                            shootToY *= distance * 5;
                            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, 435, 86, 0, Main.myPlayer);
                            Main.projectile[a].friendly = true;
                            Main.projectile[a].hostile = false;
                            canYouLikeNotInstaKillOmega = 0;
                        }
                    }
                }
            }
        }
        public override void Kill(int timeLeft)
        {
         Dust.NewDust(projectile.position, projectile.width - 28, projectile.height - 28, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 20, default(Color), 1f);
        }
    }
}