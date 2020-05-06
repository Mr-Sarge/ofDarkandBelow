using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Buffs
{
	public class LilSunk : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Lil Sunk");
			Description.SetDefault("She has come in your time of need!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("LilSunk")] > 0) {
				modPlayer.lilSunkMinion = true;
			}
			if (!modPlayer.lilSunkMinion) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
                if (player.statLife >= player.statLifeMax * 0.5f)
                {
                    player.DelBuff(buffIndex);
                }
                else
                {
                    player.buffTime[buffIndex] = 18000;
                }
			}
        }
	}
}