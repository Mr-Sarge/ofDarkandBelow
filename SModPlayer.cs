using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ofDarkandBelow
{
    public class SModPlayer : ModPlayer
    {
        public bool cosmicInfliction = false;
        public bool harasserHeal = false;
        public bool behemothEffect = false;
        public override void ResetEffects()
        {
            cosmicInfliction = false;
            harasserHeal = false;
            behemothEffect = false;
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (cosmicInfliction)
            {
                target.AddBuff(mod.BuffType("CosmicFlame"), 180);
            }
            if (behemothEffect)
            {
                target.AddBuff(mod.BuffType("HorrorHemorrhage"), 240);
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (behemothEffect)
            {
                target.AddBuff(mod.BuffType("HorrorHemorrhage"), 240);
            }
            if (cosmicInfliction)
            {
                target.AddBuff(mod.BuffType("CosmicFlame"), 180);
            }
            if (harasserHeal)
                if (crit == true)

                {
                    player.statLife += 50;
                    player.HealEffect(50, true);
                }
        }
    }

}