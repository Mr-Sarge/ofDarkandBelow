using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.Pets
{
	public class BabyNullEaterPet : ModProjectile
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Baby Null");
			Main.projFrames[projectile.type] = 2;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		public override void AI() {
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2) {
					projectile.frame = 0;
				}
			}
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.dead) {
				modPlayer.babyNull = false;
			}
			if (modPlayer.babyNull) {
				projectile.timeLeft = 2;
			}
		}
	}
}