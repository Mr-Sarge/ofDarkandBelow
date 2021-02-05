using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.Audio;

namespace ofDarkandBelow.Projectiles.Dracarnium
{
	public class HidepiercerProj : ModProjectile
    {
		public static short customGlowMask = 0;
		public int counter = 0;
		public int chargeLevel = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hidepiercer");
			if (Main.netMode != 2)
			{
				Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
				for (int i = 0; i < Main.glowMaskTexture.Length; i++)
				{
					glowMasks[i] = Main.glowMaskTexture[i];
				}
				glowMasks[glowMasks.Length - 1] = mod.GetTexture("Projectiles/Dracarnium/" + "HidepiercerProj_Glow");
				customGlowMask = (short)(glowMasks.Length - 1);
				Main.glowMaskTexture = glowMasks;
			}
			Main.projFrames[projectile.type] = 21;
		}

        public override void SetDefaults()
        {
			Player player = Main.player[projectile.owner]; // Set player to the projectile owner. You. If you shoot it, it will be you.
			projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
			projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
			projectile.spriteDirection = projectile.direction;
			projectile.width = 66;
            projectile.height = 96;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ranged = true;
            projectile.ignoreWater = true;
			projectile.glowMask = customGlowMask;
			projectile.alpha = 255;
		}

