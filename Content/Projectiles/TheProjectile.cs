using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.ID;

namespace ThePurifier.Content.Projectiles
{/*
    public class DistortionProjectile : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
                
        private int rippleCount = 3;
        private int rippleSize = 5;
        private int rippleSpeed = 15;
        private float distortStrength = 100f;

        public override void AI()
        {
            // ai[0] = state
            // 0 = unexploded
            // 1 = exploded

            if (projectile.timeLeft <= 180)
            {
                if (projectile.ai[0] == 0)
                {
                    projectile.ai[0] = 1; // Set state to exploded
                    projectile.alpha = 255; // Make the projectile invisible.
                    projectile.friendly = false; // Stop the bomb from hurting enemies.

                    if (Main.netMode != NetmodeID.Server && !Filters.Scene["Shockwave"].IsActive())
                    {
                        Filters.Scene.Activate("Shockwave", projectile.Center).GetShader().UseColor(rippleCount, rippleSize, rippleSpeed).UseTargetPosition(projectile.Center);
                    }
                }

                if (Main.netMode != NetmodeID.Server && Filters.Scene["Shockwave"].IsActive())
                {
                    float progress = (180f - projectile.timeLeft) / 60f;
                    Filters.Scene["Shockwave"].GetShader().UseProgress(progress).UseOpacity(distortStrength * (1 - progress / 3f));
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["Shockwave"].IsActive())
            {
                Filters.Scene["Shockwave"].Deactivate();
            }
        } 
    } */
}
