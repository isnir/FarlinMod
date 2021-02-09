using farlinMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.Items.Weapons.Magic
{
    public class Staff_01 : ModItem
    {
		public override string Texture => "farlinMod/Items/Weapons/Textures/StaffChaosFlame";
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Chaotic Flame Portal Staff");
			Tooltip.SetDefault("Summons a portal from the Underworld"
				+ "\nonly one portal can exist at a time");
			Item.staff[item.type] = true;
		}
        public override void SetDefaults()
        {
			item.damage = 32;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.shootSpeed = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(silver: 10);

			item.magic = true;
			item.noMelee = true; 
			//item.noUseGraphic = true;
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<MagicProj_01>();
		}
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Flamelash);
			recipe.AddIngredient(ItemID.HellstoneBar, 13);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class Staff_02 : ModItem
	{
		public override string Texture => "farlinMod/Items/Weapons/Textures/StaffCorruptor";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("World Eater's Staff");
			Tooltip.SetDefault("Test Item");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.damage = 67;
			item.knockBack = 5f;
			item.magic = true;
			item.mana = 2;
			item.noMelee = true;

			item.width = 18;
			item.height = 20;
			item.useAnimation = 30;
			item.useTime = 30;
			item.autoReuse = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = SoundID.Item39;
			
			item.shoot = ModContent.ProjectileType<MagicProj_03>();
			item.shootSpeed = 14f;

			item.value = Item.sellPrice(0, 20);
			item.rare = ItemRarityID.Expert;
		}
	}
}
