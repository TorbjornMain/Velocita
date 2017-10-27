// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:34311,y:32749,varname:node_2865,prsc:2|diff-4939-OUT,spec-358-OUT,gloss-1813-OUT,normal-945-OUT,alpha-2891-OUT,disp-1789-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:31862,y:32284,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.01108347,c2:0.2053424,c3:0.3014706,c4:1;n:type:ShaderForge.SFN_Slider,id:358,x:32756,y:32444,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32616,y:32573,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_RgbToHsv,id:9819,x:31861,y:33777,varname:node_9819,prsc:2|IN-1836-RGB;n:type:ShaderForge.SFN_ValueProperty,id:9767,x:32510,y:34073,ptovrint:False,ptlb:TesselationValue,ptin:_TesselationValue,varname:node_9767,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:1789,x:32934,y:33820,varname:node_1789,prsc:2|A-4243-OUT,B-7162-OUT,C-740-OUT;n:type:ShaderForge.SFN_NormalVector,id:7162,x:31861,y:34022,prsc:2,pt:False;n:type:ShaderForge.SFN_Clamp01,id:8013,x:32161,y:33828,varname:node_8013,prsc:2|IN-9819-VOUT;n:type:ShaderForge.SFN_DepthBlend,id:9744,x:32832,y:32795,varname:node_9744,prsc:2|DIST-9106-OUT;n:type:ShaderForge.SFN_Color,id:8290,x:31862,y:32446,ptovrint:False,ptlb:FresnelColour,ptin:_FresnelColour,varname:node_8290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.2867647,c3:0.1681034,c4:1;n:type:ShaderForge.SFN_Fresnel,id:2360,x:32005,y:32626,varname:node_2360,prsc:2|EXP-9842-OUT;n:type:ShaderForge.SFN_Vector1,id:9842,x:31757,y:32626,varname:node_9842,prsc:2,v1:4;n:type:ShaderForge.SFN_Lerp,id:8125,x:32165,y:32514,varname:node_8125,prsc:2|A-6665-RGB,B-8290-RGB,T-2360-OUT;n:type:ShaderForge.SFN_Lerp,id:910,x:32433,y:32598,varname:node_910,prsc:2|A-6665-A,B-8290-A,T-2360-OUT;n:type:ShaderForge.SFN_Multiply,id:2891,x:33384,y:32832,varname:node_2891,prsc:2|A-910-OUT,B-7471-OUT;n:type:ShaderForge.SFN_Slider,id:8016,x:31541,y:32866,ptovrint:False,ptlb:PD Scaler,ptin:_PDScaler,varname:node_8016,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.1;n:type:ShaderForge.SFN_Vector1,id:6228,x:31713,y:32989,varname:node_6228,prsc:2,v1:0;n:type:ShaderForge.SFN_TexCoord,id:968,x:31976,y:32963,varname:node_968,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:1072,x:31976,y:32829,varname:node_1072,prsc:2|A-8016-OUT,B-6228-OUT;n:type:ShaderForge.SFN_Append,id:3473,x:31976,y:33100,varname:node_3473,prsc:2|A-6228-OUT,B-8016-OUT;n:type:ShaderForge.SFN_Subtract,id:6316,x:32281,y:32861,varname:node_6316,prsc:2|A-968-UVOUT,B-1072-OUT;n:type:ShaderForge.SFN_Subtract,id:8163,x:32281,y:33018,varname:node_8163,prsc:2|A-968-UVOUT,B-3473-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:7973,x:31371,y:33258,ptovrint:False,ptlb:Wave Texture,ptin:_WaveTexture,varname:node_7973,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:732a774bd1404054fbb8e00841c7d3b9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RgbToHsv,id:7387,x:32432,y:33218,varname:node_7387,prsc:2|IN-6403-RGB;n:type:ShaderForge.SFN_HsvToRgb,id:1053,x:32616,y:33218,varname:node_1053,prsc:2|H-7387-HOUT,S-6228-OUT,V-7387-VOUT;n:type:ShaderForge.SFN_RgbToHsv,id:1370,x:32455,y:33367,varname:node_1370,prsc:2|IN-6753-RGB;n:type:ShaderForge.SFN_HsvToRgb,id:8669,x:32639,y:33367,varname:node_8669,prsc:2|H-1370-HOUT,S-6228-OUT,V-1370-VOUT;n:type:ShaderForge.SFN_ValueProperty,id:6903,x:32752,y:33694,ptovrint:False,ptlb:NormalIntensity,ptin:_NormalIntensity,varname:node_6903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_HsvToRgb,id:5468,x:32639,y:33527,varname:node_5468,prsc:2|H-9819-HOUT,S-6228-OUT,V-9819-VOUT;n:type:ShaderForge.SFN_Append,id:2686,x:33049,y:33262,varname:node_2686,prsc:2|A-8421-OUT,B-5752-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8421,x:32820,y:33208,varname:node_8421,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1053-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5752,x:32820,y:33379,varname:node_5752,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8669-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7828,x:32839,y:33517,varname:node_7828,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5468-OUT;n:type:ShaderForge.SFN_Subtract,id:1365,x:33186,y:33370,varname:node_1365,prsc:2|A-2686-OUT,B-7828-OUT;n:type:ShaderForge.SFN_Multiply,id:9680,x:33161,y:33554,varname:node_9680,prsc:2|A-1365-OUT,B-6903-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:9581,x:33411,y:33393,varname:node_9581,prsc:2,min:0,max:1|IN-9680-OUT;n:type:ShaderForge.SFN_Append,id:945,x:33908,y:33234,varname:node_945,prsc:2|A-9581-OUT,B-4962-OUT;n:type:ShaderForge.SFN_Dot,id:1697,x:33472,y:33598,varname:node_1697,prsc:2,dt:0|A-9581-OUT,B-9581-OUT;n:type:ShaderForge.SFN_OneMinus,id:320,x:33816,y:33502,varname:node_320,prsc:2|IN-2184-OUT;n:type:ShaderForge.SFN_Sqrt,id:4962,x:33976,y:33460,varname:node_4962,prsc:2|IN-320-OUT;n:type:ShaderForge.SFN_Tex2d,id:1836,x:31622,y:33470,varname:node_1836,prsc:2,tex:732a774bd1404054fbb8e00841c7d3b9,ntxv:0,isnm:False|UVIN-968-UVOUT,TEX-7973-TEX;n:type:ShaderForge.SFN_Tex2d,id:6403,x:32221,y:33283,varname:node_6403,prsc:2,tex:732a774bd1404054fbb8e00841c7d3b9,ntxv:0,isnm:False|UVIN-6316-OUT,TEX-7973-TEX;n:type:ShaderForge.SFN_Tex2d,id:6753,x:32024,y:33406,varname:node_6753,prsc:2,tex:732a774bd1404054fbb8e00841c7d3b9,ntxv:0,isnm:False|UVIN-8163-OUT,TEX-7973-TEX;n:type:ShaderForge.SFN_ValueProperty,id:9106,x:32584,y:32987,ptovrint:False,ptlb:DepthEffectIntensity,ptin:_DepthEffectIntensity,varname:node_9106,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ConstantClamp,id:7471,x:33047,y:32879,varname:node_7471,prsc:2,min:0.4,max:1|IN-9744-OUT;n:type:ShaderForge.SFN_OneMinus,id:6577,x:33060,y:32683,varname:node_6577,prsc:2|IN-9744-OUT;n:type:ShaderForge.SFN_Add,id:4939,x:33588,y:32598,varname:node_4939,prsc:2|A-9136-OUT,B-8125-OUT;n:type:ShaderForge.SFN_Power,id:9136,x:33336,y:32625,varname:node_9136,prsc:2|VAL-6577-OUT,EXP-9020-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9020,x:33039,y:32526,ptovrint:False,ptlb:EdgeFresnel,ptin:_EdgeFresnel,varname:node_9020,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ConstantClamp,id:2184,x:33645,y:33598,varname:node_2184,prsc:2,min:0,max:1|IN-1697-OUT;n:type:ShaderForge.SFN_ValueProperty,id:740,x:31936,y:34236,ptovrint:False,ptlb:DisplacementScale,ptin:_DisplacementScale,varname:node_740,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:1323,x:32450,y:33777,varname:node_1323,prsc:2|A-8013-OUT,B-6890-OUT;n:type:ShaderForge.SFN_Vector1,id:6890,x:32290,y:33937,varname:node_6890,prsc:2,v1:2;n:type:ShaderForge.SFN_Subtract,id:4243,x:32641,y:33854,varname:node_4243,prsc:2|A-1323-OUT,B-4357-OUT;n:type:ShaderForge.SFN_Vector1,id:4357,x:32440,y:33999,varname:node_4357,prsc:2,v1:1;proporder:6665-358-1813-9767-8290-7973-8016-6903-9106-9020-740;pass:END;sub:END;*/

