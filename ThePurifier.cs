using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThePurifier
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class ThePurifier : Mod
	{
        public override void Load()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if(Main.dedServ)
            {
                return;
            }

            
            Asset<Effect> theShader = Assets.Request<Effect>("Content/Effects/TintRed");
            Filters.Scene["ThePurifier:TintRed"] = new Filter(new ScreenShaderData(theShader, "TintRedPass"), EffectPriority.VeryHigh);
            Filters.Scene["ThePurifier:TintRed"].Load();
           

            Asset<Effect> blackHoleShader = Assets.Request<Effect>("Content/Effects/BlackHole");
            Filters.Scene["ThePurifier:BlackHole"] = new Filter(new ScreenShaderData(blackHoleShader, "BlackHolePass"), EffectPriority.VeryHigh);
            Filters.Scene["ThePurifier:BlackHole"].Load();
            
            
            Main.NewText("Hello from ThePurifier");
        }

        public override void Unload()
        {
            base.Unload();
        }
    }


}
