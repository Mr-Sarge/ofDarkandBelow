using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class GobblerBite : ModProjectile
    {
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Gobbler Bite");
			Main.projFrames[projectile.type] = 4;
		}
        public override void SetDefaults()
        {
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4) {
					projectile.frame = 0;
				}
			}
        {
            projectile.width = 44;  //Set the hitbox width
            projectile.height = 46;  //Set the hitbox height
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = false; //Tells the game whether or not projectile will be affected by water
            projectile.timeLeft = 60; //The amount of time the projectile is alive for
			projectile.aiStyle = 700;
			projectile.penetrate = 3;
        }}
        public override void AI()
        {
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4) {
					projectile.frame = 0;
				}
			}
        {
		    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X * 0.5f, projectile.velocity.Y * 1.5f);
        }}
			public override void Kill(int timeLeft) {
			Main.PlaySound(SoundID.NPCDeath1);
			Vector2 usePos = projectile.position;

            Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/GobblerBiteGore1"), 1f);
			Gore.NewGore(projectile.position, projectile.velocity, mod.GetGoreSlot("Gores/GobblerBiteGore2"), 1f);
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X * 0.5f, projectile.velocity.Y * 2f);
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X * 0.5f, projectile.velocity.Y * 1.5f);
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X * 0.5f, projectile.velocity.Y * 1.5f);
	    }
    }
}