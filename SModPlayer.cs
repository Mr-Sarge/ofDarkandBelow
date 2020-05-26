using ofDarkandBelow.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace ofDarkandBelow
{
    public class SModPlayer : ModPlayer
    {
        public bool cosmicRevival = false;
        public bool cosmicRevivalCooldown = false;
        public bool cosmicManaRegen = false;
        public bool cosmicEscapeeEffect = false;
        public bool harasserHeal = false;
        public bool sunkenCrownEffect = false;
        public bool kingPowerCooldown = false;
        public bool fallenRoyaltySetBonus = false;
        public bool behemothEffect = false;
        public bool dracarniumInfusion = false;
        public override void ResetEffects()
        {
            cosmicRevival = false;
            cosmicRevivalCooldown = false;
            harasserHeal = false;
            behemothEffect = false;
            cosmicManaRegen = false;
            cosmicEscapeeEffect = false;
            sunkenCrownEffect = false;
            kingPowerCooldown = false;
            fallenRoyaltySetBonus = false;
            dracarniumInfusion = false;
        }
        public override void UpdateDead()
        {
            cosmicRevivalCooldown = false;
            kingPowerCooldown = false;
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (behemothEffect)
            {
                target.AddBuff(mod.BuffType("HorrorHemorrhage"), 240);
            }
            if (fallenRoyaltySetBonus == true && kingPowerCooldown == false)
            {
                player.AddBuff(mod.BuffType("KingPower"), 480);
                player.AddBuff(mod.BuffType("KingPowerCooldown"), 1800);
            }
            if (dracarniumInfusion)
            {
                target.AddBuff(mod.BuffType("DracarniumFlames"), 240);
            }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (cosmicRevival == true && cosmicRevivalCooldown == false)
            {
                player.statLife = 50;
                player.HealEffect(50);
                player.immune = true;
                player.immuneTime = player.longInvince ? 180 : 120;
                for (int k = 0; k < player.hurtCooldowns.Length; k++)
                {
                    player.hurtCooldowns[k] = player.longInvince ? 180 : 120;
                }
                Main.PlaySound(SoundLoader.customSoundType, (int)player.position.X, (int)player.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/CosmicRevival"));
                player.AddBuff(59, 600);
                player.AddBuff(mod.BuffType("CosmicRevivalCooldown"), 9000);
                CombatText.NewText(player.getRect(), Colors.RarityPurple, "PRIMORDIAL REVIVAL", true, false);
                int radius = 5;

                for (int x = -radius; x <= radius; x++)
                {
                    for (int y = -radius; y <= radius; y++)
                    {
                        int xPosition = (int)(x + player.position.X / 16.0f);
                        int yPosition = (int)(y + player.position.Y / 16.0f);

                        if (Math.Sqrt(x * x + y * y) <= radius + 0.2)
                        {
                            Dust.NewDust(player.position, player.width, player.height, mod.DustType("CosmicDust"), player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 20, default(Color), 1f);
                        }
                    }
                }
            return false;
            }
            return true;
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (sunkenCrownEffect == true && player.statLife <= player.statLifeMax * 0.50f)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("LilSunk")] == 0)
                {
                    int lilsunkdamage = player.statLifeMax / 6;
                    CombatText.NewText(player.getRect(), Colors.RarityBlue, "'Fly my Pretty!'", true, false);
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("LilSunk"), lilsunkdamage, 0, player.whoAmI);
                    player.AddBuff(mod.BuffType("LilSunk"), 9000);
                }
            }
            if (cosmicManaRegen == true)
            {
                int manaSteal = damage * (int)1.2;
                player.statMana += manaSteal;
                player.ManaEffect(manaSteal);
            }
            if (cosmicEscapeeEffect == true)
            {
                player.AddBuff(mod.BuffType("CosmicEscapee"), 240);
            }
            return true;
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (dracarniumInfusion)
            {
                target.AddBuff(mod.BuffType("DracarniumFlames"), 240);
            }
            if (fallenRoyaltySetBonus == true && kingPowerCooldown == false)
            {
                player.AddBuff(mod.BuffType("KingPower"), 480);
                player.AddBuff(mod.BuffType("KingPowerCooldown"), 1800);
            }
            if (behemothEffect)
            {
                target.AddBuff(mod.BuffType("HorrorHemorrhage"), 240);
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