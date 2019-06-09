using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
	public class CosmicBall : ModProjectile
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cosmic Fire Ball");
			Main.projFrames[projectile.type] = 5;
		}

		public override void SetDefaults() {
            projectile.width = 40;  //Set the hitbox width
            projectile.height = 80;  //Set the hitbox height
            projectile.friendly = false;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = true; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = false; //Tells the game whether or not projectile will be affected by water
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
            projectile.light = .1f; //This defines the projectile light
        }

        public override void AI() {
        {
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5) {
					projectile.frame = 0;
				}
			}}
		{
            int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 21, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
        }}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 0.9f) ;
            {
                projectile.velocity.X = oldVelocity.X * -0.9f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 0.9f) ;
            {
                projectile.velocity.Y = oldVelocity.Y * -0.9f;
            }
            return false;
        }
		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
		   target.AddBuff(mod.BuffType("CosmicFlame"), 200);
    }
}}