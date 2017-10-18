Shader "Custom/MagTransferShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_PrevMagTex("Magnitude Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha

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
			sampler2D _PrevMagTex;
			float deltaTime;

			fixed4 uncompress(fixed4 other)
			{
				fixed4 o = (other * 2) - 1;
				o.xyz *= other.a;
				o.a = 1;
				return o;
			}

			fixed4 compress(fixed4 other)
			{
				return (other + 1) / 2;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = fixed4(0,0,0,0);
				fixed4 prevCol = uncompress(tex2D(_PrevMagTex, i.uv));

				fixed4 vel = uncompress(tex2D(_MainTex, i.uv));
				
				col = compress((prevCol + vel * deltaTime) * 0.99);

				col.a = 1;
					
				return col;
			}
			ENDCG
		}
	}
}
