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
using ofDarkandBelow;

namespace ofDarkandBelow.NPCs.EndlessMaw
{
    [AutoloadBossHead]
    public class EndlessMawHead : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primordial Maw");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 16500;        //this is the npc health
            npc.damage = 60;    //this is the npc damage
            npc.defense = 10;         //this is the npc defense
            npc.knockBackResist = 0f;
            npc.friendly = false;
            npc.width = 46; //this is where you put the npc sprite width.     important
            npc.height = 82; //this is where you put the npc sprite height.   important
            npc.boss = true;
            npc.lavaImmune = true;       //this make the npc immune to lava
            npc.noGravity = true;           //this make the npc float
            npc.noTileCollide = true;        //this make the npc go tru walls
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.NPCHit, "Sounds/NPCHit/MawHeadHit");
            npc.behindTiles = true;
            npc.DeathSound = SoundID.NPCDeath5;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/CuspofInfinity");
            npc.value = Item.buyPrice(0, 3, 0, 0);
            npc.npcSlots = 1f;
            npc.netAlways = true;
            bossBag = mod.ItemType("EndlessMawBag");
			npc.buffImmune[mod.BuffType("CosmicFlame")] = true;
			npc.buffImmune[mod.BuffType("BelowZero")] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.25f * bossLifeScale);
            npc.defense = 10;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EndlessMawHeadGore"), 1f);
            }
        }
        private bool talk1;
        private bool talk2;
        private bool talk3;
        private bool talk4;
        private bool talkdeath;
        private bool spawnexpert1;
        private bool speedUp1;
        private bool speedUp2;
        private bool speedUp3;
        private bool speedUpFinal;
        private int spawnexpert2;
        private int spawnexpert25;
        private int spawnexpert3;
        private int spawnexpert35;
        private int spawnexpert4;
        private int spawnTimer;
        private int fireTimer;
		private int ballTimer;
        public override bool PreAI()
        {
            int DustID2 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("CosmicDust"), npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 20, default(Color), 1.5f);
            Main.dust[DustID2].noGravity = true;
            {
                if (Main.expertMode && npc.life <= npc.lifeMax * 0.75 && !spawnexpert1)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CosmicFeederHead"), 1);
                    spawnexpert1 = true;
                }
                if (Main.expertMode && npc.life <= npc.lifeMax * 0.5)
                {
                    spawnexpert2++;
                    spawnexpert25++;
                    if (spawnexpert2 == 30)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CosmicFeederHead"), 1);
                    }
                    if (spawnexpert25 == 70)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CosmicFeederHead"), 1);
                    }
                }
                if (Main.expertMode && npc.life <= npc.lifeMax * 0.35)
                {
                    spawnexpert3++;
                    spawnexpert35++;
                    spawnexpert4++;
                    if (spawnexpert3 == 30)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CosmicFeederHead"), 1);
                    }
                    if (spawnexpert35 == 70)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CosmicFeederHead"), 1);
                    }
                    if (spawnexpert4 == 100)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CosmicFeederHead"), 1);
                    }
                }
                if (npc.life <= npc.lifeMax * 0.75 && !talk1)
                {
                    Main.NewText("You are competent, my child, I'll give you that.", Color.IndianRed.R, Color.IndianRed.G, Color.IndianRed.B);
                    talk1 = true;
                }
                if (npc.life <= npc.lifeMax * 0.5 && !talk2)
                {
                    Main.NewText("My diminished state shall be plenty to obliterate your fragile, childish spirit!", Color.IndianRed.R, Color.IndianRed.G, Color.IndianRed.B);
                    talk2 = true;
                }
                if (npc.life <= npc.lifeMax * 0.35 && !talk3)
                {
                    Main.NewText("Let's see how you handle what is coming, little one, for there are creatures bound to this world beyond your comprehension.", Color.IndianRed.R, Color.IndianRed.G, Color.IndianRed.B);
                    talk3 = true;
                }
                if (npc.life <= npc.lifeMax * 0.10 && !talk4)
                {
                    Main.NewText("Come on, child, things are only getting more interesting. Hit me more.", Color.IndianRed.R, Color.IndianRed.G, Color.IndianRed.B);
                    talk4 = true;
                }
                spawnTimer++;
                if (spawnTimer >= 360 && NPC.CountNPCS(mod.NPCType("CosmicDiggerHead")) <= 3) //every 2 seconds
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CosmicDiggerHead"));
                    spawnTimer = 0; //resets the timer
                }
                npc.TargetClosest(true);
                Player player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.TargetClosest(false);
                    player = Main.player[npc.target];
                    if (!player.active || player.dead)
                    {
                        npc.velocity = new Vector2(0f, -10f);
                        if (npc.timeLeft > 10)
                        {
                            npc.timeLeft = 10;
                        }
                    }
                }
                ballTimer++;
                fireTimer++;
                if (fireTimer == 400 || fireTimer == 405 || fireTimer == 410 || fireTimer == 415 || fireTimer == 420 || fireTimer == 425 || fireTimer == 430 || fireTimer == 435 || fireTimer == 440 || fireTimer == 445 || fireTimer == 450 || fireTimer == 455)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PrimordialSpew"), (int)npc.position.X, (int)npc.position.Y);
                    float Speed = 4f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                    int damage = 20;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                    int type = mod.ProjectileType("PrimordialBreath");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y, vector8.X);
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, npc.velocity.X, npc.velocity.Y, type, damage, 0f, 0);
                }
                if (fireTimer == 460)
                {
                    if (npc.life <= npc.lifeMax * 0.40)
                    {
                        fireTimer = 120;
                    }
                    else
                    {
                        fireTimer = 0;
                    }
                }
                if (Main.netMode != 1)
                {
                    // So, we start the AI off by checking if npc.ai[0] is 0.
                    // This is practically ALWAYS the case with a freshly spawned NPC, so this means this is the first update.
                    // Since this is the first update, we can safely assume we need to spawn the rest of the worm (bodies + tail).
                    if (npc.ai[0] == 0)
                    {
                        // So, here we assing the npc.realLife value.
                        // The npc.realLife value is mainly used to determine which NPC loses life when we hit this NPC.
                        // We don't want every single piece of the worm to have its own HP pool, so this is a neat way to fix that.
                        npc.realLife = npc.whoAmI;
                        // LatestNPC is going to be used later on and I'll explain it there.
                        int latestNPC = npc.whoAmI;

                        // Here we determine the length of the worm.
                        // In this case the worm will have a length of 10 to 14 body parts.
                        int randomWormLength = Main.rand.Next(25, 25);
                        for (int i = 0; i < randomWormLength; ++i)
                        {
                            // We spawn a new NPC, setting latestNPC to the newer NPC, whilst also using that same variable
                            // to set the parent of this new NPC. The parent of the new NPC (may it be a tail or body part)
                            // will determine the movement of this new NPC.
                            // Under there, we also set the realLife value of the new NPC, because of what is explained above.
                            latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EndlessMawBody"), npc.whoAmI, 0, latestNPC);
                            Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                            Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                        }
                        // When we're out of that loop, we want to 'close' the worm with a tail part!
                        latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EndlessMawTail"), npc.whoAmI, 0, latestNPC);
                        Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                        Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                        // We're setting npc.ai[0] to 1, so that this 'if' is not triggered again.
                        npc.ai[0] = 1;
                        npc.netUpdate = true;
                    }
                }

                int minTilePosX = (int)(npc.position.X / 16.0) - 1;
                int maxTilePosX = (int)((npc.position.X + npc.width) / 16.0) + 2;
                int minTilePosY = (int)(npc.position.Y / 16.0) - 1;
                int maxTilePosY = (int)((npc.position.Y + npc.height) / 16.0) + 2;
                if (minTilePosX < 0)
                    minTilePosX = 0;
                if (maxTilePosX > Main.maxTilesX)
                    maxTilePosX = Main.maxTilesX;
                if (minTilePosY < 0)
                    minTilePosY = 0;
                if (maxTilePosY > Main.maxTilesY)
                    maxTilePosY = Main.maxTilesY;

                bool collision = false;
                bool collisionBall = false;
                // This is the initial check for collision with tiles.
                for (int i = minTilePosX; i < maxTilePosX; ++i)
                {
                    for (int j = minTilePosY; j < maxTilePosY; ++j)
                    {
                        if (Main.tile[i, j] != null && (Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tileSolidTop[(int)Main.tile[i, j].type] && (int)Main.tile[i, j].frameY == 0) || (int)Main.tile[i, j].liquid > 64))
                        {
                            Vector2 vector2;
                            vector2.X = (float)(i * 16);
                            vector2.Y = (float)(j * 16);
                            if (npc.position.X + npc.width > vector2.X && npc.position.X < vector2.X + 16.0 && (npc.position.Y + npc.height > (double)vector2.Y && npc.position.Y < vector2.Y + 16.0))
                            {
                                collisionBall = true;
                                collision = true;
                                if (Main.rand.Next(100) == 0 && Main.tile[i, j].nactive())
                                    WorldGen.KillTile(i, j, true, true, false);
                            }
                        }
                    }
                }
                // If there is no collision with tiles, we check if the distance between this NPC and its target is too large, so that we can still trigger 'collision'.
                if (!collision)
                {
                    Rectangle rectangle1 = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                    int maxDistance = 1000;
                    bool playerCollision = true;
                    for (int index = 0; index < 255; ++index)
                    {
                        if (Main.player[index].active)
                        {
                            Rectangle rectangle2 = new Rectangle((int)Main.player[index].position.X - maxDistance, (int)Main.player[index].position.Y - maxDistance, maxDistance * 2, maxDistance * 2);
                            if (rectangle1.Intersects(rectangle2))
                            {
                                playerCollision = false;
                                break;
                            }
                        }
                    }
                    if (playerCollision)
                        collision = true;
                }

                // speed determines the max speed at which this NPC can move.
                // Higher value = faster speed.
                float speed = 11f;
                // acceleration is exactly what it sounds like. The speed at which this NPC accelerates.
                float acceleration = 0.2f;
                if (npc.life <= npc.lifeMax * 0.65 && !speedUp1)
                {
                    speed = 16f;
                    acceleration = 0.35f;
                    speedUp1 = true;
                }

                if (npc.life <= npc.lifeMax * 0.35 && !speedUp2)
                {
                    speed = 19f;
                    acceleration = 0.5f;
                    speedUp2 = true;
                }
                if (npc.life <= npc.lifeMax * 0.22 && !speedUp3)
                {
                    speed = 23f;
                    acceleration = 0.85f;
                    speedUp3 = true;
                }
                if (npc.life <= npc.lifeMax * 0.10 && !speedUpFinal)
                {
                    speed = 29f;
                    acceleration = 0.90f;
                    speedUp3 = true;
                }

                Vector2 npcCenter = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float targetXPos = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2);
                float targetYPos = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2);

                float targetRoundedPosX = (float)((int)(targetXPos / 16.0) * 16);
                float targetRoundedPosY = (float)((int)(targetYPos / 16.0) * 16);
                npcCenter.X = (float)((int)(npcCenter.X / 16.0) * 16);
                npcCenter.Y = (float)((int)(npcCenter.Y / 16.0) * 16);
                float dirX = targetRoundedPosX - npcCenter.X;
                float dirY = targetRoundedPosY - npcCenter.Y;

                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                // If we do not have any type of collision, we want the NPC to fall down and de-accelerate along the X axis.
                if (!collision)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > speed)
                        npc.velocity.Y = speed;
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.4)
                    {
                        if (npc.velocity.X < 0.0)
                            npc.velocity.X = npc.velocity.X - acceleration * 1.1f;
                        else
                            npc.velocity.X = npc.velocity.X + acceleration * 1.1f;
                    }
                    else if (npc.velocity.Y == speed)
                    {
                        if (npc.velocity.X < dirX)
                            npc.velocity.X = npc.velocity.X + acceleration;
                        else if (npc.velocity.X > dirX)
                            npc.velocity.X = npc.velocity.X - acceleration;
                    }
                    else if (npc.velocity.Y > 4.0)
                    {
                        if (npc.velocity.X < 0.0)
                            npc.velocity.X = npc.velocity.X + acceleration * 0.9f;
                        else
                            npc.velocity.X = npc.velocity.X - acceleration * 0.9f;
                    }
                }
                // Else we want to play some audio (soundDelay) and move towards our target.
                else
                {
                    if (npc.soundDelay == 0)
                    {
                        float num1 = length / 40f;
                        if (num1 < 10.0)
                            num1 = 10f;
                        if (num1 > 20.0)
                            num1 = 20f;
                        npc.soundDelay = (int)num1;
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1);
                    }
                    float absDirX = Math.Abs(dirX);
                    float absDirY = Math.Abs(dirY);
                    float newSpeed = speed / length;
                    dirX = dirX * newSpeed;
                    dirY = dirY * newSpeed;
                    if (npc.velocity.X > 0.0 && dirX > 0.0 || npc.velocity.X < 0.0 && dirX < 0.0 || (npc.velocity.Y > 0.0 && dirY > 0.0 || npc.velocity.Y < 0.0 && dirY < 0.0))
                    {
                        if (npc.velocity.X < dirX)
                            npc.velocity.X = npc.velocity.X + acceleration;
                        else if (npc.velocity.X > dirX)
                            npc.velocity.X = npc.velocity.X - acceleration;
                        if (npc.velocity.Y < dirY)
                            npc.velocity.Y = npc.velocity.Y + acceleration;
                        else if (npc.velocity.Y > dirY)
                            npc.velocity.Y = npc.velocity.Y - acceleration;
                        if (Math.Abs(dirY) < speed * 0.2 && (npc.velocity.X > 0.0 && dirX < 0.0 || npc.velocity.X < 0.0 && dirX > 0.0))
                        {
                            if (npc.velocity.Y > 0.0)
                                npc.velocity.Y = npc.velocity.Y + acceleration * 2f;
                            else
                                npc.velocity.Y = npc.velocity.Y - acceleration * 2f;
                        }
                        if (Math.Abs(dirX) < speed * 0.2 && (npc.velocity.Y > 0.0 && dirY < 0.0 || npc.velocity.Y < 0.0 && dirY > 0.0))
                        {
                            if (npc.velocity.X > 0.0)
                                npc.velocity.X = npc.velocity.X + acceleration * 2f;
                            else
                                npc.velocity.X = npc.velocity.X - acceleration * 2f;
                        }
                    }
                    else if (absDirX > absDirY)
                    {
                        if (npc.velocity.X < dirX)
                            npc.velocity.X = npc.velocity.X + acceleration * 1.1f;
                        else if (npc.velocity.X > dirX)
                            npc.velocity.X = npc.velocity.X - acceleration * 1.1f;
                        if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
                        {
                            if (npc.velocity.Y > 0.0)
                                npc.velocity.Y = npc.velocity.Y + acceleration;
                            else
                                npc.velocity.Y = npc.velocity.Y - acceleration;
                        }
                    }
                    else
                    {
                        if (npc.velocity.Y < dirY)
                            npc.velocity.Y = npc.velocity.Y + acceleration * 1.1f;
                        else if (npc.velocity.Y > dirY)
                            npc.velocity.Y = npc.velocity.Y - acceleration * 1.1f;
                        if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
                        {
                            if (npc.velocity.X > 0.0)
                                npc.velocity.X = npc.velocity.X + acceleration;
                            else
                                npc.velocity.X = npc.velocity.X - acceleration;
                        }
                    }
                }
                // Set the correct rotation for this NPC.
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;

                // Some netupdate stuff (multiplayer compatibility).
                if (collision)
                {
                    if (npc.localAI[0] != 1)
                        npc.netUpdate = true;
                    npc.localAI[0] = 1f;
                }
                else
                {
                    if (npc.localAI[0] != 0.0)
                        npc.netUpdate = true;
                    npc.localAI[0] = 0.0f;
                }
                if ((npc.velocity.X > 0.0 && npc.oldVelocity.X < 0.0 || npc.velocity.X < 0.0 && npc.oldVelocity.X > 0.0 || (npc.velocity.Y > 0.0 && npc.oldVelocity.Y < 0.0 || npc.velocity.Y < 0.0 && npc.oldVelocity.Y > 0.0)) && !npc.justHit)
                    npc.netUpdate = true;

                if (ballTimer == 210)
                {
                    if (collisionBall = false)
                    {
                        Main.PlaySound(SoundID.Item71, (int)npc.position.X, (int)npc.position.Y);
                        float Speed = 12f;  //projectile speed
                        Vector2 vector8 = new Vector2(npc.Center.X, npc.Center.Y);
                        int damage = 30;  //projectile damage REMEBER THE ACTUAL DAMAGE IS DOUBLE WHAT IT SAYS IN THE CODE
                        int type = mod.ProjectileType("PrimordialBall");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        ballTimer = 0;
                    }
                    ballTimer = 0;
                }
                return false;
            }
        }
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        scale = 1.9f;   //this make the NPC Health Bar biger
        return null;
    }
    public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
    {
            target.AddBuff(mod.BuffType("CosmicFlame"), 200);
	}
        public override void NPCLoot()
        {
            MyWorld.downedPrimordialMaw = true;
            Vector2 position = npc.position;
            Vector2 center = Main.player[npc.target].Center;
            float num4 = 1E+08f;
            Vector2 position2 = center;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && (Main.npc[i].type == 134 || Main.npc[i].type == 135 || Main.npc[i].type == 136))
                {
                    float num5 = Math.Abs(Main.npc[i].Center.X - center.X) + Math.Abs(Main.npc[i].Center.Y - center.Y);
                    if (num5 < num4)
                    {
                        num4 = num5;
                        position2 = Main.npc[i].position;
                    }
                }
            }
            npc.position = position2;
            if (Main.expertMode)
            {
                npc.DropBossBags();
				npc.position = position;
            }
            else
            {
            	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CosmicClusterFragment"), 35);
				if (Main.rand.NextBool(4)) {
          	       Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MawRak"));
				}
				if (Main.rand.NextBool(4)) {
         	       Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Celestra"));
				}
				if (Main.rand.NextBool(4)) {
               	   Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EyeofTheMaw"));
				}
				if (Main.rand.NextBool(10)) {
         	       Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EndlessMawMask"));
				}
				if (Main.rand.NextBool(10)) {
         	       Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EndlessMawTrophy"));
				}
				npc.position = position;
            }
        }
    }
}