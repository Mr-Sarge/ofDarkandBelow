using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class TerrorNaginataProj : ModProjectile
    {
        #region Public Properties

        public float movementFactor { get { return projectile.ai[0]; } set { projectile.ai[0] = value; } }

        public float rotationFactor { get { return projectile.ai[1]; } set { projectile.ai[1] = value; } }

        public float onHitCheck { get { return projectile.localAI[1]; } set { projectile.localAI[1] = value; } }

        #endregion Public Properties

        #region Private Properties

        private float _percentTimeAlive { get { return projectile.localAI[0]; } set { projectile.localAI[0] = value; } }

        private Vector2 _relativeMouse { get; set; }

        private Projectile sourSpot { get; set; }

        #endregion Private Properties

        #region Overriden Methods

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terror Naginata");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.usesIDStaticNPCImmunity = true;
            projectile.idStaticNPCHitCooldown = 14;
            projectile.ownerHitCheck = true;
            projectile.hide = true;
            rotationFactor = 0;
            _relativeMouse = Vector2.Zero;
            onHitCheck = 0;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float extraAngle = 0;
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection.Equals(-1))
            {
                spriteEffects = SpriteEffects.FlipVertically;
                extraAngle = MathHelper.Pi / 2;
            }

            Texture2D texture = Main.projectileTexture[projectile.type];

            Rectangle spriteRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = spriteRect.Size() / 2f;

            Main.spriteBatch.Draw(texture,
                projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
                spriteRect, projectile.GetAlpha(lightColor), projectile.rotation - extraAngle, origin + new Vector2(30, 30 * (-projectile.spriteDirection)), projectile.scale, spriteEffects, 0f);

            return false;
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];

            owner.statMana += 5;
            owner.ManaEffect(5);

            onHitCheck++;

            Main.PlaySound(new LegacySoundStyle(2, 71), projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(n.position, 10, 10, DustID.Vortex);
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            float newRotation = 0; float oldRotation = 0;

            if (owner.itemTime == owner.itemAnimationMax / 3)
            {
                _relativeMouse = Main.MouseWorld - owner.RotatedRelativePoint(owner.MountedCenter, true);
                Vector2 newVect = _relativeMouse;

                if (_relativeMouse != Vector2.Zero)
                {
                    newVect.Normalize();
                    _relativeMouse = newVect;
                }

                sourSpot = Projectile.NewProjectileDirect(projectile.position, new Vector2(0, 0), mod.ProjectileType("TerrorNaginataSourSpot"), 10, 4, owner.whoAmI, projectile.whoAmI);
            }

            oldRotation = (float)Math.Atan2(_relativeMouse.Y, _relativeMouse.X);

            if (owner.itemAnimation != 0)
            {
                float totalAliveTime = (float)owner.itemAnimationMax / (float)owner.itemAnimation;
                if (owner.itemTime == owner.itemAnimationMax / 3 && totalAliveTime >= 1.50)
                {
                    Main.PlaySound(SoundID.Item1, owner.RotatedRelativePoint(owner.MountedCenter, true));
                    if (totalAliveTime > 2.0)
                    {
                        newRotation = oldRotation + MathHelper.ToRadians(15f);
                        projectile.knockBack = 8f;
                    }
                    else
                    {
                        newRotation = oldRotation + MathHelper.ToRadians(-15f);
                    }
                    rotationFactor = newRotation - oldRotation;
                    _relativeMouse = new Vector2((float)Math.Cos(newRotation), (float)Math.Sin(newRotation));
                }
            }

            owner.heldProj = projectile.whoAmI;
            Vector2 axis = owner.RotatedRelativePoint(owner.MountedCenter, true) + _relativeMouse * 45;

            projectile.rotation = projectile.velocity.ToRotation() + rotationFactor + (MathHelper.Pi / 4);
            projectile.spriteDirection = projectile.direction = owner.direction;

            _percentTimeAlive = (float)owner.itemTime / ((float)owner.itemAnimationMax / 3);

            projectile.position.X = axis.X - (projectile.width / 2);
            projectile.position.Y = axis.Y - (projectile.height / 2);

            if (!owner.frozen)
            {
                SetCurrentMovementFactor();
            }

            projectile.position += (projectile.velocity.RotatedBy(rotationFactor) * movementFactor);

            if (sourSpot.ai[0] > 0)
            {
                projectile.damage = 0;
            }

            if (owner.itemTime == 1)
            {
                projectile.Kill();
            }
        }

        #endregion Overriden Methods

        #region Private Methods

        private void SetCurrentMovementFactor()
        {
            if (_percentTimeAlive >= 0.75f)
            {
                movementFactor += -1.5f;
            }
            else if (_percentTimeAlive >= 0.42f)
            {
                if (movementFactor < 0f)
                {
                    movementFactor = 0f;
                }
                if (movementFactor < 12f)
                {
                    movementFactor += 4f;
                }
            }
            else if (_percentTimeAlive >= 0.20f)
            {
                movementFactor = 0f;
            }
            else if (_percentTimeAlive >= 0.10f)
            {
                movementFactor = -1.5f;
            }
        }

        #endregion Private Methods
    }
}