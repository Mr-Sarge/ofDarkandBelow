using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Dracarnium
{
    public class DracarniumReap : ModProjectile
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Projectiles/Dracarnium/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            Main.projFrames[projectile.type] = 3;
            DisplayName.SetDefault("Dragon Reap");
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
            projectile.melee = true;
            projectile.light = 0.32f;
            projectile.timeLeft = 24;
            projectile.glowMask = customGlowMask;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.221f, 0.208f, 0.181f);  //this defines the projectile light color
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"));   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 20f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 0.8f;

            if (projectile.ai[0] == 0)
            {
                projectile.rotation = Main.rand.Next(-180, 180);
                projectile.ai[0] = 1;
            }

            if (++projectile.frameCounter >= 8)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

            target.AddBuff(mod.BuffType("DracarniumFlames"), 160);

        }
    }
}
