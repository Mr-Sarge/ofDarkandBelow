using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles
{
    public class TerrorNaginataProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terror Naginata");
        }

        public override void SetDefaults()
        {
            aiType = 699;
            projectile.width = 78;
            projectile.height = 88;
            projectile.aiStyle = 142;
            projectile.penetrate = -1;
            projectile.scale = 1.3f;
            projectile.alpha = 0;
            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        public float movementFactor
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            owner.statMana += 5;
            owner.ManaEffect(5);
        }
        /*
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            projectile.direction = player.direction;
            player.heldProj = projectile.whoAmI;
            projectile.Center = vector;
            if (player.dead)
            {
                projectile.Kill();
                return;
            }
            if (!player.frozen)
            {
                if (projectile.type == projectile.type)
                {
                    projectile.spriteDirection = (projectile.direction = player.direction);
                    projectile.alpha -= 127;
                    if (projectile.alpha < 0)
                    {
                        projectile.alpha = 0;
                    }
                    if (projectile.localAI[0] > 0f)
                    {
                        projectile.localAI[0] -= 1f;
                    }
                    float num = (float)player.itemAnimation / (float)player.itemAnimationMax;
                    float num2 = 1f - num;
                    float num3 = projectile.velocity.ToRotation();
                    float num4 = projectile.velocity.Length();
                    float num5 = 22f;
                    Vector2 value = new Vector2(1f, 0f).RotatedBy((double)(3.14159274f + num2 * 6.28318548f), default(Vector2));
                    Vector2 spinningpoint = value * new Vector2(num4, projectile.ai[0]);
                    projectile.position += spinningpoint.RotatedBy((double)num3, default(Vector2)) + new Vector2(num4 + num5, 0f).RotatedBy((double)num3, default(Vector2));
                    Vector2 destination = vector + spinningpoint.RotatedBy((double)num3, default(Vector2)) + new Vector2(num4 + num5 + 40f, 0f).RotatedBy((double)num3, default(Vector2));
                    projectile.rotation = player.AngleTo(destination) + 0.7853982f * (float)player.direction;
                    if (projectile.spriteDirection == -1)
                    {
                        projectile.rotation += 3.14159274f;
                    }
                    player.DirectionTo(projectile.Center);
                    Vector2 value2 = player.DirectionTo(destination);
                    Vector2 vector2 = projectile.velocity.SafeNormalize(Vector2.UnitY);
                    float num6 = 2f;
                    int num7 = 0;
                    while ((float)num7 < num6)
                    {
                        Dust dust = Dust.NewDustDirect(projectile.Center, 14, 14, 228, 0f, 0f, 110, default(Color), 1f);
                        dust.velocity = player.DirectionTo(dust.position) * 2f;
                        dust.position = projectile.Center + vector2.RotatedBy((double)(num2 * 6.28318548f * 2f + (float)num7 / num6 * 6.28318548f), default(Vector2)) * 10f;
                        dust.scale = 1f + 0.6f * Main.rand.NextFloat();
                        dust.velocity += vector2 * 3f;
                        dust.noGravity = true;
                        num7++;
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            Dust dust2 = Dust.NewDustDirect(projectile.Center, 20, 20, 228, 0f, 0f, 110, default(Color), 1f);
                            dust2.velocity = player.DirectionTo(dust2.position) * 2f;
                            dust2.position = projectile.Center + value2 * -110f;
                            dust2.scale = 0.45f + 0.4f * Main.rand.NextFloat();
                            dust2.fadeIn = 0.7f + 0.4f * Main.rand.NextFloat();
                            dust2.noGravity = true;
                            dust2.noLight = true;
                        }
                    }
                }
                else if (projectile.type == 708)
                {
                    Lighting.AddLight(player.Center, 0.75f, 0.9f, 1.15f);
                    projectile.spriteDirection = (projectile.direction = player.direction);
                    projectile.alpha -= 127;
                    if (projectile.alpha < 0)
                    {
                        projectile.alpha = 0;
                    }
                    float num8 = (float)player.itemAnimation / (float)player.itemAnimationMax;
                    float num9 = 1f - num8;
                    float num10 = projectile.velocity.ToRotation();
                    float num11 = projectile.velocity.Length();
                    float num12 = 22f;
                    Vector2 value3 = new Vector2(1f, 0f).RotatedBy((double)(3.14159274f + num9 * 6.28318548f), default(Vector2));
                    Vector2 spinningpoint2 = value3 * new Vector2(num11, projectile.ai[0]);
                    projectile.position += spinningpoint2.RotatedBy((double)num10, default(Vector2)) + new Vector2(num11 + num12, 0f).RotatedBy((double)num10, default(Vector2));
                    Vector2 destination2 = vector + spinningpoint2.RotatedBy((double)num10, default(Vector2)) + new Vector2(num11 + num12 + 40f, 0f).RotatedBy((double)num10, default(Vector2));
                    projectile.rotation = player.AngleTo(destination2) + 0.7853982f * (float)player.direction;
                    if (projectile.spriteDirection == -1)
                    {
                        projectile.rotation += 3.14159274f;
                    }
                    player.DirectionTo(projectile.Center);
                    player.DirectionTo(destination2);
                    Vector2 vector3 = projectile.velocity.SafeNormalize(Vector2.UnitY);
                    if ((player.itemAnimation == 2 || player.itemAnimation == 6 || player.itemAnimation == 10) && projectile.owner == Main.myPlayer)
                    {
                        Vector2 vector4 = vector3 + Main.rand.NextVector2Square(-0.2f, 0.2f);
                        vector4 *= 12f;
                        int itemAnimation = player.itemAnimation;
                        if (itemAnimation != 2)
                        {
                            if (itemAnimation != 6)
                            {
                                if (itemAnimation == 10)
                                {
                                    vector4 = vector3.RotatedBy(0.0, default(Vector2));
                                }
                            }
                            else
                            {
                                vector4 = vector3.RotatedBy(-0.38397244612375897, default(Vector2));
                            }
                        }
                        else
                        {
                            vector4 = vector3.RotatedBy(0.38397244612375897, default(Vector2));
                        }
                        vector4 *= 10f + (float)Main.rand.Next(4);
                        Projectile.NewProjectile(projectile.Center, vector4, 709, projectile.damage, 0f, projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 3; j += 2)
                    {
                        float scaleFactor = 1f;
                        float num13 = 1f;
                        switch (j)
                        {
                            case 1:
                                num13 = -1f;
                                break;
                            case 2:
                                num13 = 1.25f;
                                scaleFactor = 0.5f;
                                break;
                            case 3:
                                num13 = -1.25f;
                                scaleFactor = 0.5f;
                                break;
                        }
                        if (Main.rand.Next(6) != 0)
                        {
                            num13 *= 1.2f;
                            Dust dust3 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 226, 0f, 0f, 100, default(Color), 1f);
                            dust3.velocity = vector3 * (4f + 4f * Main.rand.NextFloat()) * num13 * scaleFactor;
                            dust3.noGravity = true;
                            dust3.noLight = true;
                            dust3.scale = 0.75f;
                            dust3.fadeIn = 0.8f;
                            dust3.customData = projectile;
                            if (Main.rand.Next(3) == 0)
                            {
                                dust3.noGravity = false;
                                dust3.fadeIn = 0f;
                            }
                        }
                    }
                }
            }
            if (player.itemAnimation == 2)
            {
                projectile.Kill();
                player.reuseDelay = 2;
            }
        }*/
    }
}