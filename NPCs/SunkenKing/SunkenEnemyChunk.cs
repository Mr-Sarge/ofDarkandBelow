using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using ofDarkandBelow.Projectiles;

namespace ofDarkandBelow.NPCs.SunkenKing
{
	public class SunkenEnemyChunk : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunken Chunk");
        }
        public override void SetDefaults()
        {
            npc.width = 70;
            npc.height = 70;
            npc.scale = 0.85f;
            npc.friendly = false;
            npc.damage = 40;
            npc.defense = 0;
            npc.lifeMax = 40;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath32;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.alpha = 0;
            npc.value = 0f;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (npc.ai[0] == 0)
            {
                npc.velocity = npc.DirectionTo(player.Center) * 5;
                npc.ai[0] = 1;
            }

            npc.rotation += 0.1f;
            Point point = npc.Center.ToTileCoordinates();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    {
                        if (Main.tile[point.X + x, point.Y + y].type != 0 && Main.tile[point.X + x, point.Y + y].active());
                        {
                            npc.life = 0;
                            npc.active = false;
                            npc.alpha = 255;
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SunkenSoldierNew"));
                            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunkBit1"), 1f);
                            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunkBit2"), 1f);
                            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SunkenChunkBit3"), 1f);
                            Main.PlaySound(SoundID.NPCDeath1, (int)npc.position.X, (int)npc.position.Y); // Play a death sound
                            
                            // Spawn some dusts upon javelin death
                            for (int i = 0; i < 20; i++)
                            {
                                Vector2 usePos = npc.position; // Position to use for dusts
                                Vector2 rotVector = (npc.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
                                usePos += rotVector * 16f;
                                // Create a new dust
                                Dust dust = Dust.NewDustDirect(usePos, npc.width, npc.height, 16);
                                Dust dust2 = Dust.NewDustDirect(usePos, npc.width * 2, npc.height * 2, 16);
                                Dust dust3 = Dust.NewDustDirect(usePos, npc.width * 1, npc.height * 1, 16);
                                dust.position = (dust.position + npc.Center) / 2f;
                                dust.velocity += rotVector * 2f;
                                dust.velocity *= 0.5f;
                                dust.noGravity = true;
                                dust2.velocity *= 0.8f;
                                dust2.noGravity = true;
                                dust3.noGravity = true;
                                dust3.scale *= 1.2f;
                                dust3.velocity *= 1f;
                            }
                        }
                    }
                }
            }
        return;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    Vector2 usePos = npc.position; // Position to use for dusts
                    Vector2 rotVector = (npc.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
                    usePos += rotVector * 16f;
                    // Create a new dust
                    Dust dust = Dust.NewDustDirect(usePos, npc.width, npc.height, 16);
                    Dust dust2 = Dust.NewDustDirect(usePos, npc.width * 2, npc.height * 2, 16);
                    Dust dust3 = Dust.NewDustDirect(usePos, npc.width * 1, npc.height * 1, 16);
                    dust.position = (dust.position + npc.Center) / 2f;
                    dust.velocity += rotVector * 2f;
                    dust.velocity *= 0.5f;
                    dust.noGravity = true;
                    dust2.velocity *= 0.8f;
                    dust2.noGravity = true;
                    dust2.scale *= 1.2f;
                    dust3.noGravity = true;
                    dust3.scale *= 1.2f;
                    dust3.velocity *= 1f;
                }
			}
		}
	}
}