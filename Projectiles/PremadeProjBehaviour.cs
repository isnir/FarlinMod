using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace farlinMod.Projectiles
{
	public abstract class SpearBehaviour : ModProjectile
	{
		protected float initialSpeed = 3f;
		protected float returnSpeed = 1f;
		protected float accelerationSpeed = 1f;
		protected float returnBreakFrame = 2f;

		/// <summary>
		/// Use Isso Para Criar Efeitos Do Tipo Dust, apenas Chamado Na Função AI().
		/// </summary>
		public virtual void CreateDust()
		{

		}

		/// <summary>
		/// Use Isso Para Criar Um Projetil Quando A Animação Da Lança Chegar Na Metade.
		/// </summary>
		public virtual void SpawnProjOnReturn()
		{

		}

		// In here the AI uses this example, to make the code more organized and readable
		// Also showcased in ExampleJavelinProjectile.cs
		public float movementFactor // Change this value to alter how fast the spear moves
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		// It appears that for this AI, only the ai0 field is used!
		public override void AI()
		{
			// Since we access the owner player instance so much, it's useful to create a helper local variable for this
			// Sadly, Projectile/ModProjectile does not have its own
			Player projOwner = Main.player[projectile.owner];
			// Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projectile.spriteDirection = projectile.direction; // Use if there is an correct sprite direction.
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			// As long as the player isn't frozen, the spear can move
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
				{
					movementFactor = initialSpeed; // Make sure the spear moves forward when initially thrown out
					projectile.netUpdate = true; // Make sure to netUpdate this spear
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / returnBreakFrame) // Somewhere along the item animation, make sure the spear moves back
				{
					movementFactor -= returnSpeed;
					SpawnProjOnReturn();
				}
				else // Otherwise, increase the movement factor
				{
					movementFactor += accelerationSpeed;
				}
			}
			// Change the spear position based off of the velocity and the movementFactor
			projectile.position += projectile.velocity * movementFactor;
			// When we reach the end of the animation, we can kill the spear projectile
			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}
			// Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
			// MathHelper.ToRadians(xx degrees here)
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			// Offset by 90 degrees here
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}

			CreateDust();
		}
	}

	public abstract class HomingBehaviour : ModProjectile
	{

		protected float maxHomigDistance = 400;
		protected float adjustValue = 6;
		/// <summary>
		/// Use Isso Para Criar Efeitos Do Tipo Dust, apenas Chamado Na Função AI().
		/// </summary>
		public virtual void CreateVisuals()
		{

		}

		public virtual void Behaviour()
        {

        }
		public override void AI()
		{			
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			bool hasTarget = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && !Main.npc[k].immortal)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < maxHomigDistance)
					{
						move = newMove;
						maxHomigDistance = distanceTo;
						hasTarget = true;
					}
				}
			}
			if (hasTarget)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}		

			Behaviour();
			CreateVisuals();
		}

		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > adjustValue)
			{
				vector *= adjustValue / magnitude;
			}
		}
	}
}
