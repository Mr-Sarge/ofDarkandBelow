using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ofDarkandBelow.Projectiles
{
    public class PrimordialBreathMinion : ModProjectile
    {
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Feeder's Breath");
		}
        public override void SetDefaults()
        {
            projectile.width = 16;  //Set the hitbox width
            projectile.height = 16; //Set the hitbox height
            projectile.friendly = false;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = true;
            projectile.ignoreWater = true;  //Tells the game whether or not projectile will be affected by water
            projectile.tileCollide = false;
            projectile.timeLeft = 40;
            projectile.alpha = 255;
            projectile.extraUpdates = 3;
        }
 
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.45f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);   //this is the light colors
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 4f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 3f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("CosmicDust"), projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 1f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                    Main.dust[dust2].noGravity = true;
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(mod.BuffType("CosmicFlame"), 300);
        }
    }
}