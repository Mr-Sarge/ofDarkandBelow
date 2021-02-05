using ofDarkandBelow.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameInput;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.UI;
using Terraria.Utilities;
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
        public bool ire = false;
        public bool ancientAleBuff = false;
        public bool ancientAleBuffCoolDown = false;
        public bool powerOrbBuff = false;
        public bool powerOrbCooldown = false;
        public bool freakyCritActive = false;
        public bool freakyCritCoolDown = false;
        public int immovableSetBonus = 0;
        public bool immovableSetBonusReady = false;

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
            ire = false;
            ancientAleBuff = false;
            ancientAleBuffCoolDown = false;
            powerOrbBuff = false;
            powerOrbCooldown = false;
            freakyCritActive = false;
            freakyCritCoolDown = false;
            immovableSetBonusReady = false;
    }
        public override void UpdateDead()
        {
            cosmicRevivalCooldown = false;
            kingPowerCooldown = false;
            powerOrbCooldown = false;
            ancientAleBuffCoolDown = false;
            freakyCritCoolDown = false;
            immovableSetBonusReady = false;
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) // Upon hitting...
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
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) // Before dying...
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
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit) // ???
        {
            if (ire)
            {
                npc.AddBuff(mod.BuffType("DracarniumFlames"), 420);
            }
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) // On damage taken...
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
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) // On hit with projectile...
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
        public override void PostUpdate()
        {
            if (ofDarkandBelow.ODABArmorHotKey.JustPressed)
            {
                if (powerOrbBuff == true && powerOrbCooldown == false)
                {
                  player.AddBuff(mod.BuffType("powerOrb"), 900);
                  player.AddBuff(mod.BuffType("powerOrbCooldown"), 3600);
                }
                if (freakyCritActive == true && freakyCritCoolDown == false)
                {
                    int radius = 3;
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.position.X, (int)player.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/FreakActivate"));
                    player.AddBuff(mod.BuffType("FreakyCrit"), 500);
                    player.AddBuff(mod.BuffType("FreakyCritCoolDown"), 3600);
                    Vector2 position = player.Center;
                    for (int x = -radius; x <= radius; x++)
                    {
                        for (int y = -radius; y <= radius; y++)
                        {
                            int xPosition = (int)(x + position.X / 16.0f);
                            int yPosition = (int)(y + position.Y / 16.0f);

                            if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                            {
                                Dust.NewDust(player.position, player.width, player.height - 6, DustID.Blood, 0f, 5f, 150, default(Color), 1f);
                                Dust.NewDust(player.position, player.width, player.height, DustID.Blood, 0f, 0f, 150, default(Color), 1.5f);
                                Dust.NewDust(player.position, player.width, player.height + 6, DustID.Blood, 0f, 5f, 150, default(Color), 1f);
                            }
                        }
                    }
                }
            }
        }
    }
}