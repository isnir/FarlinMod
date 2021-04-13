using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FarlinMod.Dusts;

namespace farlinMod.Projectiles.Magic
{
	public class MagicProj_01 : ModProjectile
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MagicSpawnerCorruptorProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corruptor Projectile");
		}
		public override void SetDefaults()
		{
			projectile.alpha = 255;
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 30;
		}		
		public override void AI()
		{
			//Dust Effects
			if (projectile.alpha <= 200)
			{
				for (int i = 0; i < 4; i++)
				{
					float dustspeedModX = projectile.velocity.X / 4f * (float)i;
					float dustspeedModY = projectile.velocity.Y / 4f * (float)i;
					int dustBase = Dust.NewDust(projectile.position, projectile.width, projectile.height, 184);
					Main.dust[dustBase].position.X = projectile.Center.X - dustspeedModX;
					Main.dust[dustBase].position.Y = projectile.Center.Y - dustspeedModY;
					Dust dustPreMod = Main.dust[dustBase];
					Dust dustMod = dustPreMod;
					dustMod.velocity *= 0f;
					Main.dust[dustBase].scale = 0.7f;
				}
			}
			projectile.alpha -= 10;
			if (projectile.alpha <= 200)
			{
				projectile.alpha = 0;
			}
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 0.785f;
			//Behaviour						
			if (projectile.ai[0] != 10)
			{
				projectile.ai[0]++;
			}
			if (projectile.ai[0] >= 10 && projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 2; i++)
				{
					float projSpeedX = (float)Main.rand.Next(-5, 6) * 0.02f;
					float projSpeedY = (float)Main.rand.Next(-15, 16) * 0.02f;
					projSpeedX *= 10f;
					projSpeedY *= 10f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projSpeedX, projSpeedY, ModContent.ProjectileType<MagicProj_02>(), (int)((double)projectile.damage * 0.5), (int)((double)projectile.knockBack * 0.35), Main.myPlayer);
					projectile.ai[0] = 0;
				}
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)(projectile.spriteDirection == 1 ? sourceRectangle.Width - 20 : 20);

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

			return false;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y);
			for (int i = 0; i < 20; i++)
			{
				int dustBase = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184);
				Dust dustPreMod = Main.dust[dustBase];
				Dust dustMod = dustPreMod;
				dustMod.scale *= 1.1f;
				Main.dust[dustBase].noGravity = true;
			}
			for (int i = 0; i < 30; i++)
			{
				int dustBase = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 184);
				Dust dustPreMod = Main.dust[dustBase];
				Dust dustMod = dustPreMod;
				dustMod.velocity *= 2.5f;
				dustPreMod = Main.dust[dustBase];
				dustMod = dustPreMod;
				dustMod.scale *= 0.8f;
				Main.dust[dustBase].noGravity = true;
			}
		}
	}
	public class MagicProj_02 : ModProjectile
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MagicHomingCorruptorProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corruptor Seeker Projectile");
			ProjectileID.Sets.Homing[projectile.type] = true;
			Main.projFrames[projectile.type] = 3;

		}
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.timeLeft = 160;
			projectile.magic = true;
			projectile.extraUpdates = 3;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.ai[1] < 5f)
			{
				projectile.ai[1] += 1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.5f;
			}
			return false;
		}
		public override void AI()
		{
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 50;
			}
			else
			{
				projectile.extraUpdates = 0;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			for (int i = 0; i < 3; i++)
			{
				float dustSpeedModX = projectile.velocity.X / 3f * (float)i;
				float dustSpeedModY = projectile.velocity.Y / 3f * (float)i;
				int dustBase = Dust.NewDust(projectile.position, projectile.width, projectile.height, 184);
				Main.dust[dustBase].position.X = projectile.Center.X - dustSpeedModX;
				Main.dust[dustBase].position.Y = projectile.Center.Y - dustSpeedModY;
				Dust dustPreMod = Main.dust[dustBase];
				Dust dustMod = dustPreMod;
				dustMod.velocity *= 0f;
				Main.dust[dustBase].scale = 0.5f;
			}
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 3)
			{
				projectile.frame = 0;
			}

			float posX = projectile.position.X;
			float posY = projectile.position.Y;
			float distance = 100000f;
			bool hasTarget = false;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 30f)
			{
				projectile.ai[0] = 30f;
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].CanBeChasedBy(this))
					{
						float num381 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
						float num382 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
						float num383 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num381) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num382);
						if (num383 < 800f && num383 < distance && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height))
						{
							distance = num383;
							posX = num381;
							posY = num382;
							hasTarget = true;
						}
					}
				}
			}
			if (!hasTarget)
			{
				posX = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
				posY = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
			}

			float speedModX = 9f; //?
			float speedMod = 0.2f;

			Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			float vSpeedX = posX - vector.X;
			float vSpeedY = posY - vector.Y;
			float vSpeedXY = (float)Math.Sqrt(vSpeedX * vSpeedX + vSpeedY * vSpeedY);
			vSpeedXY = speedModX / vSpeedXY;
			vSpeedX *= vSpeedXY;
			vSpeedY *= vSpeedXY;
			if (projectile.velocity.X < vSpeedX)
			{
				projectile.velocity.X += speedMod;
				if (projectile.velocity.X < 0f && vSpeedX > 0f)
				{
					projectile.velocity.X += speedMod * 2f;
				}
			}
			else if (projectile.velocity.X > vSpeedX)
			{
				projectile.velocity.X -= speedMod;
				if (projectile.velocity.X > 0f && vSpeedX < 0f)
				{
					projectile.velocity.X -= speedMod * 2f;
				}
			}
			if (projectile.velocity.Y < vSpeedY)
			{
				projectile.velocity.Y += speedMod;
				if (projectile.velocity.Y < 0f && vSpeedY > 0f)
				{
					projectile.velocity.Y += speedMod * 2f;
				}
			}
			else if (projectile.velocity.Y > vSpeedY)
			{
				projectile.velocity.Y -= speedMod;
				if (projectile.velocity.Y > 0f && vSpeedY < 0f)
				{
					projectile.velocity.Y -= speedMod * 2f;
				}
			}
		}
	}

    public class MagicProj_03 : HomingBehaviour {

		public override string Texture => "farlinMod/Projectiles/Textures/MagicHomingHeartProj";
        public override void SetStaticDefaults()
        {
			Main.projFrames[projectile.type] = 3;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
        public override void SetDefaults()
        {
			projectile.height = 16;
			projectile.width = 16;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;

			maxHomigDistance = 250f;
			adjustValue = 8;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			Color value = Color.Lerp(lightColor, Color.White, 0.95f);
			value.A = 128;
			return value * (1f - (float)projectile.alpha / 255f);
		}
		public override void CreateVisuals()
        {
			if(projectile.alpha > 0)
            {
				projectile.alpha -= 50 ;				
            }
			if (projectile.alpha >= 50)
			{
				projectile.frame = Main.rand.Next(3);
				projectile.scale = Main.rand.NextFloat(1f,2f);
			}
		}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.Item54, projectile.Center);			
		}
    }

}