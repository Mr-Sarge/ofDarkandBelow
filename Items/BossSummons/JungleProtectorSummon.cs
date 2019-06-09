using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Items.BossSummons
{
    public class JungleProtectorSummon : ModItem
{
        #region .     Properties     .

        #endregion .     Properties     .

        #region .   Public Methods   .

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Protector Summon");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.consumable = true;
            item.maxStack = 1;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("JungleProtector"));

            return true;
        }

        #endregion .   Public Methods   .

        #region . Overridden Methods .

        #endregion . Overridden Methods .

        #region .   Private Methods  .

        #endregion .   Private Methods  .

    }
}
