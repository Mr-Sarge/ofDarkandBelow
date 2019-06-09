using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.NPCs.JungleProtector
{
    public class JungleProtector : ModNPC
    {
        #region .     Constants      .

        private const int SPAWN = 0;
        private const int CHASE = 1;
        private const int DBLFIRE = 2;

        #endregion .     Constants      .

        #region .     Properties     .

        private float _chaseAccel = 0.03f;
        private float _chaseTopSp = 4f;
        private float _chaseRotSp = 0.05f;
        private float _taperSpeed = 0.98f;

        private Rectangle newHit = new Rectangle();

        private int _leftHandID;
        private int _rightHandID;

        #endregion .     Properties     .

        #region .    AI Variables    .

        private float _stateTimer { get { return npc.ai[0]; } set { npc.ai[0] = value; } }

        private float _currentState { get { return npc.ai[1]; } set { npc.ai[1] = value; } }

        private float _currentPhase { get { return npc.ai[2]; } set { npc.ai[2] = value; } }

        #endregion .    AI Variables    .

        #region . Overridden Methods .

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Protector");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.dontTakeDamage = true;

            npc.lifeMax = 5000;
            npc.defense = 10;
            npc.damage = 0;
            npc.value = Item.buyPrice(gold: 35);
            npc.knockBackResist = 0f;

            npc.width = 128;
            npc.height = 200;

            newHit = npc.Hitbox;
            newHit.Width = 60;

            music = MusicID.Boss1;
            musicPriority = MusicPriority.BossMedium;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = new LegacySoundStyle(SoundID.Shatter, 0, Terraria.Audio.SoundType.Sound);
        }

        public override void AI()
        {
            newHit.X = npc.Hitbox.X; newHit.Y = npc.Hitbox.Y;
            npc.Hitbox = newHit; // Halving his hitbox to account for the sprite's size.

            switch ((int)_currentState)
            {
                case SPAWN:
                    _rightHandID = NPC.NewNPC((int)npc.Right.X + 40, (int)npc.Right.Y, mod.NPCType("JungleProtectorHand"), Start: npc.whoAmI, ai0: 1f, ai1: npc.whoAmI, Target: npc.target);
                    _leftHandID = NPC.NewNPC((int)npc.Left.X - 40, (int)npc.Left.Y, mod.NPCType("JungleProtectorHand"), Start: npc.whoAmI, ai0: -1f, ai1: npc.whoAmI, Target: npc.target);
                    _currentState++;
                    break;
                case CHASE:
                    Chase();
                    _stateTimer++;
                    if (_stateTimer > 90 && Main.rand.Next(1, 10) == 1)
                    {
                        _currentState = 2f;
                        _stateTimer = 0f;
                    }
                        break;
                case DBLFIRE:
                    DoubleFire();
                    if (_stateTimer > 20)
                    {
                        _currentState = 1f;
                        _stateTimer = 0f;
                    }
                    break;
                case 3: // Standing still
                    npc.velocity.X = 0; npc.velocity.Y = 0;
                    break;
                default:
                    _currentState = 1;
                    break;
            }
        }

        #endregion . Overridden Methods .

        #region .  AI State Methods  .

        private void Chase()
        {
            npc.TargetClosest(true);
            Vector2 targetPos = Main.player[npc.target].Center;

            if (npc.Center.X > targetPos.X)
            {
                MoveLeft(true);
            }
            else if (npc.Center.X < targetPos.X)
            {
                MoveRight(true);
            }

            if (npc.Center.Y > targetPos.Y + 80)
            {
                MoveDown();
            }
            else if (npc.Center.Y < targetPos.Y + 80)
            {
                MoveUp();
            }
        }

        private void DoubleFire()
        {
            Main.npc[_leftHandID].ai[2] = 1f;
            Main.npc[_rightHandID].ai[2] = 1f;
        }


        #endregion .  AI State Methods  .

        #region .  AI Helper Methods .

        private void MoveRight(bool rotate = false)
        {
            if (npc.velocity.X < 0f)
            {
                npc.velocity.X *= _taperSpeed;
            }
            npc.velocity.X += _chaseAccel;
            if (npc.velocity.X < -_chaseTopSp)
            {
                npc.velocity.X = -_chaseTopSp;
            }
            if (rotate)
                SetRotation();
        }

        private void MoveLeft(bool rotate = false)
        {
            if (npc.velocity.X > 0f)
            {
                npc.velocity.X *= _taperSpeed;
            }
            npc.velocity.X -= _chaseAccel;
            if (npc.velocity.X > _chaseTopSp)
            {
                npc.velocity.X = _chaseTopSp;
            }
            if (rotate)
                SetRotation();
        }

        private void MoveDown()
        {
            if (npc.velocity.Y > 0f)
            {
                npc.velocity.Y *= _taperSpeed;
            }
            npc.velocity.Y -= _chaseAccel;
            if (npc.velocity.Y < -_chaseTopSp)
            {
                npc.velocity.Y = -_chaseTopSp;
            }
        }

        private void MoveUp()
        {
            if (npc.velocity.Y < 0f)
            {
                npc.velocity.Y *= _taperSpeed;
            }
            npc.velocity.Y += _chaseAccel;
            if (npc.velocity.Y < _chaseTopSp)
            {
                npc.velocity.Y = _chaseTopSp;
            }
        }

        private void SetRotation()
        {
            npc.rotation = 0.02f * npc.velocity.X;
        }

        private void ResetRotation()
        {
            if (npc.rotation > 0)
            {
                npc.rotation -= _chaseRotSp;
                if (npc.rotation < 0)
                {
                    npc.rotation = 0;
                }
            }
            if (npc.rotation < 0)
            {
                npc.rotation += _chaseRotSp;
                if (npc.rotation > 0)
                {
                    npc.rotation = 0;
                }
            }
        }

        private void StopChasing()
        {
            if (npc.velocity.X > 0)
                npc.velocity.X -= _chaseAccel;
            if (npc.velocity.X < 0)
                npc.velocity.X += _chaseAccel;

            if (npc.velocity.Y < 0)
                npc.velocity.Y += _chaseAccel;
            if (npc.velocity.Y > 0)
                npc.velocity.Y -= _chaseAccel;

            ResetRotation();
        }

        #endregion .  AI Helper Methods .  
    }
}