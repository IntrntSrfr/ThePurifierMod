using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ThePurifier.Content.Projectiles;
using Terraria.DataStructures;

namespace ThePurifier.Content.Items
{
    public class TheGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.scale = 0.8f;
            Item.rare = ItemRarityID.Blue;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.knockBack = 2f;

            Item.value = 10000;
            Item.UseSound = SoundID.Item11;
            // Set the projectile type and speed
            Item.shoot = ModContent.ProjectileType<TheProjectile>();
            Item.shootSpeed = 5f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool CanShoot(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<TheProjectile>()] < 1;
        }

        public override bool CanUseItem(Player player)
        {
            Item.UseSound = CanShoot(player) ? SoundID.Item11 : null;
            return CanShoot(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<TheProjectile>(), damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset() {
			return new Vector2(2f, -2f);
		}
    } 
}
