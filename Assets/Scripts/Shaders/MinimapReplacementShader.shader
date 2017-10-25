Shader "Unlit/MinimapReplacementShader"
{
	Properties
	{
		_MinimapColor("MinimapColor", Color) = (0,0,0,1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Track"="True" }
		LOD 100

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

			fixed4 _MinimapColor;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = _MinimapColor;
				return col;
			}
			ENDCG
		}
	}
}
