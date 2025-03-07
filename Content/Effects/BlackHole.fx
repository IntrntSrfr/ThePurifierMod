sampler2D uImage0 : register(s0);
float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;

float4 BlackHoleLensingPS(float2 coords : TEXCOORD0) : COLOR0
{
    float2 targetCoords = (uTargetPosition - uScreenPosition) / uScreenResolution;
    float2 centreCoords = (coords - targetCoords) * (uScreenResolution / uScreenResolution.y);

    float dist = length(coords - targetCoords);
    float angle = atan2(coords.y - targetCoords.y, coords.x - targetCoords.x);

    float bend = 0.005 / dist;
    
    coords += -bend * float2(cos(angle), sin(angle));

    float4 col = tex2D(uImage0, coords);

    col *= smoothstep(1.0, 0.9, bend);

    col = lerp(float4(0.0, 0.0, 0.0, 0.0), col, smoothstep(0.03, 0.045, dist));

    return col;
}

technique Technique1
{
    pass BlackHolePass
    {
        PixelShader = compile ps_2_0 BlackHoleLensingPS();
    }
}
