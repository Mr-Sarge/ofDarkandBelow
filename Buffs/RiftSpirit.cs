using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Buffs
{
	public class RiftSpirit : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Rift Spirit");
			Description.SetDefault("Beware the forces of the Null.");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("RiftSpirit")] > 0) {
				modPlayer.riftspiritMinion = true;
			}
			if (!modPlayer.riftspiritMinion) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}