using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace farlinMod.Projectiles.Melee
{
    public class SpearProjectile_01 : SpearBehaviour
    {
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearWoodProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wood Spear Projectile");
		}    
        public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 1;
			returnBreakFrame = 2; 

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}

	public class SpearProjectile_02 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearBorealwoodProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boreal Wood Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 0.8f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_03 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearEbonwoodProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.45f;
			returnSpeed = 1f;
			returnBreakFrame = 3;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

	}
	public class SpearProjectile_04 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearShadewoodProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadewood Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.8f;
			returnSpeed = 0.8f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}		
	}
	public class SpearProjectile_05 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearPalmwoodProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.2f;
			returnSpeed = 1f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_06 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearMahoganywoodProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rich Mahogany Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.4f;
			returnSpeed = 1f;
			returnBreakFrame = 3;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}		
	}
	public class SpearProjectile_07 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearCopperProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copper Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.5f;
			returnSpeed = 0.8f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_08 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearTinProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tin Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;


			initialSpeed = 3f;
			accelerationSpeed = 1.5f;
			returnSpeed = 0.8f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_09 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearIronProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 0.9f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_10 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearLeadProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lead Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 0.9f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_11 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearSilverProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silver Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 1f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_12 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearTungstenProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tungsten Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 1f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_13 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearGoldProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.9f;
			returnSpeed = 1.2f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_14 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearPlatinumProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.9f;
			returnSpeed = 1.2f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
	public class SpearProjectile_15 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearDemoniteProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonite Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 2.6f;
			returnBreakFrame = 4;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

		public override void CreateDust()
        {
			//Dust Effect
			if (Main.rand.NextBool(2))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 14,
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 50, Scale: 1.2f);
				dust.velocity += projectile.velocity * 0.4f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(3))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 14,
					0, 0, 0, Scale: 1f);
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
		}
	}
	public class SpearProjectile_16 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearIceProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Glaive Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 120;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 1.6f;
			returnBreakFrame = 3;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

        public override void CreateDust()
        {
			//Dust Effect
			if (Main.rand.NextBool(2))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 92,
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 50, Scale: 1.2f);
				dust.noGravity = true;
				dust.velocity += projectile.velocity * 0.4f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(3))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 92,
					0, 0, 0, Scale: 1f);
				dust.noGravity = true;
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
		}
        public override void SpawnProjOnReturn()
        {
			if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
			{
				projectile.localAI[0] = 1f;
				Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X * movementFactor, projectile.Center.Y + projectile.velocity.Y * movementFactor, projectile.velocity.X * 1.8f, projectile.velocity.Y * 1.8f, ProjectileID.IceBolt, projectile.damage, projectile.knockBack, projectile.owner);
			}
		}
	}
	public class SpearProjectile_17 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearThornProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorn Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;

			initialSpeed = 3f;
			accelerationSpeed = 2f;
			returnSpeed = 1.6f;
			returnBreakFrame = 3;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

        public override void CreateDust()
        {
			//Dust Effect
			if (Main.rand.NextBool(3))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 39,
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 50, Scale: 1.2f);
				dust.velocity += projectile.velocity * 0.4f;
				dust.velocity *= 0.2f;
				dust.noGravity = true;
			}
			if (Main.rand.NextBool(4))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 39,
					0, 0, 0, Scale: 1f);
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Poisoned, 60);
		}
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
			target.AddBuff(BuffID.Poisoned, 30);
		}      
	}
	public class SpearProjectile_18 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearMoltenProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Lance Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 50;

			initialSpeed = 3f;
			accelerationSpeed = 2.1f;
			returnSpeed = 2.6f;
			returnBreakFrame = 3;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
        public override void CreateDust()
        {
			//Dust Effect
			if (Main.rand.NextBool(2))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, DustID.Fire,
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 50, Scale: 1.5f);
				dust.velocity += projectile.velocity * 0.4f;
				dust.velocity *= 0.2f;
				dust.noGravity = true;
			}
			if (Main.rand.NextBool(3))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, DustID.Fire,
					0, 0, 0, Scale: 1.8f);
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 30);
		}
	}
	public class SpearProjectile_19 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearDungeonProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calm Moon Spear Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 50;

			initialSpeed = 3f;
			accelerationSpeed = 1.6f;
			returnSpeed = 2.6f;
			returnBreakFrame = 3;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;

			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 12;
		}

        public override void CreateDust()
        {
			//Dust Effect
			if (Main.rand.NextBool(2))
			{
				int choice = Main.rand.Next(2); // choose a random number: 0 or 1.
				if (choice == 0) // use that number to select dustID: 29 or 59
				{
					choice = 29;
				}
				else
				{
					choice = 59;
				}
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, choice,
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 100, Scale: 1.5f);
				dust.velocity += projectile.velocity * 0.4f;
				dust.velocity *= 0.2f;
				dust.noGravity = true;
			}
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 2; i++)
				{
					// Calculate new speeds for other projectiles.
					// Rebound at 40% to 70% speed, plus a random amount between -8 and 8
					float speedX = Main.rand.Next(-1, 1) * projectile.velocity.X * Main.rand.NextFloat(.2f, .5f) + Main.rand.NextFloat(-8f, 8f);
					float speedY = projectile.velocity.Y * Main.rand.Next(20, 50) * 0.01f + Main.rand.Next(-20, 21) * 0.4f; // This is Vanilla code, a little more obscure.
																															// Spawn the Projectile.
					Projectile.NewProjectile(target.Center.X, target.Center.Y, speedX, speedY, ModContent.ProjectileType<MeleeProj_01>(), (int)(projectile.damage * 0.15), 0f, projectile.owner, 0f, 0f);
				}
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 3; i++)
				{
					// Calculate new speeds for other projectiles.
					// Rebound at 40% to 70% speed, plus a random amount between -8 and 8
					float speedX = Main.rand.Next(-1, 1) * projectile.velocity.X * Main.rand.NextFloat(.2f, .5f) + Main.rand.NextFloat(-8f, 8f);
					float speedY = projectile.velocity.Y * Main.rand.Next(20, 50) * 0.01f + Main.rand.Next(-20, 21) * 0.4f; // This is Vanilla code, a little more obscure.
																															// Spawn the Projectile.
					Projectile.NewProjectile(target.Center.X, target.Center.Y, speedX, speedY, ModContent.ProjectileType<MeleeProj_01>(), (int)(projectile.damage * 0.4), 0f, projectile.owner, 0f, 0f);
				}
			}
		}						
	}
	public class SpearProjectile_20 : SpearBehaviour
	{
		public override string Texture => "farlinMod/Projectiles/Textures/MeleeSpearScarabProj";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarab Glaive Projectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			initialSpeed = 3f;
			accelerationSpeed = 1.65f;
			returnSpeed = 1.2f;
			returnBreakFrame = 2;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
	}
}
