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
    public class AstralArrowProj : ModProjectile
    {
        float speedX;
        float speedY;
        Vector2 position;
        public override void SetDefaults()
        {
            projectile.width = 10;  //Set the hitbox width
            projectile.height = 18;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;   //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
            projectile.light = 0.60f; //This defines the projectile light
            aiType = 1; // this is the projectile ai style . 1 is for arrows style
        }
        public int bounceAmount;
        public override void AI()
        {
            if (projectile.ai[1] == 0)
            {
                bounceAmount = 3;
                projectile.ai[1] = 1;
            }

            //red | green| blue
            Lighting.AddLight(projectile.Center, 0.4f, 0.0f, 0.4f);  //this defines the projectile light color
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1f);
            Main.dust[dust].velocity /= 30f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 1f;  //this modify the scale of the first dust
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("CosmicFlame"), 160);
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 5;

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.2)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1f);
                    }
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            int radius = 5;

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.2)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1f);
                    }
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounceAmount--;
            if (bounceAmount <= 0)
            {
                projectile.Kill();
            }
            else
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 0.5f);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
        return false;
        }
    }
}