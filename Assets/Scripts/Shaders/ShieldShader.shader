// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/ShieldShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_RimIntensity("Rim Intensity", Float) = 8
		_GridOpacity("Grid Opacity", Float) = 5
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100
		ZWrite Off
		Cull Off
		Blend One One

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		float2 uv : TEXCOORD0;
	};

	struct v2f
	{
		float2 uv : TEXCOORD0;
		float2 screenuv : TEXCOORD1;
		float4 vertex : SV_POSITION;
		float3 normal : TEXCOORD2;
		float3 viewDir: TEXCOORD3;
		float depth : TEXCOORD4;
	};

	sampler2D _MainTex;
	sampler2D _CameraDepthNormalsTexture;
	float4 _MainTex_ST;
	float4 _Color;
	float _RimIntensity;
	float _GridOpacity;

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		o.screenuv = ((o.vertex.xy / o.vertex.w) + 1) / 2;
		o.screenuv.y = 1 - o.screenuv.y;
		o.normal = UnityObjectToWorldNormal(v.normal);
		o.viewDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, v.vertex).xyz);
		o.depth = UnityObjectToViewPos(v.vertex).z * _ProjectionParams.w;
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 texCol = tex2D(_MainTex, (i.uv + float2(_Time.y/2, 0))) * fixed4(_Color.rgb, _GridOpacity);
		float screenDepth = DecodeFloatRG(tex2D(_CameraDepthNormalsTexture, i.screenuv).zw);
		float diff = screenDepth - i.depth;
		float intersect = 0;
		float NdotV = 1 - abs(dot(i.normal, normalize(i.viewDir))) * 2;


		float glow = max(NdotV, 0);

		// sample the texture
		fixed4 col = fixed4(lerp(_Color.rgb, fixed3(1,1,1), pow(glow, _RimIntensity)), pow(glow, _RimIntensity));
		fixed4 rim = fixed4(lerp(_Color.rgb, fixed3(1, 1, 1), NdotV), 0);

		//return pow(NdotV,2);
		//return col + _Color + texCol + rim;
		return col * col.a + _Color * _Color.a + texCol * texCol.a * _GridOpacity;
	}
		ENDCG
	}
	}
}
