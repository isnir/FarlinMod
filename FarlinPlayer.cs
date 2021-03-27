using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace farlinMod
{
	public class FarlinPlayer : ModPlayer
	{
		public static FarlinPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<FarlinPlayer>();
		}
		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
		}
	}
}
