sampler2D uImage0 : register(s0);
float2 uScreenResolution;       // screen width and height (in pixels)
float2 uScreenPosition;       // screen width and height (in pixels)
float2 uTargetPosition;   // the player's position on screen (in pixels)

float4 BlackHoleLensingPS(float2 coords : TEXCOORD0) : COLOR0
{
    float2 targetCoords = (uTargetPosition - uScreenPosition) / uScreenResolution;
    float2 centreCoords = (coords - targetCoords) * (uScreenResolution / uScreenResolution.y);

    // Calculate distance and angle from the “black hole” center.
    float radius = length(coords - targetCoords);
    float angle = atan2(coords.y - targetCoords.y, coords.x - targetCoords.x);
    
    // How much the light is bent.
    float bend = 0.005 / radius;
    
    // Apply the lensing effect.
    coords += -bend * float2(cos(angle), sin(angle));

    // Sample the scene texture.
    float4 col = tex2D(uImage0, coords);

    // Darken the area based on bending (simulate the black hole’s center).
    col *= smoothstep(1.0, 0.9, bend);

    // A little extra fade toward the right.

    // col = mix(vec4(0.0), col, smoothstep(0.05, 0.055, radius));
    // convert above to HLSL

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
