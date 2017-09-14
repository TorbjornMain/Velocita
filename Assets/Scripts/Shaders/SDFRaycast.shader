// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/SDFRaycast"
{
	Properties
	{
		_Steps("Resolution", Range(10, 300)) = 100
		_Color("Color", Color) = (1, 1, 1, 1)
		_Gloss("Gloss", Float) = 1
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
		// make fog work
#pragma multi_compile_fog
#pragma target 4.0

#include "UnityCG.cginc"
#include "Lighting.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f
	{
		UNITY_FOG_COORDS(1)
			float4 vertex : SV_POSITION;
		float3 worldPos: COLOR0;
		float3 modelPos: COLOR1;
	};

	int _Steps;
	fixed4 _Color;
	float _Gloss;


	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
		o.modelPos = v.vertex.xyz
			UNITY_TRANSFER_FOG(o,o.vertex);
		return o;
	}


	struct Ray {
		float3 Origin;
		float3 Dir;
	};

	struct AABB {
		float3 Min;
		float3 Max;
	};

	bool IntersectBox(Ray r, AABB aabb, out float t0, out float t1)
	{
		float3 invR = 1.0 / r.Dir;
		float3 tbot = invR * (aabb.Min - r.Origin);
		float3 ttop = invR * (aabb.Max - r.Origin);
		float3 tmin = min(ttop, tbot);
		float3 tmax = max(ttop, tbot);
		float2 t = max(tmin.xx, tmin.yz);
		t0 = max(t.x, t.y);
		t = min(tmax.xx, tmax.yz);
		t1 = min(t.x, t.y);
		return t0 <= t1;
	}

	float vmax(float3 v) {
		return max(max(v.x, v.y), v.z);
	}

	float vmin(float3 v) {
		return min(min(v.x, v.y), v.z);
	}

	float SDFSmoothMin(float a, float b, float k = 32)
	{
		float res = exp(-k*a) + exp(-k*b);
		return -log(max(0.0001,res)) / k;
	}

	
	
	float SDFSphere(float3 p, float3 centre, float radius)
	{
		return	length(p - centre) - radius;
	}

	float SDFBox(float3 p, float3 centre, float3 halfDim)
	{
		float3 d = abs(p - centre) - (halfDim);
		return length(max(d, float3(0,0,0))) + vmax(min(d, float3(0,0,0)));
	}


	float SDFMap(float3 p)
	{
		return SDFSmoothMin(SDFSmoothMin(SDFSphere(p, float3(0.5, 0.5, 0.7), 0.1), SDFSphere(p, float3(0.5, 0.5, 0.3), 0.1)), SDFBox(p, float3(0.5, 0.5, 0.5),float3(0.05, 0.05, 0.1)));
	}

	float3 SDFNorm(float3 p)
	{
		const float h = 0.01;
		float4 n = float4(normalize(float3(SDFMap(p + float3(h, 0, 0)) - SDFMap(p - float3(h, 0, 0)), SDFMap(p + float3(0, h, 0)) - SDFMap(p - float3(0, h, 0)), SDFMap(p + float3(0, 0, h)) - SDFMap(p - float3(0, 0, h)))), 0);
		return normalize(mul(unity_ObjectToWorld, n).xyz);
	}

	fixed4 lambert(float3 p, float3 n)
	{
		fixed3 lightDir = _WorldSpaceLightPos0.xyz;
		fixed3 lightCol = _LightColor0.rgb;

		float NdotL = max(dot(lightDir, n), 0);
		fixed4 c;
		c.rgb = (_Color.rgb * NdotL * lightCol) + (_Color.rgb * 0.2);
		c.a = 1;
		return c;
	}

	fixed4 specular(float3 p, float3 n)
	{
		fixed3 lightDir = _WorldSpaceLightPos0.xyz;
		float3 refl = reflect(normalize(mul(unity_ObjectToWorld, float4(p, 1)).xyz - _WorldSpaceCameraPos), n);
		return fixed4(1, 1, 1, 0) * pow(clamp(0, 1, dot(refl, n)), 6) * length(_LightColor0.rgb) * _Gloss;
	}

	fixed4 renderPoint(float3 p)
	{
		float3 n = SDFNorm(p);
		return lambert(p, n) + specular(p, n);
	}

	fixed4 frag(v2f i) : SV_Target
	{
		float3 worldViewDir = normalize(i.worldPos - _WorldSpaceCameraPos);
		float3 modelViewDir = normalize(mul(unity_WorldToObject, float4(worldViewDir, 0)).xyz);

		Ray r;
		r.Origin = i.modelPos;
		r.Dir = modelViewDir;
		AABB a;
		a.Min = float3(-1, -1, -1);
		a.Max = float3(1, 1, 1);
		float t0, t1;

		IntersectBox(r, a, t0, t1);


		float3 rayStart = (i.modelPos) + 0.5;
		float3 rayEnd = ((i.modelPos + modelViewDir * t1)) + 0.5;
		float3 step = (rayEnd - rayStart) / _Steps;


		fixed4 col = fixed4(0,0,0,0);

		for (int i = 0; i < _Steps; i++)
		{
			if (SDFMap(rayStart + step*i) < 0)
			{
				if (col.a < 1)
				{
					fixed4 sampleCol = renderPoint(rayStart + step*i);
					col.a += sampleCol.a;
					col.rgb = lerp(col.rgb, sampleCol.rgb, sampleCol.a);
				}
			}
		}

		// apply fog
		//UNITY_APPLY_FOG(i.fogCoord, col);
		return col;
	}
		ENDCG
	}
	}
}
