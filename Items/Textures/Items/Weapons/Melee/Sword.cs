using farlinMod.Projectiles.Melee;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.Items.Weapons.Melee
{
	public class Sword_01 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSwordScarab";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flying Scarab's Dagger");
			Tooltip.SetDefault("Use <right> to throw"
				+ "\nYou have wait for the sword to return to be able to use it again");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<MeleeProj_02>();	
			item.shootSpeed = 10f;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.noMelee = true;
				item.noUseGraphic = true;
				item.shoot = ModContent.ProjectileType<MeleeProj_02>();
				item.shootSpeed = 10;
				return player.ownedProjectileCounts[item.shoot] < 1;
			}
			else
			{
				item.noMelee = false;
				item.noUseGraphic = false;
				item.shoot = 0;
				return player.ownedProjectileCounts[ModContent.ProjectileType<MeleeProj_02>()] < 1;
			}
			return player.ownedProjectileCounts[item.shoot] < 1;
		}     		
		public override bool AltFunctionUse(Player player)
		{			
			return true;
		}
	}
	public class Sword_02 : ModItem
    {
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSwordSightGoldAL"; // AL = Animated Loop.
        public override void SetStaticDefaults()
        {
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
			DisplayName.SetDefault("King's Sight");
		}
        public override void SetDefaults()
        {
			item.width = 14;
			item.height = 38;
			item.useAnimation = 25;
			item.useTime = 15;
			item.useStyle = 5;
			item.rare = 2;
			item.noUseGraphic = true;
			item.channel = true;
			item.noMelee = true;
			item.damage = 11;
			item.knockBack = 4f;
			item.autoReuse = false;
			item.noMelee = true;
			item.melee = true;
			item.shoot = ModContent.ProjectileType<MeleeProj_03>();
			item.shootSpeed = 15f;
			item.value = 40000;
		}
        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldCrown);
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddIngredient(ItemID.Lens, 5);
			recipe.AddRecipeGroup("Farlin:ShadowScale",3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
	public class Sword_03 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSwordSightPlatAL"; // AL = Animated Loop.
		public override void SetStaticDefaults()
		{
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
			DisplayName.SetDefault("King's Sight");
		}
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 38;
			item.useAnimation = 25;
			item.useTime = 15;
			item.useStyle = 5;
			item.rare = 2;
			item.noUseGraphic = true;
			item.channel = true;
			item.noMelee = true;
			item.damage = 12;
			item.knockBack = 4f;
			item.autoReuse = false;
			item.noMelee = true;
			item.melee = true;
			item.shoot = ModContent.ProjectileType<MeleeProj_03>();
			item.shootSpeed = 15f;
			item.value = 40000;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumCrown);
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddIngredient(ItemID.Lens, 5);
			recipe.AddRecipeGroup("Farlin:ShadowScale",3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Sword_04 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSwordReaver";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence Reaver");
			Tooltip.SetDefault("Steals Essence on hit" 				
				+ "\nUse <right> to consume a charge of Essence and release a barrage of swords"
				+ "\nCan hold up to 3 charges of Essence");				
		}
		public override void SetDefaults()
		{
			item.damage = 30;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.alpha = 20;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.shoot = 0;
			item.shootSpeed = 10f;
		}
		int essenceStack = 0;
		int attackStack = 0;
        public override void HoldItem(Player player)
		{
			if (attackStack > 0)
			{
				for (float ik = 0.8f; ik < attackStack; ik++)
				{
					float t = (float)Main.GlobalTime * 1f + ik;
					// Generate flame particles
					int dust = Dust.NewDust(player.position, 1, 1, 89, 0, 0, 100, Color.White, 0.75f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0;
					Main.dust[dust].position = player.Center + new Vector2((float)Math.Sin(2 * t) / 2f, -(float)Math.Cos(3 * t) / 3f) * 35f;
					Main.playerDrawDust.Add(dust);
				}
			}						
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			if (player.altFunctionUse != 2)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 89, 0f, 0f, 170, default(Color), 0.8f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity.X += player.direction * 2f;
				Main.dust[dust].velocity.Y += 0.2f;
			}
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			if (target.lifeMax > 5 && !target.immortal && item.shoot != ModContent.ProjectileType<MeleeProj_05>() && attackStack < 3 && player.whoAmI == Main.myPlayer)
			{
				essenceStack += 1;
				Main.PlaySound(SoundID.Item103, (int)target.position.X, (int)target.position.Y) ;
				//Dust Effect
				for (int k = 0; k < 20; k++)
				{
					Dust dust = Dust.NewDustDirect(target.position, target.width, player.height, 89, 0, 0, 170, default, 1.2f);
					dust.noGravity = true;
				}
			}
			if(essenceStack >= 3)
            {
				essenceStack = 0;
				attackStack++;				
			}
			if(attackStack >= 3)
            {
				attackStack = 3;
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{		
			Color value = Color.Lerp(lightColor, Color.White, 0.95f);
			value.A = 128;
			return value * (1f - (float)item.alpha / 155f);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float mousePosX = (float)Main.mouseX + Main.screenPosition.X - position.X;
			float mousePosY = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
			float speed = item.shootSpeed;
			float spawnPos = Main.rand.NextFloat() * ((float)Math.PI * 2f);
			float hitbotX = 20f;
			float hitbotY = 20f;
			Vector2 spawnHitbot = position + spawnPos.ToRotationVector2() * MathHelper.Lerp(hitbotX, hitbotY, Main.rand.NextFloat());
			for (int num199 = 0; num199 < 50; num199++)
			{
				spawnHitbot = position + spawnPos.ToRotationVector2() * MathHelper.Lerp(hitbotX, hitbotY, Main.rand.NextFloat());
				if (Collision.CanHit(position, 0, 0, spawnHitbot + (spawnHitbot - position).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
				{
					break;
				}
				spawnPos = Main.rand.NextFloat() * ((float)Math.PI * 2f);
			}
			Vector2 safeVelocity = Main.MouseWorld - spawnHitbot;
			Vector2 safeMousePos = new Vector2(mousePosX, mousePosY).SafeNormalize(Vector2.UnitY) * speed;
			safeVelocity = safeVelocity.SafeNormalize(safeMousePos) * speed;
			safeVelocity = Vector2.Lerp(safeVelocity, safeMousePos, 0.25f);
			Projectile.NewProjectile(spawnHitbot, safeVelocity, type, damage, knockBack, player.whoAmI);
			return false;
        }
        public override bool CanUseItem(Player player)
		{			
			if (player.altFunctionUse == 2 && attackStack > 0)
			{				

				Item.staff[item.type] = true;
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useAnimation = 18;
				item.useTime = 6;
				item.reuseDelay = item.useAnimation + 6;
				item.shoot = ModContent.ProjectileType<MeleeProj_05>();
				attackStack -= 1;				
			}
			else
			{
				Item.staff[item.type] = false;
				item.useTime = 26;
				item.useAnimation = 26;
				item.reuseDelay = 0;
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.shoot = 0;
			}
			return true;
		}
		public override bool AltFunctionUse(Player player)
		{
			if (attackStack < 1)
				return false;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.Bone ,50);
			recipe.AddIngredient(ItemID.FieryGreatsword);
			recipe.AddIngredient(ItemID.BladeofGrass);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();		
		}
	}
}