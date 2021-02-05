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
    public class BoneFemurBroken1Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Femur Shard");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 11;
            projectile.height = 11;
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
                bounceAmount = 4;
                projectile.ai[1] = 1;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            bounceAmount--;
            if (bounceAmount <= 0)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/FemurBreak2"));
                projectile.Kill();
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounceAmount--;
            if (bounceAmount <= 0)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/FemurBreak2"));
                projectile.Kill();
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 3) * 4, -projectile.velocity.Y * 2)), mod.ProjectileType("BoneFemurBroken2Projectile"), projectile.damage / 2, projectile.knockBack / 2, projectile.owner, 0, 1);
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 3) * 4, -projectile.velocity.Y * 2)), mod.ProjectileType("BoneFemurBroken2Projectile"), projectile.damage / 2, projectile.knockBack / 2, projectile.owner, 0, 1);
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}