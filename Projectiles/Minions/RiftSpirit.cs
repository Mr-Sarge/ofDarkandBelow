using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Minions
{
    //ported from my tAPI mod because I'm lazy
    public class RiftSpirit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 5;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 24;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0.5f;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.aiStyle = 66;
            //inertia = 20f;
        }

        public void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.dead)
            {
                modPlayer.riftspiritMinion = false;
            }
            if (modPlayer.riftspiritMinion)
            {
                projectile.timeLeft = 2;
            }
        }

        public override bool PreAI()
        {
            CheckActive();
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 17, Alpha: 100);
            Main.dust[dust].velocity.Y -= 1.2f;
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
            if (++projectile.frameCounter >= 8)
            {
                if (++projectile.frame >= 5)
                {
                    projectile.frame = 0;
                }
                projectile.frameCounter = 0;
            }
            return true;
        }
}
}