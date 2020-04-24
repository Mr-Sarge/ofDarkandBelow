using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.NullItems
{
    public class RiftSpirit : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(388);
            aiType = 388;
            projectile.netImportant = true;
            projectile.width = 26;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0.5f;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.aiStyle = 66;
            
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
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, mod.DustType("NullDust"), Alpha: 50);
            Main.dust[dust].velocity.Y -= 1.2f;
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("BelowZero"), 160);   //this make so when the projectile/flame hit a npc, gives it the buff  onfire , 80 = 3 seconds
        }
    }
}