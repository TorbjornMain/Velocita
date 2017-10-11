// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SpeedTint"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_VingetteTexture("Vingette Template", 2D) = "white" {}
		_Speed("Speed", Float) = 0
		_Intensity("Intensity", Range(0,1)) = 0.8
		_RacerColor("Racer Color", Color) = (1,1,1,1)
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
			sampler2D _VingetteTexture;
			float _Speed;
			float _Intensity;
			fixed4 _RacerColor;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float2 tUV = ((i.uv - float2(0.5, 0.5)) * 2);
				if (length(tUV) > 1.8 - _Speed)
				{
					col += _RacerColor * ((_Intensity * (length(tUV) - (1.8 - _Speed)))) * tex2D(_VingetteTexture, i.uv);
					col.a = 1;
				}
				return col ;
			}
			ENDCG
		}
	}
}
