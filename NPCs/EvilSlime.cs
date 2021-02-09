using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.NPCs
{
	public class EvilSlime : ModNPC
	{
		public override string Texture => "farlinMod/NPCs/Textures/EvilSlime";
		public override void SetStaticDefaults()
        {
			Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
			npc.width = 24;
			npc.height = 26;
			//npc.aiStyle = -1;
			npc.damage = 6;
			npc.defense = 5;
			npc.lifeMax = 95;
			npc.scale = 1.2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.alpha = 0;
			npc.value = 40f;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = false;
			animationType = NPCID.SlimeSpiked;
			npc.aiStyle = -1;
		}
        public override void AI()
		{
			if (!npc.wet && !Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				Vector2 vector3 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num11 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector3.X;
				float num12 = Main.player[npc.target].position.Y - vector3.Y;
				float num13 = (float)Math.Sqrt(num11 * num11 + num12 * num12);
				if (num13 < 200f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && npc.velocity.Y == 0f && npc.life > npc.lifeMax * .75f)
				{
					npc.ai[0] = -40f;
					if (npc.velocity.Y == 0f)
					{
						npc.velocity.X *= 0.9f;
					}
					if (Main.netMode != NetmodeID.MultiplayerClient && npc.localAI[0] == 0f)
					{
						num12 = Main.player[npc.target].position.Y - vector3.Y - (float)Main.rand.Next(-10, 60);
						num13 = (float)Math.Sqrt(num11 * num11 + num12 * num12);
						num13 = 7.5f / num13;
						num11 *= num13;
						num12 *= num13;
						npc.localAI[0] = 120f;
						Projectile.NewProjectile(vector3.X, vector3.Y, num11, num12, ProjectileID.SpikedSlimeSpike, 4, 0f, Main.myPlayer);
					}
				}
				else if (num13 < 200f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && npc.velocity.Y == 0f && npc.life < npc.lifeMax * .5f)
				{
					npc.ai[0] = -40f;
					if (npc.velocity.Y == 0f)
					{
						npc.velocity.X *= 1.2f;
					}
					if (Main.netMode != NetmodeID.MultiplayerClient && npc.localAI[0] == 0f)
					{
						npc.velocity.Y = 0f;
						for (int i = 0; i < 5; i++)
						{
							Vector2 vector2 = new Vector2(i - 2, -4f);
							vector2.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							vector2.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							vector2.Normalize();
							vector2 *= 4f + (float)Main.rand.Next(-50, 51) * 0.01f;
							Projectile.NewProjectile(vector3.X, vector3.Y, vector2.X, vector2.Y, ProjectileID.SpikedSlimeSpike, 4, 0f, Main.myPlayer);
							npc.localAI[0] = 120f;
						}
					}
					else if (npc.localAI[0] <= 115f)
					{
						npc.velocity.Y -= 4f;
					}
				}
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			GlowmaskUtils.DrawNPCGlowMask(spriteBatch, false, true, npc, mod.GetTexture("NPCs/Textures/EvilSlime_Glow"));
		}
	}
}
