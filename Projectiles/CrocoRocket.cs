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
			projectile.width = 22; //Set the hitbox width
			projectile.height = 32; //Set the hitbox height
			projectile.timeLeft = 120; //The amount of time the projectile is alive for
			projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.ranged = true; //Tells the game whether it is a ranged projectile or not
			projectile.aiStyle = 340; //How the projectile works, 0 makes the projectile just go straight towards your cursor
		}
		
		//How the projectile works
		public override void AI()
        {
		    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.light = 0.9f; //Lights up the whole room
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.5f, projectile.velocity.Y * 1.5f);
            }
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(2); //Generates an integer from 0 to 1
            if(rand == 0)
            {
                n.AddBuff(30, 180); //On Fire! debuff for 3 seconds
            }
            else if (rand == 1)
            {
                owner.statLife += 10; //Gives 5 Health
				owner.HealEffect(5, true); //Shows you have healed by 5 health
            }
        }
        public override void Kill(int timeLeft)
        {
 
            Vector2 position = projectile.Center;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 0f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 3f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;  
            int radius = 20;     //this is the explosion radius, the highter is the value the bigger is the explosion
 
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
				}
			}
		}
	}
}