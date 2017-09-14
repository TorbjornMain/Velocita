Shader "Hidden/BasicBloom"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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
			uniform float4 _MainTex_TexelSize;
			uniform float Speed;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 color = tex2D(_MainTex, i.uv);
				float2 texel = _MainTex_TexelSize.xy;
				[unroll(18)]
				for (int dx = -9; dx < 9; dx++)
				{
					[unroll(18)]
					for (int dy = -9; dy < 9; dy++)
					{
						fixed4 col = tex2D(_MainTex, i.uv + float2(dx*texel.x, dy*texel.y));
						color += (1.0 / (1.0 + 0.1*(pow(dx, 8) + pow(dy, 8))) * fixed4(pow(col, fixed4(10, 10, 10, 10))));
					}
				}
				return color;
			}
			ENDCG
		}
	}
}
