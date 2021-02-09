using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.Projectiles.Melee
{
    public class MeleeProjExtra_01 : ModProjectile
    {
		public override string Texture => "farlinMod/Projectiles/Textures/ExtraMeleeDungeonProjectile";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calm Moon Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.alpha = 255;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.timeLeft = 100;
			projectile.penetrate = 2;
		}
        public override void AI()
        {
			//Dust Effect
			int choice = Main.rand.Next(2); // choose a random number: 0 or 1.
			if (choice == 0) // use that number to select dustID: 29 or 59
			{
				choice = 29;
			}
			else
			{
				choice = 59;
			}
			for (int k = 0; k < 2; k++)
			{
				Dust dust = Dust.NewDustDirect(projectile.position  + projectile.velocity, projectile.width /2, projectile.height /2, choice, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
				dust.scale = 1.2f;
				dust.noGravity = true;
			}

			projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
			if (projectile.ai[0] >= 15f)
			{
				projectile.ai[0] = 15f;
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			int b = 3;
			b--;
			if (b <= 0)
			{
				projectile.Kill();
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
			}
			return false;
		}		
		public override void Kill(int timeLeft)
		{		
			//Dust Effect
			for (int k = 0; k < 20; k++)
			{
				Dust dust = Dust.NewDustDirect(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				dust.scale = 1.6f;
				dust.noGravity = true;
			}
		}
	}
}
