using farlinMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace farlinMod.Items.Weapons.Magic
{
    public class Magic_01 : ModItem
    {
        public override string Texture => "farlinMod/Items/Weapons/Textures/MagicArtifactHeartGun";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Blaster");
        }
        public override void SetDefaults()
        {
            item.damage = 24;
            item.magic = true;
            item.mana = 14;
            item.useTime = 24;
            item.useAnimation = 24;
            item.autoReuse = true;
            item.noMelee = true;

            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(gold: 1);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 20;
            item.height = 20;
            item.UseSound = SoundID.Item85;

            item.shoot = ModContent.ProjectileType<MagicProj_03>();
            item.shootSpeed = 14f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.SpaceGun);
            recipe.AddIngredient(ItemID.LifeCrystal, 3);
            recipe.AddIngredient(ItemID.Handgun);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            for (int i = 0; i < 3; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
