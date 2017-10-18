Shader "Custom/VelTransferShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ConductiveTex("Conductivity Texture", 2D) = "white" {}
		_PrevVelTex("Velocity Texture", 2D) = "white" {}
		_SampleResolution("SampleResolution", Int) = 256
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
			sampler2D _ConductiveTex;
			sampler2D _PrevVelTex;
			int _SampleResolution;
			float deltaTime;
			float timeScale;


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
				//fixed4 accelX = (((tex2D(_ConductiveTex, i.uv) + tex2D(_ConductiveTex, i.uv + float2(0.01, 0)))/2) * (tex2D(_MainTex, i.uv + float2(0.01, 0)) - tex2D(_MainTex, i.uv))) - (((tex2D(_ConductiveTex, i.uv - float2(0.01, 0)) + tex2D(_ConductiveTex, i.uv)) / 2) * (tex2D(_MainTex, i.uv ) - tex2D(_MainTex, i.uv - float2(0.01, 0))));
				//fixed4 accelY = (((tex2D(_ConductiveTex, i.uv) + tex2D(_ConductiveTex, i.uv + float2(0 , 0.01))) / 2) * (tex2D(_MainTex, i.uv + float2(0, 0.01)) - tex2D(_MainTex, i.uv))) - (((tex2D(_ConductiveTex, i.uv - float2(0, 0.01)) + tex2D(_ConductiveTex, i.uv)) / 2) * (tex2D(_MainTex, i.uv) - tex2D(_MainTex, i.uv - float2(0, 0.01))));
				//fixed3 accel = accelX.xyz + accelY.xyz;
				fixed4 accel = uncompress(tex2D(_MainTex, i.uv - float2(0.01, 0))) + uncompress(tex2D(_MainTex, i.uv + float2(0.01, 0))) + uncompress(tex2D(_MainTex, i.uv - float2(0, 0.01))) + uncompress(tex2D(_MainTex, i.uv + float2(0, 0.01))) - 4 * uncompress(tex2D(_MainTex, i.uv));
				accel.a = 1;
				float3 prevVel = uncompress(tex2D(_PrevVelTex, i.uv));
				return compress(fixed4((prevVel + timeScale * deltaTime * accel) * 0.99, 1));//((fixed4(prevVel + (accel * deltaTime * timeScale), 1)) + 1)/2 ;//tex2D(_PrevVelTex, i.uv) + fixed4(1,1,1,accel);// * deltaTime;// *deltaTime;//fixed4(1,1,1, (tex2D(_PrevVelTex, i.uv).a + (accel * deltaTime)));
			}
			ENDCG
		}
	}
}
