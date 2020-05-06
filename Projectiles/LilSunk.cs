using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class LilSunk : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lil Sunk");
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            aiType = 388;
            projectile.netImportant = true;
            projectile.width = 53;
            projectile.height = 42;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0f;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.aiStyle = 66;
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
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
                modPlayer.lilSunkMinion = false;
            }
            if (modPlayer.lilSunkMinion)
            {
                projectile.timeLeft = 2;
            }
        }

        public override bool PreAI()
        {
            if (projectile.velocity.X >= 0)
            {
                projectile.spriteDirection = -1;
            }
            else if (projectile.velocity.X < 0)
            {
                projectile.spriteDirection = 1;
            }
            CheckActive();
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
            return true;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.X * 0.07f;
            return;
        }
    }
}