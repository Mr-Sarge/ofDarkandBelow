using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class TerrorNaginataProj : ModProjectile
    {
        public float movementFactor { get { return projectile.ai[0]; } set { projectile.ai[0] = value; } }

        private float _percentTimeAlive { get { return projectile.localAI[0]; } set { projectile.localAI[0] = value; } }

        private float _initialMouseClicked { get { return projectile.localAI[1]; } set { projectile.localAI[1] = value; } }

        private Vector2 _relativeMouse { get; set; }

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
            projectile.idStaticNPCHitCooldown = 36;
            projectile.ownerHitCheck = true;
            projectile.hide = true;
            _initialMouseClicked = 0;
            _relativeMouse = Vector2.Zero;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float extraAngle = 0;
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection.Equals(-1))
            {
                spriteEffects = SpriteEffects.FlipVertically;
                extraAngle = MathHelper.Pi/2;
            }

            Texture2D texture = Main.projectileTexture[projectile.type];

            Rectangle spriteRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = spriteRect.Size() / 2f;

            Main.spriteBatch.Draw(texture,
                projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
                spriteRect, projectile.GetAlpha(lightColor), projectile.rotation-extraAngle, origin+new Vector2(30,30*(-projectile.spriteDirection)), projectile.scale, spriteEffects, 0f);

            return false;
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];

            owner.statMana += 5;
            owner.ManaEffect(5);
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];

            if (_initialMouseClicked == 0)
            {
                _relativeMouse = Main.MouseWorld - owner.RotatedRelativePoint(owner.MountedCenter, true);
                Vector2 newVect = _relativeMouse;

                if (_relativeMouse != Vector2.Zero)
                {
                    newVect.Normalize();
                    _relativeMouse = newVect;
                }

                _initialMouseClicked = 1;
            }
            
            owner.heldProj = projectile.whoAmI;
            owner.itemTime = owner.itemAnimation;
            Vector2 axis = owner.RotatedRelativePoint(owner.MountedCenter, true) + _relativeMouse*45;
            
            projectile.rotation = projectile.velocity.ToRotation() + (MathHelper.Pi/4);
            projectile.spriteDirection = projectile.direction = owner.direction;
            
            _percentTimeAlive = (float)owner.itemAnimation / (float)owner.itemAnimationMax;

            projectile.position.X = axis.X - (projectile.width / 2);
            projectile.position.Y = axis.Y - (projectile.height / 2);

            if (!owner.frozen)
            {
                SetCurrentMovementFactor();
            }

            projectile.position += (projectile.velocity * movementFactor);
            
            if (owner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            
        }

        private void SetCurrentMovementFactor()
        {
            if (_percentTimeAlive >= 0.9f)
            {
                movementFactor = -1f;
            }
            else if (_percentTimeAlive >= 0.6f)
            {
                if (movementFactor < 6f)
                {
                    movementFactor += 3f;
                }
            }
            else if (_percentTimeAlive >= 0.30f)
            {
                movementFactor = -1f;
            }
            else if (_percentTimeAlive >= 0.15f)
            {
                movementFactor = 0f;
            }
        }
    }
}