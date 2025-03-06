sampler2D uImage0 : register(s0);
float2 uScreenResolution;       // screen width and height (in pixels)
float2 uScreenPosition;
// Note: We replace uPlayerScreenPosition with uTargetPosition for consistency,
// but you can keep the original name if preferred.
float2 uTargetPosition;         
float uTime;                    // time, if you need it for animations

float4 BlackHoleLensingPS(float4 position : SV_POSITION, float2 coords : TEXCOORD0) : COLOR0
{

    float2 targetCoords = (uTargetPosition - uScreenPosition) / uScreenResolution;
    float2 centreCoords = (coords - targetCoords) * (uScreenResolution / uScreenResolution.y);

    // Calculate distance and angle from the black hole center.
    float radius = length(centreCoords - targetCoords);
    float angle = atan2(centreCoords.y - targetCoords.y, centreCoords.x - targetCoords.x);
    
    // How much the light is bent.
    float bend = 0.01 / radius;
    
    // Apply the lensing effect.
    centreCoords += -bend * float2(cos(angle), sin(angle));
    
    // Sample the scene texture.
    float4 col = tex2D(uImage0, centreCoords);
    
    // Darken the area based on bending (simulate the black hole’s center).
    col *= smoothstep(1.0, 0.9, bend);
    
    col = lerp(float4(0.0, 0.0, 0.0, 0.0), col, smoothstep(0.05, 0.055, radius));
    
    return col;
}

technique Technique1
{
    pass BlackHolePass
    {
        PixelShader = compile ps_2_0 BlackHoleLensingPS();
    }
}
