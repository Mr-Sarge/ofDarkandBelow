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
	public class SoulShred : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.width = 106;
			projectile.height = 84;
			projectile.alpha = 60;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = 5;
			projectile.melee = true;
			projectile.timeLeft = 400;
		}

		public override void AI() {
           Lighting.AddLight(projectile.Center, 1f, 0.6f, 0f);
		   projectile.aiStyle = 274;
		   aiType = ProjectileID.DeathSickle;
		   projectile.rotation += 0.3f;
		   int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
		   Main.dust[dust].scale = 1f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            float Speed = 7f;  //projectile speed
            Vector2 vector8 = new Vector2(projectile.Center.X, projectile.Center.Y);
            int type = 321;  //put your projectile
            float rotation = (float)Math.Atan2(vector8.Y - (projectile.position.Y + (projectile.height * 0.5f)), vector8.X - (projectile.position.X + (projectile.width * 0.5f)));
            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
		    Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
            target.AddBuff(BuffID.OnFire, 180);    //this adds a buff to the npc hit. 210 it the time of the buff
    }
}}