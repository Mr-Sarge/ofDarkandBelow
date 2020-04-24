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
    public class MawRakProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(6);
            projectile.width = 40;
            projectile.height = 44;
            projectile.penetrate = 3;
            projectile.scale = 0.85f;
        }
        public override void AI()
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1f);
            projectile.rotation += 0.2f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("CosmicFlame"), 160);
        }
        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundLoader.customSoundType, (int)position.X, (int)position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/MawRakCatch"));
            int radius = 5;

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.2)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1f);
                    }
                }
            }
        }
    }
}