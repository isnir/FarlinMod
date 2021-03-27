using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.NPCs
{
    public class CursedDemonEye : ModNPC
    {
		public override string Texture => "farlinMod/NPCs/Textures/EvilEye";

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Cursed Demon Eye");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
        {
			npc.width = 30;
			npc.height = 32;
			npc.damage = 18;
			npc.defense = 2;
			npc.lifeMax = 60;
			npc.HitSound = SoundID.NPCHit1;
			npc.knockBackResist = 0.8f;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 75f;
			npc.buffImmune[31] = false;
			npc.aiStyle = -1;
		}

		public override void FindFrame(int frameHeight)
		{
			if (npc.velocity.X > 0f)
			{
				npc.spriteDirection = 1;
			}
			if (npc.velocity.X < 0f)
			{
				npc.spriteDirection = -1;
			}
			npc.rotation = npc.velocity.X * 0.1f;
			npc.frameCounter += 1.0;
			if (npc.frameCounter >= 6.0)
			{
				npc.frame.Y += frameHeight;
				npc.frameCounter = 0.0;
			}
			if (npc.frame.Y >= frameHeight * 4)
			{
				npc.frame.Y = 0;
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldNightMonster.Chance * 0.25f;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			if(npc.direction == 1)
				npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
			if(npc.direction == -1)
				npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 3.14f;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			GlowmaskUtils.DrawNPCGlowMask(spriteBatch, false, true, npc, mod.GetTexture("NPCs/Textures/EvilEye_Glow"));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int i = 0; i < 6; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 5, 2 * hitDirection, -2f);
					if (Main.rand.NextBool(2))
					{
						Main.dust[dust].noGravity = true;
						Main.dust[dust].scale = 1.2f * npc.scale;
					}
					else
					{
						Main.dust[dust].scale = 0.7f * npc.scale;
					}
				}
				Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
				Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/EvilEye1_Gore"), 1f);
				Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/EvilEye2_Gore"), 1f);
			}
		}
		public override void AI()
		{
			npc.noGravity = true;

			if (!npc.noTileCollide)
			{
				if (npc.collideX)
				{
					npc.velocity.X = npc.oldVelocity.X * -0.5f;
					if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
					{
						npc.velocity.X = 2f;
					}
					if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
					{
						npc.velocity.X = -2f;
					}
				}
				if (npc.collideY)
				{
					npc.velocity.Y = npc.oldVelocity.Y * -0.5f;
					if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
					{
						npc.velocity.Y = 1f;
					}
					if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
					{
						npc.velocity.Y = -1f;
					}
				}
			}

			if (Main.dayTime && (double)npc.position.Y <= Main.worldSurface * 16.0)
			{
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
				npc.directionY = -1;
				if (npc.velocity.Y > 0f)
				{
					npc.direction = 1;
				}
				npc.direction = -1;
				if (npc.velocity.X > 0f)
				{
					npc.direction = 1;
				}
			}
			else
			{
				npc.TargetClosest();
			}

			float speedX = 4f;
			float speedY = 1.5f;
			speedX *= 1f + (1f - npc.scale);
			speedY *= 1f + (1f - npc.scale);

			if (npc.direction == -1 && npc.velocity.X > 0f - speedX)
			{
				npc.velocity.X -= 0.1f;
				if (npc.velocity.X > speedX)
				{
					npc.velocity.X -= 0.1f;
				}

				else if (npc.velocity.X > 0f)
				{
					npc.velocity.X += 0.05f;
				}

				if (npc.velocity.X < 0f - speedX)
				{
					npc.velocity.X = 0f - speedX;
				}
			}
			else if (npc.direction == 1 && npc.velocity.X < speedX)
			{
				npc.velocity.X += 0.1f;
				if (npc.velocity.X < 0f - speedX)
				{
					npc.velocity.X += 0.1f;
				}

				else if (npc.velocity.X < 0f)
				{
					npc.velocity.X -= 0.05f;
				}

				if (npc.velocity.X > speedX)
				{
					npc.velocity.X = speedX;
				}
			}

			if (npc.directionY == -1 && npc.velocity.Y > 0f - speedY)
			{
				npc.velocity.Y -= 0.04f;
				if (npc.velocity.Y > speedY)
				{
					npc.velocity.Y -= 0.05f;
				}
				else if (npc.velocity.Y > 0f)
				{
					npc.velocity.Y += 0.03f;
				}
				if (npc.velocity.Y < 0f - speedY)
				{
					npc.velocity.Y = 0f - speedY;
				}
			}

			else if (npc.directionY == 1 && npc.velocity.Y < speedY)
			{
				npc.velocity.Y += 0.04f;
				if (npc.velocity.Y < 0f - speedY)
				{
					npc.velocity.Y += 0.05f;
				}
				else if (npc.velocity.Y < 0f)
				{
					npc.velocity.Y -= 0.03f;
				}
				if (npc.velocity.Y > speedY)
				{
					npc.velocity.Y = speedY;
				}
			}
		}

	}
}
