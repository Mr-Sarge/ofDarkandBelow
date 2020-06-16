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
using ofDarkandBelow.Projectiles.Dracarnium;

namespace ofDarkandBelow.Projectiles.Dracarnium
{
    public class DracarniumOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dracarnium Orb");
        }
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.ranged = false;
            projectile.magic = true;
            projectile.melee = false;
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
            projectile.light = 0.60f; //This defines the projectile light
            aiType = ProjectileID.Bullet;
            projectile.hide = true;
        }
        public override void AI()
        {
            int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.8f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
            Main.dust[DustID2].noGravity = true;
            int DustID3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.6f, projectile.velocity.Y * 0.05f, 100, default(Color), 1.5f);
            Main.dust[DustID3].noGravity = true;
            int DustID4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.02f, 100, default(Color), 1.2f);
            Main.dust[DustID4].noGravity = true;
            if (Main.rand.NextBool(9))
            {
                float Speed = 2f;
                Vector2 vector8 = new Vector2(projectile.position.X + Main.rand.Next(-20, 20), projectile.position.Y + Main.rand.Next(-20, 20));
                int damage = projectile.damage / 3;
                int type = mod.ProjectileType("DracarniumReap");  //put your projectile
                float rotation = Main.rand.Next(-180, 180);
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

            target.AddBuff(mod.BuffType("DracarniumFlames"), 360);    //this adds a buff to the npc hit. 210 it the time of the buff

        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 4) * 2, -projectile.velocity.Y + Main.rand.Next(-3, 3) * 2)), mod.ProjectileType("DracarniumSpark"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 3) * 2, -projectile.velocity.Y + Main.rand.Next(-3, 3) * 2)), mod.ProjectileType("DracarniumSpark"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
            Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 5) * 2, -projectile.velocity.Y + Main.rand.Next(-3, 3) * 2)), mod.ProjectileType("DracarniumSpark"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
            int radius = 10;
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                    {
                        Dust.NewDust(position, 54, 54, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                    }
                }
            }
        }
    }
}