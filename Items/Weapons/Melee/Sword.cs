using farlinMod.Projectiles.Melee;
using Microsoft.Xna.Framework;
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
			DisplayName.SetDefault("Flying Scarab");
			Tooltip.SetDefault("Use Right Click to throw."
				+ "\nYou have wait for the sword to return to be able to use it again.");
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
}