<<<<<<< HEAD
using Microsoft.Xna.Framework;
=======
﻿using Microsoft.Xna.Framework;
>>>>>>> 3f912c970132cabd93a0330c60ceb9c98094fb73
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class TerrorNaginataSourSpot : ModProjectile
    {
        public override void AutoStaticDefaults()
        {
            Main.projectileTexture[this.projectile.type] = null;
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.usesIDStaticNPCImmunity = true;
            projectile.idStaticNPCHitCooldown = 15;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ownerHitCheck = true;
            projectile.hide = true;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            var spearTip = Main.projectile[(int)projectile.ai[0]];
            Vector2 spearTipDirection = spearTip.velocity;
            spearTipDirection.Normalize();

            projectile.position = spearTip.position - spearTipDirection*28;

            if (owner.itemTime == 1 || spearTip.localAI[1] > 0)
            {
                projectile.Kill();
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0]++;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 3f912c970132cabd93a0330c60ceb9c98094fb73
