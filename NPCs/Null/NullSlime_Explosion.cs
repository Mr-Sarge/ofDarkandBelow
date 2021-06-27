using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.NPCs.Null
{
    public class NullSlime_Explosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            DisplayName.SetDefault("Null Slimesplosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 112;
            projectile.height = 102;
            projectile.scale = 1f;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.hide = false;
            projectile.light = 0.45f;
            projectile.timeLeft = 20;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.0f, 0.25f, 0.0525f);
            int dust = Dust.NewDust(projectile.position, projectile.width + 20, projectile.height + 20, mod.DustType("NullFire"));
            Main.dust[dust].velocity /= 20f;
            Main.dust[dust].scale = 0.8f;

            if (projectile.ai[0] == 0)
            {
                Main.PlaySound(SoundID.Item14, (int)projectile.position.X, (int)projectile.position.Y);
                projectile.ai[0] = 1;
            }

            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (target.type == ModContent.NPCType<NullSlime>())
            {
            damage *= 50;
            }
        }
    }
}
