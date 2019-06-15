using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Minions
{
    //ported from my tAPI mod because I'm lazy
    public class RiftSpirit : ModProjectile
    {
        private int _frameCounter;
        private int _frame;

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
            projectile.CloneDefaults(388);
            aiType = 388;
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
            _frame = 0;
            _frameCounter = 0;
            
        }

        public override bool MinionContactDamage()
        {
            return true;
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
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 17, Alpha: 50);
            Main.dust[dust].velocity.Y -= 1.2f;
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
            return true;
        }

        public override void PostAI()
        {
            if (++_frameCounter >= 8)
            {
                if (++_frame >= 5)
                {
                    _frame = 0;
                }
                _frameCounter = 0;
            }

            projectile.frameCounter = _frameCounter;
            projectile.frame = _frame;
            projectile.tileCollide = false;
        }
    }
}