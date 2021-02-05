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
    public class TrueShadTipProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(45);
            projectile.width = 22;
            projectile.height = 22;
            projectile.penetrate = -1;
            projectile.scale = 0.85f;
            projectile.friendly = true;
            projectile.timeLeft = 360;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.alpha = 80;
            projectile.scale = 2f;
        }
        public override void AI()
        {
            projectile.rotation += 0.4f * (float)projectile.direction;
            int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 163, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
            Main.dust[DustID4].noGravity = true;
            projectile.rotation += 0.4f * (float)projectile.direction;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            target.AddBuff(39, 360); // BuffID.CursedInferno
        }
        public override void Kill(int TimeLeft)
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 163, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 20, default(Color), 1f);
        }
    }
}