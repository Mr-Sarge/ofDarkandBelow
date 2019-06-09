using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class HottancoolArrowProj : ModProjectile
    {
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Molten and Frozen Arrow");
			Main.projFrames[projectile.type] = 3;
		}
        public override void SetDefaults()
        {
            projectile.width = 8;  //Set the hitbox width
            projectile.height = 8;  //Set the hitbox height
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
        public override void AI()
        {
            //red | green| blues
            Lighting.AddLight(projectile.Center, 0.4f, 0.0f, 0.4f);  //this defines the projectile light color
            int dust= Dust.NewDust(projectile.position, projectile.width, projectile.height, 36);   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 30f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 1f;  //this modify the scale of the first dust
			int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16);   //this adds a vanilla terraria dust to the projectile
            Main.dust[dust].velocity /= 30f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 1f;  //this modify the scale of the first dust
			if (++projectile.frameCounter >= 4) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 3) {
					projectile.frame = 0;
			if (++projectile.frameCounter >= 4) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 3) {
					projectile.frame = 0;
				}
			}
        }}}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

            target.AddBuff(BuffID.OnFire, 180);    //this adds a buff to the npc hit. 210 it the time of the buff
			target.AddBuff(BuffID.Frostburn, 180);
        }
    }
}