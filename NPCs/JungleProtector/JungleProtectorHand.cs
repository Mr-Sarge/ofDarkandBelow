using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.NPCs.JungleProtector
{
    public class JungleProtectorHand : ModNPC
    {
        #region .     Properties     .

        private float _speed = 1f;

        #endregion .     Properties     .

        #region . Overridden Methods .

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hand of the Jungle Protector");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.lifeMax = 1000;
            npc.defense = 5;
            npc.damage = 5;
            npc.knockBackResist = 0f;

            npc.width = 58;
            npc.height = 64;

            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = new LegacySoundStyle(SoundID.Shatter, 0, Terraria.Audio.SoundType.Sound);
        }

        public override void AI()
        {
            npc.spriteDirection = -(int)npc.ai[0];
            //npc.rotation = 0.1046667f * npc.velocity.X;

            Player player = Main.player[npc.target];

            var bossLeft = Main.npc[(int)npc.ai[1]].Left.X;
            var bossRight = Main.npc[(int)npc.ai[1]].Right.X;
            var bossCenter = Main.npc[(int)npc.ai[1]].Center.Y;

            switch ((int)Main.npc[(int)npc.ai[1]].ai[1])
            {
                case 1:
                case 3:
                    if (!Main.npc[(int)npc.ai[1]].active)
                    {
                        npc.life = -1;
                        npc.HitEffect(0, 10.0);
                        npc.active = false;
                    }

                    /*
                    if (bossCenter < npc.Center.Y)
                    {
                        npc.velocity.Y += _speed;
                    } else if (bossCenter > npc.Center.Y)
                    {
                        npc.velocity.Y += -_speed;
                    }
                    */

                    npc.position.Y = bossCenter - 20f;

                    if ((int)npc.ai[0] == -1) // Left Hand
                    {
                        /*
                        if (bossLeft > npc.position.X)
                        {
                            npc.velocity.X += _speed;
                        }
                        else if (bossLeft < npc.position.X - 25f)
                        {
                            npc.velocity.X += -_speed;
                        }

                        if (bossLeft > npc.position.X - 25f && bossLeft < npc.position.X)
                        {
                            if (npc.velocity.X < 0)
                            {
                                npc.velocity.X += _speed;
                            }
                            else if (npc.velocity.X > 0)
                            {
                                npc.velocity.X += -_speed;
                            }
                        }
                        */
                        npc.position.X = bossLeft - 58f;
                    }
                    else if ((int)npc.ai[0] == 1) // Right Hand
                    {
                        /*
                        if (bossRight > npc.position.X + 25f)
                        {
                            npc.velocity.X += _speed;
                        }
                        else if (bossRight < npc.position.X)
                        {
                            npc.velocity.X += -_speed;
                        }

                        if (bossRight > npc.position.X && bossRight < npc.position.X + 25f)
                        {
                            if (npc.velocity.X < 0)
                            {
                                npc.velocity.X += _speed;
                            }
                            else if (npc.velocity.X > 0)
                            {
                                npc.velocity.X += -_speed;
                            }
                        }
                        */
                        npc.position.X = bossRight;
                    }
                    break;
                case 2:
                    Vector2 distFromPlayer = player.Center - npc.Center;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, distFromPlayer.X, distFromPlayer.Y, ProjectileID.CursedFlameHostile, npc.damage, 3f, Main.myPlayer, BuffID.CursedInferno, 350f);
                    break;
            }
        }

        public override void PostAI()
        {
           npc.spriteDirection = -(int)npc.ai[0];
        }

        #endregion . Overridden Methods .

        #region .   Private Methods  .

        #endregion .   Private Methods  .
    }
}