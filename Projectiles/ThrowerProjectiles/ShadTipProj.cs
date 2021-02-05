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
    public class ShadTipProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            projectile.aiStyle = 304;
            int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.3f, 20, default(Color), 0.8f);
            Main.dust[DustID4].noGravity = true;
            projectile.rotation += 0.4f * (float)projectile.direction;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
        }
        public override void Kill(int TimeLeft)
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 20, default(Color), 1f);
        }
    }
}
