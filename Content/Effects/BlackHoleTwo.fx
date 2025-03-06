sampler2D uImage0 : register(s0);
float2 uScreenResolution;   // Screen resolution in pixels (e.g., 1920x1080)
float2 uScreenPosition;     // World coordinate of the screen's top-left (typically Main.screenPosition)
float2 uTargetPosition;     // World coordinate where the effect is centered (e.g., projectile.Center)
float uIntensity;           // Strength of the lensing effect (e.g., 0.2 for subtle pull)
float uRadius;              // Radius (in pixels) over which the effect is applied

float4 BlackHoleLensingPS(float2 coords : TEXCOORD0) : COLOR0
{

    float4 color = tex2D(uImage0, coords);
    color.r = saturate(color.r + 0.9);
    return color;
/* 
    float2 targetCoords = (uTargetPosition - uScreenPosition) / uScreenResolution;
    float2 centreCoords = (coords - targetCoords) * (uScreenResolution / uScreenResolution.y);
    
    // Compute the distance (in pixels) from the current pixel to the target.
    float d = length(centreCoords - targetCoords);
    
    // If within the effect radius, apply the lensing distortion.
    if (d < uRadius)
    {
        float4 color = tex2D(uImage0, coords);
        color.r = saturate(color.g + 0.5);
        return color;
    }
    else
    {
        float4 color = tex2D(uImage0, coords);
        color.r = saturate(color.r + 0.5);
        return color;
    } */
}

technique Technique1
{
    pass BlackHolePass
    {
        PixelShader = compile ps_2_0 BlackHoleLensingPS();
    }
}