        public override void AI()
        {

			Player player = Main.player[projectile.owner]; // Set player to the projectile owner. You. If you shoot it, it will be you.

			float num = 1.57079637f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true); // Set vector in direction of the player.
			projectile.ai[0] += 1f;
			int num2 = 0;
			if (projectile.ai[0] >= 30f)
			{
				num2++;
			}
			if (projectile.ai[0] >= 60f)
			{
				num2++;
			}
			if (projectile.ai[0] >= 90f)
			{
				num2++;
			}
			int num3 = 24;
			int num4 = 6;
			projectile.ai[1] += 1f;
			bool flag = false;
			if (projectile.ai[1] >= num3 - num4 * num2)
			{
				projectile.ai[1] = 0f;
				flag = true;
			}
			if (projectile.ai[1] == 1f && projectile.ai[0] != 1f)
			{
				Vector2 vector2 = Vector2.UnitX * 4f;
				vector2 = vector2.RotatedBy(projectile.rotation - 1.57079637f, default);
				Vector2 value = projectile.Center + vector2;
				for (int i = 0; i < 3; i++)
				{
					int num5 = Dust.NewDust(value - Vector2.One * 8f, 16, 16, mod.DustType("CosmicDust"), projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 100, default, 1f);
					Main.dust[num5].position.Y -= 0.3f;
					Main.dust[num5].velocity *= 0.66f;
					Main.dust[num5].noGravity = true;
					Main.dust[num5].scale = 1.4f;
				}
			}
			if (flag && Main.myPlayer == projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
					Vector2 vector3 = vector;
					Vector2 value2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - vector3;
					if (player.gravDir == -1f)
					{
						value2.Y = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - vector3.Y;
					}
					Vector2 vector4 = Vector2.Normalize(value2);
					if (float.IsNaN(vector4.X) || float.IsNaN(vector4.Y))
					{
						vector4 = -Vector2.UnitY;
					}
					vector4 *= scaleFactor;
					if (vector4.X != projectile.velocity.X || vector4.Y != projectile.velocity.Y)
					{
						projectile.netUpdate = true;
					}
					projectile.velocity = vector4;
					float scaleFactor2 = 14f;
					int num7 = 7;
				
					vector3 = projectile.Center + new Vector2(Main.rand.Next(-num7, num7 + 1), Main.rand.Next(-num7, num7 + 1));
					Vector2 vector5 = Vector2.Normalize(projectile.velocity) * scaleFactor2;
					vector5 = vector5.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default);
					if (float.IsNaN(vector5.X) || float.IsNaN(vector5.Y))
					{
						vector5 = -Vector2.UnitY;
					}
				}
			}
			projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
			projectile.rotation = projectile.velocity.ToRotation() + num;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			projectile.alpha = 0;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.direction, projectile.velocity.X * projectile.direction);

			counter++;

			if (counter >= 180) // At about two seconds, it will be complete, and ready the black arrow.
			{
				Lighting.AddLight(projectile.Center, 0.67f, 0.13f, 0.88f);
				chargeLevel = 4;
				projectile.frame = 20;
			}
			else if (counter >= 120) // At 1 and a half seconds, it will quadruple in damage.
			{
				Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 101);
				chargeLevel = 3;
				Lighting.AddLight(projectile.Center, 0.67f, 0.13f, 0.88f);
				if (++projectile.frameCounter >= 6)
				{
					projectile.frameCounter = 0;
					if (++projectile.frame >= 21)
					{
						projectile.frame = 10;
					}
				}
			}

            else if (counter >= 90)  // At 1 second, it will begin to triple damage.
			{
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 101);
                chargeLevel = 2;
				Lighting.AddLight(projectile.Center, 0.67f, 0.13f, 0.88f);
				if (++projectile.frameCounter >= 6)
				{
					projectile.frameCounter = 0;
					if (++projectile.frame >= 10)
					{
						projectile.frame = 3;
					}
				}
			}

            else if (counter >= 60)  // At half a second, it will begin to double damage.
			{
                chargeLevel = 1;
				Lighting.AddLight(projectile.Center, 0.67f, 0.13f, 0.88f);
				if (++projectile.frameCounter >= 6)
				{
					projectile.frameCounter = 0;
					if (++projectile.frame >= 4)
					{
						projectile.frame = 1;
					}
				}
			}

            else if (counter < 60) // Until half a second, it will not do anything special.
            {
                chargeLevel = 0;
				if (++projectile.frameCounter >= 6)
                {
					projectile.frameCounter = 0;
					if (++projectile.frame >= 1)
                    {
						projectile.frame = 0;
                    }
                }
            }
			else
            {

            }

            if (!player.channel)
			{
				projectile.Kill();
				player.itemTime = 24;
				player.itemAnimation = 24;
			}
        }

        public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
            if (projectile.owner == Main.myPlayer)
            {
				float num1 = 12f;
				Vector2 vector2 = new Vector2(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f);
				float f1 = Main.mouseX + Main.screenPosition.X - vector2.X;
				float f2 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
				if (player.gravDir == -1.0)
					f2 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector2.Y;
				float num4 = (float)Math.Sqrt(f1 * (double)f1 + f2 * (double)f2);
				float num5;
				if (float.IsNaN(f1) && float.IsNaN(f2) || f1 == 0.0 && f2 == 0.0)
				{
					f1 = player.direction;
					f2 = 0.0f;
					num5 = num1;
				}
				else
					num5 = num1 / num4;
				float SpeedX = f1 * num5;
				float SpeedY = f2 * num5;
                switch (chargeLevel)
                {
                    case 0:
						Main.PlaySound(SoundID.Item5, (int)projectile.position.X, (int)projectile.position.Y);
						Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX * 4, SpeedY * 4, mod.ProjectileType("DracarniumArrow"), projectile.damage, 1f, player.whoAmI);
						//Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, ModContent.ProjectileType<Shot>(), projectile.damage, 1f, player.whoAmI);
						break;
					case 1:
						Main.PlaySound(SoundID.Item5, (int)projectile.position.X, (int)projectile.position.Y);
                        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX * 4, SpeedY * 4, mod.ProjectileType("DracarniumArrow"), projectile.damage * 2, 1f, player.whoAmI);
						//Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, ModContent.ProjectileType<Shot>(), projectile.damage * 2, 1f, player.whoAmI);
						break;
					case 2:
						Main.PlaySound(SoundID.Item5, (int)projectile.position.X, (int)projectile.position.Y);
                        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX * 4, SpeedY * 4, mod.ProjectileType("DracarniumArrow"), projectile.damage * 4, 1f, player.whoAmI);
						//Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, ModContent.ProjectileType<Shot>(), projectile.damage * 2, 1f, player.whoAmI);
						break;
					case 3:
						Main.PlaySound(SoundID.Item5, (int)projectile.position.X, (int)projectile.position.Y);
						Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX * 4, SpeedY * 4, mod.ProjectileType("DracarniumArrow"), projectile.damage * 6, 1f, player.whoAmI);
						//Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, ModContent.ProjectileType<Shot>(), projectile.damage * 2, 1f, player.whoAmI);
						break;
					case 4:
						Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 88);
                        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX * 4, SpeedY * 4, mod.ProjectileType("BlackArrow"), projectile.damage * 10, 1f, player.whoAmI);
						//Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, ModContent.ProjectileType<Charged>(), projectile.damage * 6, 1f, player.whoAmI);
						break;
                }
				player.itemTime = 24;
				player.itemAnimation = 24;
			}
        }
    }
}
