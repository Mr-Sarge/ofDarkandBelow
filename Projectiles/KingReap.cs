using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class KingReap : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3;
            DisplayName.SetDefault("Kingly Reap");
        }

        public override void SetDefaults()
        {
            projectile.width = 62;
            projectile.height = 96;
            projectile.scale = 0.8f;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = false;
            projectile.magic = true;
            projectile.alpha = 150;
            projectile.timeLeft = 15;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.0f, 0.0f, 0.3f);  //this defines the projectile light color
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16);   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 20f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 0.8f;

            if (projectile.ai[0] == 0)
            {
                projectile.rotation = Main.rand.Next(-100, 100);
                projectile.ai[0] = 1;
            }

            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}
