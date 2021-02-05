using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
	public class TerrorBreath : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Terror's Breath");     //The English name of the projectile
		}

		public override void SetDefaults() {
			projectile.width = 4;               //The width of projectile hitbox
			projectile.height = 4;              //The height of projectile hitbox
			projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 45;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
		}
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood);
            Main.dust[dust].scale = 1f;
            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
            Main.dust[dust2].scale = 0.7f;
            int dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood);
            Main.dust[dust3].scale = 0.4f;
        }
        public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
			target.AddBuff(mod.BuffType("DracarniumFlames"), 220);
            target.AddBuff(BuffID.OnFire, 220);
            target.AddBuff(31, 220);
            target.AddBuff(69, 220);
        }
	}
}