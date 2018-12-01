Shader "Custom/Water" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Transparency ("Transparency", Range(0,1)) = 0.5
	}
	SubShader
    {
        Tags { "Queue" = "Transparent" }

        GrabPass
        {
            "_BackgroundTexture"
        }

        Pass
        {        
            ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 grabPos : TEXCOORD0;
                float2 uv : TEXCOORD1;
                float4 pos : SV_POSITION;
            };
                       
            sampler2D _MainTex;
            float4 _Color;
            float _Transparency;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.pos);
                o.uv = v.texcoord;                                
                return o;
            }

            sampler2D _BackgroundTexture;

            half4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv + float2(_Time.x, _Time.x);                        
                        
                //_WorldSpaceLightPos0                        
                        
                half4 bgColor = tex2Dproj(_BackgroundTexture, i.grabPos);
                half4 texColor = tex2D(_MainTex, uv);
                half4 color = lerp(texColor * _Color, bgColor, _Transparency);
                                                                
                return color;
            }
            ENDCG
        }

    }
	FallBack "Diffuse"
}
