using ofDarkandBelow.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Buffs
{
    public class EelSpiked : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            // NPC only buff so we'll just assign it a useless buff icon.
            texture = "ofDarkandBelow/Buffs/BuffTemplate";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Eel Spiked");
            Description.SetDefault("ouchie");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<SGlobalNPC>().eelSpiked = true;
        }
    }
}