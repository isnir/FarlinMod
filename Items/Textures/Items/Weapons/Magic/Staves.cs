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
		public override string Texture => "farlinMod/Items/Weapons/Textures/MagicStaffCorruptor";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("World Eater's Staff");
			Tooltip.SetDefault("More than a thousand bites");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.damage = 23;
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
			
			item.shoot = ModContent.ProjectileType<MagicProj_01>();
			item.shootSpeed = 14f;

			item.value = Item.sellPrice(gold: 1,silver: 20);
			item.rare = ItemRarityID.Orange;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vilethorn);
			recipe.AddIngredient(ItemID.VilePowder, 10);
			recipe.AddIngredient(ItemID.WormTooth, 3);
			recipe.AddIngredient(ItemID.MagicMissile);			
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
