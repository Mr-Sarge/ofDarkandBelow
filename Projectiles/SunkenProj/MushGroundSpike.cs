using ofDarkandBelow.Items;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ofDarkandBelow.Projectiles.SunkenProj
{
	public class MushGroundSpike : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushy Impalement");
            Main.projFrames[projectile.type] = 9;
            ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true; // projectiles with hide but without this will draw in the lighting values of the owner player.
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 98;
            projectile.penetrate = -1;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.tileCollide = true;
            projectile.hide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 180;
        }
        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            // Add this projectile to the list of projectiles that will be drawn BEFORE tiles and NPC are drawn. This makes the projectile appear to be BEHIND the tiles and NPC.
            drawCacheProjsBehindNPCsAndTiles.Add(index);
        }
        public override void AI()
        {
            projectile.rotation = projectile.ai[0];

            if (++projectile.frameCounter >= 9)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 9)
                {
                    projectile.frame = 6;
                }
            }
            if (projectile.frame >= 6 && projectile.ai[0] != 1)
            {
                projectile.hostile = true;
            }
            projectile.localAI[0] += 1f;
            projectile.velocity.X *= 0.00f;
            projectile.velocity.Y += 1.00f;
            if (projectile.localAI[0] >= 160)
            {
                projectile.alpha += 10;
            }
            if (projectile.alpha >= 255)
            {
                projectile.Kill();
            }
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            fallThrough = false;
            return true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 0.0f)
            {
                projectile.velocity.X = oldVelocity.X * -0.0f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 0.0f)
            {
                projectile.velocity.Y = oldVelocity.Y * -0.0f;
            }
            return false;
        }
    }
}