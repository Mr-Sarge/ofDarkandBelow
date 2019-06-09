using Terraria;
using Terraria.ModLoader;
using ofDarkandBelow.NPCs;
namespace ofDarkandBelow.Buffs
{
	public class LecherousBite : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Lecherous Bite");
			Description.SetDefault("The Blood Flows!");
			Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
		{
            player.lifeRegen = -15;
		}
		        public override void Update(NPC npc, ref int buffIndex)
        {
        }
	}
}