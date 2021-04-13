using Terraria;
using Terraria.ModLoader;

namespace FarlinMod.Dusts
{
	public class Dust_Hex : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale = 1f;
			dust.fadeIn = 0.5f;
		}
	}
}
