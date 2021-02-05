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
namespace ofDarkandBelow.Projectiles.Dracarnium
{
	public class DracarniumSpikesProj : ModProjectile
	{
		public bool stopSpinning; // This is a public variable to allow me to disable certain things when a block is hit.
		public bool toBufforNotToBuff; // This is a public variable that allows me to control when buffs are applied by the weapon.
		public bool touchedMyTalala; // This is a public variable that is used to continue zeroing the velocity upon touching a block.
		public bool peneHold; // This is a public variable to make the penetration code not repeat, and never die.
		public int peneTest; // This is a public variable to allow me to use a infinite piercing projectile, and still give durability.
		public override void SetDefaults()
		{
			// Clones some basic AI code from throwing knives for gravity, and other various things.
			projectile.CloneDefaults(48);

			// While our sprite is larger than the values below, we set them lower to allow the sprite to clip into blocks. Simply for looks.
			projectile.width = 22; 
			projectile.height = 20;

			/* We will be setting the penetration to -1, this is so we can set our own variable above to set a custom penetration.
			 We do this so that we can allow the projectile to, later, expand and actually cause the explosion. */
			projectile.penetrate = -1;

			// The timeleft will always be 60 is equal to 1 seconds. This case has a 8 second fuse.
			projectile.timeLeft = 483;

			// These two lines make the projectile do thrown damage, and be friendly to the player. So we don't hurt ourself.
			projectile.thrown = true;
			projectile.friendly = true;

			// This forces a custom invinciblility frame timer, meaning it is damages slower and won't set off the public immunity frames.
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 40;

			// We set all of our variables to be their default values when they are spawned, just for safe measure.
			stopSpinning = false;
			toBufforNotToBuff = false;
			touchedMyTalala = false;
			peneHold = false;
			peneTest = 0;

			// This is simply here as the exampleMod bomb code had it, and it doesn't harm anything. It's on thin ice.
			drawOffsetX = 5;
			drawOriginOffsetY = 5;
		}
		public override void AI()
		{
			if (touchedMyTalala == true)
            {
				projectile.velocity = Vector2.Zero;

				// Sets the velocity to zero repeatedly upon a returning true.
			}
			if (stopSpinning == false && projectile.timeLeft > 3)
			{
                projectile.rotation += 0.1f * (float)projectile.direction;
				
				// Makes the projectile spin until stopSpinning becomes true, or there is 3 or less seconds left.
			}
			if (projectile.timeLeft <= 3)
			{
				// This whole code, upon the projectile reaching the last three ticks of it's lifespan runs all of this.

				projectile.alpha = 255;
				// This hides the projectile from sight.

				projectile.rotation = 0;
				// This sets the rotation to be a perfect 9 degree angle, to avoid weird hitboxes.

				projectile.tileCollide = false;
				// This makes it so the projectile can explode without blocks being in the way.

				projectile.velocity = Vector2.Zero;
				// This just sets the velocity to zero, if it hadn't been done already.

				projectile.localNPCHitCooldown = 3;
				// This makes enemies only damaged every three ticks, which means they will only take damage once.

				projectile.position.X = projectile.position.X + 7.5f * 16;
				projectile.position.Y = projectile.position.Y + 7.5f * 16;
				projectile.position = projectile.Center;
				/* This fixes the off-set issue that is present with projectiles expanding, 
				 * by taking the 7.5 block offset, and multiplying it by 16.
				 * This is then added to the projectile position, overwriting it's
				 * current position. Always remember, 16 units is equal to one block. */

				projectile.damage = 15;
				projectile.knockBack = 10;
				// Sets the damage and knockback of the projectile; how much damage it's going to do and how far it knocksback.

				projectile.width = 100;
				projectile.height = 100;
				// These values here increases the size of the explosion, it's best to go for equal values or squares.

				toBufforNotToBuff = true;
				// Allows to projectile to begin applying buffs.

				projectile.Center = projectile.position;
				projectile.position.X = projectile.position.X - 7.5f * 16;
				projectile.position.Y = projectile.position.Y - 7.5f * 16;
				// Don't need to explain much, just inverses our previous lines above.

			}
			int DustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
			Main.dust[DustID2].noGravity = true;
			// Makes the projectile have some dust follow it around while flying, with no gravity.

			return;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			/* Upon hitting a block, the following things will happen:
			 * - The velocity will be set to zero in all directions.
			 * - The wall checking boolean will be set to true, which will continue to set the velocity to zero.
			 * - The stop spinning boolean will be set to true, making the spinning code stop. */

			projectile.velocity = Vector2.Zero;
			touchedMyTalala = true;
			stopSpinning = true;

			return false;
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
			if (peneTest < 4)
            {
				// If it has not penetrated for times, then it will add a value on to state it has done so.
				peneTest += 1;
            }
			if (toBufforNotToBuff == true || peneTest >= 4)
            {
				// If allowed to buff or the penetration is 4 or greater, it will apply our debuff.
				target.AddBuff(mod.BuffType("DracarniumFlames"), 360);
			}
			if (peneTest >= 4 && peneHold == false)
			{
				/* If it has penetrated 4 or more time, and has not ran this code before it will:
				 * - The velocity will be set to zero in all directions.
				 * - Reduces the projectile life time down to 3, causing the explosion to happen.
				 * - Sets the hit cooldown to three, pre-maturely.
				 * - Gives the ability for hits to apply debuffs.
				 * - Makes this code unable to run again.
				 */

				projectile.velocity = Vector2.Zero;
				projectile.timeLeft = 3;
				projectile.localNPCHitCooldown = 3;
				toBufforNotToBuff = true;
				peneHold = true;

			}
		}
		public override void Kill(int timeLeft)
		{
			// Does something dust based.
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Spawns the fire dust on explosion.
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("DracarniumFlamesDust"), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
			// Spawns large smoke gore on explosion.
			for (int g = 0; g < 2; g++)
			{
				int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}
			// Plays the explosion sound.
			Main.PlaySound(SoundID.Item14, (int)projectile.Center.X, (int)projectile.Center.Y);
		}
	}
}