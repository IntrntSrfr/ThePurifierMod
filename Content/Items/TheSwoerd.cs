using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;

namespace ThePurifier.Content.Items
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class TheSwoerd : ModItem
	{
        public static Effect hole;

		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.ThePurifier.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ)
            {
                if (Filters.Scene["ThePurifier:BlackHole"].IsActive())
                {
                    return base.UseItem(player);
                }

                var shader = Filters.Scene["ThePurifier:BlackHole"].GetShader();
                shader.Shader.Parameters["uPlayerScreenPosition"].SetValue(new Vector2(Main.screenWidth / 3, Main.screenHeight / 3));
                shader.Shader.Parameters["uScreenResolution"].SetValue(new Vector2(Main.screenWidth, Main.screenHeight));
                Filters.Scene.Activate("ThePurifier:BlackHole");
                
            }
            return base.UseItem(player);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
