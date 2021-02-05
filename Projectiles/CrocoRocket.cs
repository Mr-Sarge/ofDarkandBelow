using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{	
	public class CrocoRocket : ModProjectile 
	{
	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Croco-Rocket");
		}
		public override void SetDefaults()
		{
            projectile.width = 4;               //The width of projectile hitbox
            projectile.height = 4;              //The height of projectile hitbox
            projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 55;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            projectile.light = 0.5f;            //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
            aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
        }

        //How the projectile works
        public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.5f, projectile.velocity.Y * 1.5f);
            {
                for (int i = 0; i < 120; i++)
                {
                    NPC target = Main.npc[i];
                    //If the npc is hostile
                    if (target.friendly == false && target.immortal == false)
                    {
                        //Get the shoot trajectory from the projectile and target
                        float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                        float shootToY = target.position.Y - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        //If the distance between the live targeted npc and the projectile is less than 480 pixels
                        if (distance < 140f && !target.friendly && target.active)
                        {
                            //Divide the factor, 3f, which is the desired velocity
                            distance = 3f / distance;

                            //Multiply the distance by a multiplier if you wish the projectile to have go faster
                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            //Set the velocities to the shoot values
                            projectile.velocity.X = shootToX;
                            projectile.velocity.Y = shootToY;
                        }
                    }
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(2); //Generates an integer from 0 to 1
            if(rand == 0)
            {
                target.AddBuff(mod.BuffType("DracarniumFlames"), 220);
                target.AddBuff(BuffID.OnFire, 220);
                target.AddBuff(31, 220);
                target.AddBuff(69, 220);
            }
            else if (rand == 1)
            {
                owner.statLife += 10; //Gives 5 Health
				owner.HealEffect(5, true); //Shows you have healed by 5 health
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item14, projectile.position);
            Vector2 position = projectile.Center;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 0f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 3f;
            int radius = 20;     //this is the explosion radius, the highter is the value the bigger is the explosion
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 3f;
            }
        }
    }
}