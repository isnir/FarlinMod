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
			npc.aiStyle = 2;
			aiType = NPCID.DemonEye;
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
	}
}
