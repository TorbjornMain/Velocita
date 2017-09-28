Shader "Custom/BasicBloom"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Intensity("Bloom Intensity", Range(0, 1)) = 0.1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _Intensity;
			uniform float4 _MainTex_TexelSize;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 color = tex2D(_MainTex, i.uv);
				float2 texel = _MainTex_TexelSize.xy;
				for (int dx = -3; dx < 3; dx++)
				{
					for (int dy = -3; dy < 3; dy++)
					{
						fixed4 col = tex2D(_MainTex, i.uv + float2(dx*texel.x, dy*texel.y));
						color += col * _Intensity/(10.0f * (1 + pow(dx/3, 6) + pow(dy/3, 6)));
					}
				}
				return color;
			}
			ENDCG
		}
	}
}
