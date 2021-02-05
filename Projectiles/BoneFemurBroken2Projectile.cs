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
    public class BoneFemurBroken2Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 5;
            projectile.height = 5;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.melee = true;
            projectile.penetrate = 3;
        }
        public int bounceAmount;
        public override void AI()
        {
            projectile.rotation += 0.25f;
            projectile.velocity.Y += 0.25f;
            if (projectile.ai[1] == 0)
            {
                bounceAmount = 3;
                projectile.ai[1] = 1;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            bounceAmount--;
            if (bounceAmount <= 0)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/FemurBreak3"));
                projectile.Kill();
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounceAmount--;
            if (bounceAmount <= 0)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/FemurBreak3"));
                projectile.Kill();
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, DustID.Blood);
                dust.position = (dust.position + projectile.Center) / 2f;
                dust.velocity += rotVector * 1.25f;
                dust.velocity *= 0.8f;
                dust.noGravity = true;
            }
        }
    }
}