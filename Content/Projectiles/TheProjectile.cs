using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.ID;

namespace ThePurifier.Content.Projectiles
{
    public class TheProjectile : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 60;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            var filter = Filters.Scene["ThePurifier:BlackHole"];
            var shader = Filters.Scene["ThePurifier:BlackHole"].GetShader();

            if (Main.netMode != NetmodeID.Server && !Filters.Scene["ThePurifier:BlackHole"].IsActive())
            {
                Main.NewText("Activating BlackHole");
                Filters.Scene["ThePurifier:BlackHole"].GetShader().UseTargetPosition(Projectile.Center);
                Filters.Scene.Activate("ThePurifier:BlackHole", Projectile.Center);
            } 
            else
            {
                shader.UseTargetPosition(Projectile.Center);
            } 
        }

        public override void OnKill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["ThePurifier:BlackHole"].IsActive())
            {
                Filters.Scene["ThePurifier:BlackHole"].Deactivate();
            }
        } 
    } 
}
