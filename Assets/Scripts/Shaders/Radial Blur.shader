// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Radial Blur"
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
			uniform float Speed;

			fixed4 frag (v2f i) : SV_Target
			{
				
				float2 uv = 2 * (i.uv - float2(0.5, 0.5));
				float2 deltaTexCoord = float2(length(uv) * (uv/length(uv)));
				deltaTexCoord *= Speed/100 * pow(length(uv * 2), 2);
				float2 coord = uv;
				float illuminationDecay = 1.0;
				fixed4 col = tex2D(_MainTex, i.uv);//tex2D(_MainTex, i.uv);
				for (int i = 0; i < 50; i++)
				{
					coord -= deltaTexCoord;
					fixed4 texel = tex2D(_MainTex, (coord/2) + float2(0.5,0.5));//(coord/2) - float2(0.5, 0.5));
					texel *= illuminationDecay * 0.4;
					col += texel;
					illuminationDecay *= 0.8;
				}
				col *= 0.3;
				col = clamp(col, 0, 1);
				return col;
			}
			ENDCG
		}
	}
}
