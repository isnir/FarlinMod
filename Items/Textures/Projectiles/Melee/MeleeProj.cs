using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.Projectiles.Melee
{
	public class MeleeProj_01 : ModProjectile
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeBouncingCalmMoonProj"; 
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
			drawOriginOffsetX += 6;
			drawOriginOffsetY += 6;

			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
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
				Dust dust = Dust.NewDustDirect(projectile.position + projectile.velocity, projectile.width / 2, projectile.height / 2, choice, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
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

	public class MeleeProj_02 : ModProjectile
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeBoomerangScarabProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarab Boomerang Projectile");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}		
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		public override void AI()
		{
			if (projectile.soundDelay == 0)
			{
				projectile.soundDelay = 8;
				Main.PlaySound(SoundID.Item7, projectile.position);
			}

			if (projectile.ai[0] == 0f)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] >= 30f)
				{
					projectile.ai[0] = 1f;
					projectile.ai[1] = 0f;
					projectile.netUpdate = true;
				}
			}
			else
			{
				projectile.tileCollide = false;
				float num43 = 9f;
				float num44 = 0.4f;
				Vector2 vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num45 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector2.X;
				float num46 = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - vector2.Y;
				float num47 = (float)Math.Sqrt(num45 * num45 + num46 * num46);
				if (num47 > 3000f)
				{
					projectile.Kill();
				}
				num47 = num43 / num47;
				num45 *= num47;
				num46 *= num47;

				if (projectile.velocity.X < num45)
				{
					projectile.velocity.X += num44;
					if (projectile.velocity.X < 0f && num45 > 0f)
					{
						projectile.velocity.X += num44;
					}
				}
				else if (projectile.velocity.X > num45)
				{
					projectile.velocity.X -= num44;
					if (projectile.velocity.X > 0f && num45 < 0f)
					{
						projectile.velocity.X -= num44;
					}
				}
				if (projectile.velocity.Y < num46)
				{
					projectile.velocity.Y += num44;
					if (projectile.velocity.Y < 0f && num46 > 0f)
					{
						projectile.velocity.Y += num44;
					}
				}
				else if (projectile.velocity.Y > num46)
				{
					projectile.velocity.Y -= num44;
					if (projectile.velocity.Y > 0f && num46 < 0f)
					{
						projectile.velocity.Y -= num44;
					}
				}

				if (Main.myPlayer == projectile.owner)
				{
					Rectangle rectangle = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
					Rectangle value2 = new Rectangle((int)Main.player[projectile.owner].position.X, (int)Main.player[projectile.owner].position.Y, Main.player[projectile.owner].width, Main.player[projectile.owner].height);
					if (rectangle.Intersects(value2))
					{
						projectile.Kill();
					}
				}
			}
			projectile.spriteDirection = projectile.direction;
			projectile.rotation += 0.5f * (float)projectile.direction;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			projectile.ai[0] = 1f;

			projectile.velocity.X = 0f - projectile.velocity.X;
			projectile.velocity.Y = 0f - projectile.velocity.Y;

			projectile.netUpdate = true;
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			return false;
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.ai[0] == 0f)
			{
				projectile.velocity.X = 0f - projectile.velocity.X;
				projectile.velocity.Y = 0f - projectile.velocity.Y;
				projectile.netUpdate = true;
			}
			projectile.ai[0] = 1f;
		}

		public override void ModifyHitPvp(Player target, ref int damage, ref bool crit)
		{
			if (projectile.ai[0] == 0f)
			{
				projectile.velocity.X = 0f - projectile.velocity.X;
				projectile.velocity.Y = 0f - projectile.velocity.Y;
				projectile.netUpdate = true;
			}
			projectile.ai[0] = 1f;
		}
	}
	public class MeleeProj_03 : ModProjectile
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeArkhalisSightProj"; 
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 28;			
		}
		public override void SetDefaults()
		{
			projectile.width = 60;
			projectile.height = 58;			
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			float num = (float)Math.PI / 2f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter);

			num = 0f;
			if (projectile.spriteDirection == -1)
			{
				num = (float)Math.PI;
			}
			if (++projectile.frame >= Main.projFrames[projectile.type])
			{
				projectile.frame = 0;
			}
			projectile.soundDelay--;
			if (projectile.soundDelay <= 0)
			{
				Main.PlaySound(SoundID.Item1, projectile.Center);
				projectile.soundDelay = 20;
			}
			if (Main.myPlayer == projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					float num33 = 1f;
					if (player.inventory[player.selectedItem].shoot == projectile.type)
					{
						num33 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
					}
					Vector2 vector8 = Main.MouseWorld - vector;
					vector8.Normalize();
					if (vector8.HasNaNs())
					{
						vector8 = Vector2.UnitX * player.direction;
					}
					vector8 *= num33;
					if (vector8.X != projectile.velocity.X || vector8.Y != projectile.velocity.Y)
					{
						projectile.netUpdate = true;
					}
					projectile.velocity = vector8;
				}
				else
				{
					projectile.Kill();
				}
			}
			Vector2 vector9 = projectile.Center + projectile.velocity * 3f;			

			projectile.position = player.RotatedRelativePoint(player.MountedCenter) - projectile.Size / 2f;
			projectile.rotation = projectile.velocity.ToRotation() + num;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * (float)projectile.direction, projectile.velocity.X * (float)projectile.direction);

			if (projectile.alpha != 0)
			{
				return;
			}				
		}
		public override Color? GetAlpha(Color lightColor)
		{
			Color value = Color.Lerp(lightColor, Color.White, 0.95f);
			value.A = 128;
			return value * (1f - (float)projectile.alpha / 255f);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 10;
		}
	}
	public class MeleeProj_04 : ModProjectile
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeJavelinScarab";
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.timeLeft = 120;
		}
		public override void AI()
		{
			projectile.spriteDirection = projectile.direction;
			projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
			if (projectile.ai[0] >= 30f)
			{
				projectile.ai[0] = 30f;
				projectile.velocity.Y = projectile.velocity.Y + 0.6f;
			}
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts

			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;

			const int NUM_DUSTS = 20;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < NUM_DUSTS; i++)
			{
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 24);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}
		}
	}
	public class MeleeProj_05 : ModProjectile
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeDefaultReaverProj";
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 3;
		}
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 200;
			projectile.melee = true;
			projectile.ignoreWater = true;

			drawOffsetX = -19;
			drawOriginOffsetY = -16;
			drawOriginOffsetX = 0;
		}
		public override void AI()
		{
			DelegateMethods.v3_1 = new Vector3(0.6f, 1f, 1f) * 0.2f;
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * 10f, 8f, DelegateMethods.CastLightOpen);

			if (projectile.alpha > 0)
			{
				Main.PlaySound(SoundID.Item9, projectile.Center);
				projectile.alpha = 0;
				projectile.scale = 1.1f;
				projectile.frame = Main.rand.Next(3);
				float num101 = 16f;
				for (int num102 = 0; (float)num102 < num101; num102++)
				{
					Vector2 spinningpoint5 = Vector2.UnitX * 0f;
					spinningpoint5 += -Vector2.UnitY.RotatedBy((float)num102 * ((float)Math.PI * 2f / num101)) * new Vector2(1f, 4f);
					spinningpoint5 = spinningpoint5.RotatedBy(projectile.velocity.ToRotation());
					int num103 = Dust.NewDust(projectile.Center, 0, 0, 89);
					Main.dust[num103].scale = 1.5f;
					Main.dust[num103].alpha = 170;
					Main.dust[num103].noGravity = true;
					Main.dust[num103].position = projectile.Center + spinningpoint5;
					Main.dust[num103].velocity = projectile.velocity * 0f + spinningpoint5.SafeNormalize(Vector2.UnitY) * 1f;
				}
			}
		}
        public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			int num569 = Main.rand.Next(4, 10);
			for (int num570 = 0; num570 < num569; num570++)
			{
				int num571 = Dust.NewDust(projectile.Center, 0, 0, 89, 0f, 0f, 170);
				Dust dust171 = Main.dust[num571];
				Dust dust2 = dust171;
				dust2.velocity *= 1.6f;
				Main.dust[num571].velocity.Y -= 1f;
				dust171 = Main.dust[num571];
				dust2 = dust171;
				dust2.velocity += -projectile.velocity * (Main.rand.NextFloat() * 2f - 1f) * 0.5f;
				Main.dust[num571].scale = 0.8f;
				Main.dust[num571].fadeIn = 0.5f;
				Main.dust[num571].noGravity = true;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			projectile.rotation = projectile.velocity.ToRotation() + (float)Math.PI / 4f;
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)(projectile.spriteDirection == 1 ? sourceRectangle.Width - 19 : 19);

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);					
			return false;
		}
		public override Color? GetAlpha(Color lightColor)
        {
			return new Color(53, 255, 198, 0) * projectile.Opacity;
		}
    }
}
