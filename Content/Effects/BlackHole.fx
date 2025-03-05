sampler2D uImage0 : register(s0);
float2 uScreenResolution;       // screen width and height (in pixels)
float2 uPlayerScreenPosition;   // the player's position on screen (in pixels)
float uTime;                    // time, if you need it for animations

float4 BlackHoleLensingPS(float2 coords : TEXCOORD0) : COLOR0
{
    // Convert texture coords (0-1) to actual screen coordinates.
    float2 fragCoord = coords * uScreenResolution;

    // Create a normalized coordinate system similar to Shadertoy.
    float2 uv = (fragCoord - 0.5 * uScreenResolution) / uScreenResolution.x + float2(0.5, 0.5);

    // Use the player's screen position in a similar normalized space.
    float2 pos = (uPlayerScreenPosition - 0.5 * uScreenResolution) / uScreenResolution.x + float2(0.5, 0.5);

    // Calculate distance and angle from the “black hole” center.
    float radius = length(uv - pos);
    float angle = atan2(uv.y - pos.y, uv.x - pos.x);
    
    // How much the light is bent.
    float bend = 0.005 / radius;
    
    // Apply the lensing effect.
    uv += -bend * float2(cos(angle), sin(angle));

    // Sample the scene texture.
    float4 col = tex2D(uImage0, uv);

    // Darken the area based on bending (simulate the black hole’s center).
    col *= smoothstep(1.0, 0.9, bend);

    // A little extra fade toward the right.
    col *= smoothstep(1.0, 0.0, uv.x);

    return col;
}

technique Technique1
{
    pass BlackHolePass
    {
        PixelShader = compile ps_2_0 BlackHoleLensingPS();
    }
}