Shader "Shader Forge/WaveGeometry" {
    Properties {
        _Color ("Color", Color) = (0.01108347,0.2053424,0.3014706,1)
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _TesselationValue ("TesselationValue", Float ) = 4
        _FresnelColour ("FresnelColour", Color) = (0,0.2867647,0.1681034,1)
        _WaveTexture ("Wave Texture", 2D) = "white" {}
        _PDScaler ("PD Scaler", Range(0, 0.1)) = 0
        _NormalIntensity ("NormalIntensity", Float ) = 1
        _DepthEffectIntensity ("DepthEffectIntensity", Float ) = 2
        _EdgeFresnel ("EdgeFresnel", Float ) = 2
        _DisplacementScale ("DisplacementScale", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles ps4 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _FresnelColour;
            uniform float _PDScaler;
            uniform sampler2D _WaveTexture; uniform float4 _WaveTexture_ST;
            uniform float _NormalIntensity;
            uniform float _DepthEffectIntensity;
            uniform float _EdgeFresnel;
            uniform float _DisplacementScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_6228 = 0.0;
                float2 node_6316 = (i.uv0-float2(_PDScaler,node_6228));
                float4 node_6403 = tex2D(_WaveTexture,TRANSFORM_TEX(node_6316, _WaveTexture));
                float4 node_7387_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_7387_p = lerp(float4(float4(node_6403.rgb,0.0).zy, node_7387_k.wz), float4(float4(node_6403.rgb,0.0).yz, node_7387_k.xy), step(float4(node_6403.rgb,0.0).z, float4(node_6403.rgb,0.0).y));
                float4 node_7387_q = lerp(float4(node_7387_p.xyw, float4(node_6403.rgb,0.0).x), float4(float4(node_6403.rgb,0.0).x, node_7387_p.yzx), step(node_7387_p.x, float4(node_6403.rgb,0.0).x));
                float node_7387_d = node_7387_q.x - min(node_7387_q.w, node_7387_q.y);
                float node_7387_e = 1.0e-10;
                float3 node_7387 = float3(abs(node_7387_q.z + (node_7387_q.w - node_7387_q.y) / (6.0 * node_7387_d + node_7387_e)), node_7387_d / (node_7387_q.x + node_7387_e), node_7387_q.x);;
                float2 node_8163 = (i.uv0-float2(node_6228,_PDScaler));
                float4 node_6753 = tex2D(_WaveTexture,TRANSFORM_TEX(node_8163, _WaveTexture));
                float4 node_1370_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1370_p = lerp(float4(float4(node_6753.rgb,0.0).zy, node_1370_k.wz), float4(float4(node_6753.rgb,0.0).yz, node_1370_k.xy), step(float4(node_6753.rgb,0.0).z, float4(node_6753.rgb,0.0).y));
                float4 node_1370_q = lerp(float4(node_1370_p.xyw, float4(node_6753.rgb,0.0).x), float4(float4(node_6753.rgb,0.0).x, node_1370_p.yzx), step(node_1370_p.x, float4(node_6753.rgb,0.0).x));
                float node_1370_d = node_1370_q.x - min(node_1370_q.w, node_1370_q.y);
                float node_1370_e = 1.0e-10;
                float3 node_1370 = float3(abs(node_1370_q.z + (node_1370_q.w - node_1370_q.y) / (6.0 * node_1370_d + node_1370_e)), node_1370_d / (node_1370_q.x + node_1370_e), node_1370_q.x);;
                float4 node_1836 = tex2D(_WaveTexture,TRANSFORM_TEX(i.uv0, _WaveTexture));
                float4 node_9819_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_9819_p = lerp(float4(float4(node_1836.rgb,0.0).zy, node_9819_k.wz), float4(float4(node_1836.rgb,0.0).yz, node_9819_k.xy), step(float4(node_1836.rgb,0.0).z, float4(node_1836.rgb,0.0).y));
                float4 node_9819_q = lerp(float4(node_9819_p.xyw, float4(node_1836.rgb,0.0).x), float4(float4(node_1836.rgb,0.0).x, node_9819_p.yzx), step(node_9819_p.x, float4(node_1836.rgb,0.0).x));
                float node_9819_d = node_9819_q.x - min(node_9819_q.w, node_9819_q.y);
                float node_9819_e = 1.0e-10;
                float3 node_9819 = float3(abs(node_9819_q.z + (node_9819_q.w - node_9819_q.y) / (6.0 * node_9819_d + node_9819_e)), node_9819_d / (node_9819_q.x + node_9819_e), node_9819_q.x);;
                float2 node_9581 = clamp(((float2((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_7387.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_6228)*node_7387.b).r,(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_1370.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_6228)*node_1370.b).r)-(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_9819.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_6228)*node_9819.b).r)*_NormalIntensity),0,1);
                float3 normalLocal = float3(node_9581,sqrt((1.0 - clamp(dot(node_9581,node_9581),0,1))));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float node_9744 = saturate((sceneZ-partZ)/_DepthEffectIntensity);
                float node_2360 = pow(1.0-max(0,dot(normalDirection, viewDirection)),4.0);
                float3 diffuseColor = (pow((1.0 - node_9744),_EdgeFresnel)+lerp(_Color.rgb,_FresnelColour.rgb,node_2360)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,(lerp(_Color.a,_FresnelColour.a,node_2360)*clamp(node_9744,0.4,1)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles ps4 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _FresnelColour;
            uniform float _PDScaler;
            uniform sampler2D _WaveTexture; uniform float4 _WaveTexture_ST;
            uniform float _NormalIntensity;
            uniform float _DepthEffectIntensity;
            uniform float _EdgeFresnel;
            uniform float _DisplacementScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                UNITY_FOG_COORDS(10)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_6228 = 0.0;
                float2 node_6316 = (i.uv0-float2(_PDScaler,node_6228));
                float4 node_6403 = tex2D(_WaveTexture,TRANSFORM_TEX(node_6316, _WaveTexture));
                float4 node_7387_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_7387_p = lerp(float4(float4(node_6403.rgb,0.0).zy, node_7387_k.wz), float4(float4(node_6403.rgb,0.0).yz, node_7387_k.xy), step(float4(node_6403.rgb,0.0).z, float4(node_6403.rgb,0.0).y));
                float4 node_7387_q = lerp(float4(node_7387_p.xyw, float4(node_6403.rgb,0.0).x), float4(float4(node_6403.rgb,0.0).x, node_7387_p.yzx), step(node_7387_p.x, float4(node_6403.rgb,0.0).x));
                float node_7387_d = node_7387_q.x - min(node_7387_q.w, node_7387_q.y);
                float node_7387_e = 1.0e-10;
                float3 node_7387 = float3(abs(node_7387_q.z + (node_7387_q.w - node_7387_q.y) / (6.0 * node_7387_d + node_7387_e)), node_7387_d / (node_7387_q.x + node_7387_e), node_7387_q.x);;
                float2 node_8163 = (i.uv0-float2(node_6228,_PDScaler));
                float4 node_6753 = tex2D(_WaveTexture,TRANSFORM_TEX(node_8163, _WaveTexture));
                float4 node_1370_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1370_p = lerp(float4(float4(node_6753.rgb,0.0).zy, node_1370_k.wz), float4(float4(node_6753.rgb,0.0).yz, node_1370_k.xy), step(float4(node_6753.rgb,0.0).z, float4(node_6753.rgb,0.0).y));
                float4 node_1370_q = lerp(float4(node_1370_p.xyw, float4(node_6753.rgb,0.0).x), float4(float4(node_6753.rgb,0.0).x, node_1370_p.yzx), step(node_1370_p.x, float4(node_6753.rgb,0.0).x));
                float node_1370_d = node_1370_q.x - min(node_1370_q.w, node_1370_q.y);
                float node_1370_e = 1.0e-10;
                float3 node_1370 = float3(abs(node_1370_q.z + (node_1370_q.w - node_1370_q.y) / (6.0 * node_1370_d + node_1370_e)), node_1370_d / (node_1370_q.x + node_1370_e), node_1370_q.x);;
                float4 node_1836 = tex2D(_WaveTexture,TRANSFORM_TEX(i.uv0, _WaveTexture));
                float4 node_9819_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_9819_p = lerp(float4(float4(node_1836.rgb,0.0).zy, node_9819_k.wz), float4(float4(node_1836.rgb,0.0).yz, node_9819_k.xy), step(float4(node_1836.rgb,0.0).z, float4(node_1836.rgb,0.0).y));
                float4 node_9819_q = lerp(float4(node_9819_p.xyw, float4(node_1836.rgb,0.0).x), float4(float4(node_1836.rgb,0.0).x, node_9819_p.yzx), step(node_9819_p.x, float4(node_1836.rgb,0.0).x));
                float node_9819_d = node_9819_q.x - min(node_9819_q.w, node_9819_q.y);
                float node_9819_e = 1.0e-10;
                float3 node_9819 = float3(abs(node_9819_q.z + (node_9819_q.w - node_9819_q.y) / (6.0 * node_9819_d + node_9819_e)), node_9819_d / (node_9819_q.x + node_9819_e), node_9819_q.x);;
                float2 node_9581 = clamp(((float2((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_7387.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_6228)*node_7387.b).r,(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_1370.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_6228)*node_1370.b).r)-(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_9819.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_6228)*node_9819.b).r)*_NormalIntensity),0,1);
                float3 normalLocal = float3(node_9581,sqrt((1.0 - clamp(dot(node_9581,node_9581),0,1))));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float node_9744 = saturate((sceneZ-partZ)/_DepthEffectIntensity);
                float node_2360 = pow(1.0-max(0,dot(normalDirection, viewDirection)),4.0);
                float3 diffuseColor = (pow((1.0 - node_9744),_EdgeFresnel)+lerp(_Color.rgb,_FresnelColour.rgb,node_2360)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * (lerp(_Color.a,_FresnelColour.a,node_2360)*clamp(node_9744,0.4,1)),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles ps4 
            #pragma target 3.0
            uniform sampler2D _WaveTexture; uniform float4 _WaveTexture_ST;
            uniform float _DisplacementScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float3 normalDir : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles ps4 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _Color;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _FresnelColour;
            uniform sampler2D _WaveTexture; uniform float4 _WaveTexture_ST;
            uniform float _DepthEffectIntensity;
            uniform float _EdgeFresnel;
            uniform float _DisplacementScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float node_9744 = saturate((sceneZ-partZ)/_DepthEffectIntensity);
                float node_2360 = pow(1.0-max(0,dot(normalDirection, viewDirection)),4.0);
                float3 diffColor = (pow((1.0 - node_9744),_EdgeFresnel)+lerp(_Color.rgb,_FresnelColour.rgb,node_2360));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
