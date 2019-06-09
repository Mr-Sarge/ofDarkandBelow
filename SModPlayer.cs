
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow
{
    public class SModPlayer : ModPlayer
    {
        public bool cosmicInfliction = false;

        public override void ResetEffects()
        {
            cosmicInfliction = false;
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (cosmicInfliction)
            {
                target.AddBuff(mod.BuffType("CosmicFlame"), 180);
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (cosmicInfliction)
            {
                target.AddBuff(mod.BuffType("CosmicFlame"), 180);
            }
        }
    }
}