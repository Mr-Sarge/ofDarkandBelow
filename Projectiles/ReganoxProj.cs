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
    public class ReganoxProj : ModProjectile
    {
        float speedX;
        float speedY;
        Vector2 position;
        public override void SetDefaults()
        {
            projectile.width = 38;  //Set the hitbox width
            projectile.height = 38;  //Set the hitbox height
            projectile.aiStyle = 0; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;   //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
            projectile.light = 0.60f; //This defines the projectile light
            aiType = ProjectileID.Bullet; // this is the projectile ai style . 1 is for arrows style
        }
        public int bounceAmount;
        public override void AI()
        {
            if (projectile.ai[1] == 0)
            {
                bounceAmount = 3;
                projectile.ai[1] = 1;
            }
            projectile.rotation += 0.5f;
            //red | green| blue
            Lighting.AddLight(projectile.Center, 0.0f, 0.0f, 0.45f);  //this defines the projectile light color
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item10, (int)position.X, (int)position.Y);
            if (projectile.penetrate <= 1)
            {
                Gore.NewGore(projectile.position, -projectile.velocity, mod.GetGoreSlot("Gores/ReganoxProjBroke1"), 1f);
                Gore.NewGore(projectile.position, -projectile.velocity, mod.GetGoreSlot("Gores/ReganoxProjBroke2"), 1f);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 3) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 2) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 4) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 2) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                projectile.Kill();
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                Gore.NewGore(projectile.position, -projectile.velocity, mod.GetGoreSlot("Gores/ReganoxProjBroke1"), 1f);
                Gore.NewGore(projectile.position, -projectile.velocity, mod.GetGoreSlot("Gores/ReganoxProjBroke2"), 1f);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 3) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 2) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-2, 4) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                Projectile.NewProjectile((new Vector2(projectile.Center.X, projectile.Center.Y)), (new Vector2(-projectile.velocity.X + Main.rand.Next(-3, 2) * 2, -projectile.velocity.Y + Main.rand.Next(-2, 2) * 2)), mod.ProjectileType("ReganoxShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, 1);
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                projectile.velocity *= 0.75f;
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
    }
}