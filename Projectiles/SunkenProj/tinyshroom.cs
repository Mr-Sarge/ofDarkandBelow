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
using ofDarkandBelow.Projectiles;
namespace ofDarkandBelow.Projectiles.SunkenProj
{
	public class tinyshroom : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tiny Shroom");
            ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true; // projectiles with hide but without this will draw in the lighting values of the owner player.
        }
        public override void SetDefaults()
        {
			projectile.width = 11;
			projectile.height = 11;
			projectile.alpha = 60;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.timeLeft = 240;
        }
        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            // Add this projectile to the list of projectiles that will be drawn BEFORE tiles and NPC are drawn. This makes the projectile appear to be BEHIND the tiles and NPC.
            drawCacheProjsBehindNPCsAndTiles.Add(index);
        }
        public override void AI()
        {
            projectile.rotation += 0.1f;
            {
                if (projectile.ai[0] == 0)
                {
                    projectile.velocity.Y += 0.01f;
                    if (projectile.velocity.Y > .3f)
                    {
                        projectile.ai[0] = 1f;
                        projectile.netUpdate = true;
                    }
                }
                else if (projectile.ai[0] == 1)
                {
                    projectile.velocity.Y -= 0.01f;
                    if (projectile.velocity.Y < -.3f)
                    {
                        projectile.ai[0] = 0f;
                        projectile.netUpdate = true;
                    }
                }
            }
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(BuffID.Slow, 120);
        }
    }
}