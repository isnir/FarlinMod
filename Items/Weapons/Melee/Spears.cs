using farlinMod.Projectiles.Melee;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.Items.Weapons.Melee
{
	public class Spear_01 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearWood";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wood Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 5;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_01>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Spear_02 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearBorealwood";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boreal Wood Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_02>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BorealWood, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_03 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearEbonwood";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Lance"); 
		}
		public override void SetDefaults()
		{
			item.damage = 8;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 36;
			item.useTime = 36;
			item.shootSpeed = 3.7f;
			item.knockBack = 3f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_03>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ebonwood, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_04 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearShadewood";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadewood Fork"); 
		}
		public override void SetDefaults()
		{
			item.damage = 9;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 36;
			item.useTime = 36;
			item.shootSpeed = 3.7f;
			item.knockBack = 3.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_04>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shadewood, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_05 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearPalmwood";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Trident"); 
		}
		public override void SetDefaults()
		{
			item.damage = 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 36;
			item.useTime = 36;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_05>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalmWood, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_06 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearMahoganywood";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rich Mahogany Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 2.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = true; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_06>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_07 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearCopper";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copper Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 5;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 2.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_07>();
		}     
        public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_08 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearTin";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tin Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 7;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 2.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_08>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_09 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearIron";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 8;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 2.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_09>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 7);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_10 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearLead";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lead Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 9;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 2.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_10>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 7);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_11 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearSilver";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silver Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 9;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.9f;
			item.knockBack = 2.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_11>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 7);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_12 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearTungsten";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tungsten Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.9f;
			item.knockBack = 2.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_12>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBar, 7);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_13 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearGold";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 11;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_13>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_14 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearPlatinum";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_14>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_15 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearDemonite";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonite Spear"); 
		}
		public override void SetDefaults()
		{
			item.damage = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_15>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_16 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearIce";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Glaive"); 
		}
		public override void SetDefaults()
		{
			item.damage = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_16>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
	public class Spear_17 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearThorn";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorn"); 
		}
		public override void SetDefaults()
		{
			item.damage = 19;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_17>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_18 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearMolten";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Lance"); 
		}
		public override void SetDefaults()
		{
			item.damage = 23;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.7f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(silver: 10);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_18>();
		}
		public override bool CanUseItem(Player player)
		{
			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 17);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Spear_19 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearDungeon";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calm Moon Spear"); 
			Tooltip.SetDefault("Causes a water blast on hit");
		}
		public override void SetDefaults()
		{
			item.damage = 18;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 34;
			item.useTime = 34;
			item.shootSpeed = 3.7f;
			item.knockBack = 5.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(gold: 1);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_19>();
		}				
		public override bool CanUseItem(Player player)
		{			
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
	public class Spear_20 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/MeleeSpearScarab";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarab Glaive");
			Tooltip.SetDefault("Use Right Click to throw.");

		}
		public override void SetDefaults()
		{
			item.damage = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 34;
			item.useTime = 34;
			item.shootSpeed = 3.7f;
			item.knockBack = 5.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 50);

			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = false;

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearProjectile_20>();
		}		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 30;
				item.useAnimation = 30;
				item.shoot = ModContent.ProjectileType<MeleeProj_04>();
				item.shootSpeed = 14;
				return player.ownedProjectileCounts[item.shoot] < 1;
			}
			else
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 34;
				item.useAnimation = 34;
				item.shootSpeed = 3.7f;
				item.shoot = ModContent.ProjectileType<SpearProjectile_20>();
				return player.ownedProjectileCounts[ModContent.ProjectileType<MeleeProj_04>()] < 1;
			}
			return base.CanUseItem(player);
		}
	}
}