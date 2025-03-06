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
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 60;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
                
        private int rippleCount = 3;
        private int rippleSize = 5;
        private int rippleSpeed = 15;
        private float distortStrength = 100f;

        public override void AI()
        {
            if (Main.netMode != NetmodeID.Server && !Filters.Scene["ThePurifier:BlackHoleTwo"].IsActive())
            {
                Main.NewText("Activating BlackHoleTwo");
                Filters.Scene.Activate("ThePurifier:BlackHoleTwo", Projectile.Center).GetShader().UseTargetPosition(Projectile.Center);
            } 
            else
            {
                Filters.Scene["ThePurifier:BlackHoleTwo"].GetShader().UseTargetPosition(Projectile.Center);
            }
        }

        public override void OnKill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["ThePurifier:BlackHoleTwo"].IsActive())
            {
                Filters.Scene["ThePurifier:BlackHoleTwo"].Deactivate();
            }
        } 
    } 
}
