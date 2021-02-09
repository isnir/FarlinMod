using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace farlinMod
{
	public static class GlowmaskUtils
	{
		public static void DrawNPCGlowMask(SpriteBatch spriteBatch, bool effNone, bool draw, NPC npc, Texture2D texture)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			if (effNone)
			{
				effects = SpriteEffects.None;
			}
			if (draw)
			{
				spriteBatch.Draw(
					texture,
					npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY),
					npc.frame,
					Color.White,
					npc.rotation,
					npc.frame.Size() / 2,
					npc.scale,
					effects,
					0
				);
			}
		}
	}
}
