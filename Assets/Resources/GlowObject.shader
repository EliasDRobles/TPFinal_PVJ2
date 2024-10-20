Shader "Custom/GlowObject"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (.002, 0.03)) = .005
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"Queue"="Overlay" }
        Pass
        {
            Name "OUTLINE"
            Tags {"LightMode" = "Always"}
            Cull Front
            ZWrite On
            ZTest LEqual
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            uniform float _Outline;
            uniform float4 _OutlineColor;

            v2f vert (appdata_t v)
            {
                // just copy pos and color, no interpolated normals or uvs needed
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                float3 norm = mul((float3x3) unity_ObjectToWorld, v.normal);
                float3 offs = norm * _Outline;
                o.pos.xy += offs.xy * o.pos.w;
                o.color = _OutlineColor;
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
                return i.color;
            }
            ENDCG
        }
    }
    SubShader
    {
        Tags {"Queue"="Geometry"}
        Pass
        {
            Name "BASE"
            Tags {"LightMode" = "Always"}
            Cull Back
            ZWrite On
            ZTest LEqual
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            uniform float4 _Color;

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
                half4 texcol = tex2D(_MainTex, i.uv) * _Color;
                return texcol;
            }
            ENDCG
        }
    }
}

