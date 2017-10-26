// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33330,y:32546,varname:node_3138,prsc:2|emission-9428-OUT,clip-6757-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32415,y:32551,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Vector4Property,id:3039,x:31990,y:32777,ptovrint:False,ptlb:Position,ptin:_Position,varname:node_3039,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0,v4:0;n:type:ShaderForge.SFN_TexCoord,id:8359,x:32008,y:33017,varname:node_8359,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_If,id:1514,x:32875,y:32858,varname:node_1514,prsc:2|A-3069-OUT,B-8467-OUT,GT-9880-OUT,EQ-9880-OUT,LT-2701-OUT;n:type:ShaderForge.SFN_Vector1,id:9880,x:32750,y:33225,varname:node_9880,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2701,x:32780,y:33093,varname:node_2701,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:9428,x:32755,y:32574,varname:node_9428,prsc:2|A-7241-RGB,B-7241-A;n:type:ShaderForge.SFN_Vector1,id:8467,x:32750,y:33151,varname:node_8467,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Multiply,id:6757,x:33065,y:32775,varname:node_6757,prsc:2|A-7241-A,B-1514-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1832,x:32149,y:33264,ptovrint:False,ptlb:XScale,ptin:_XScale,varname:node_1832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:3945,x:32236,y:33340,ptovrint:False,ptlb:YScale,ptin:_YScale,varname:node_3945,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:5054,x:32331,y:33021,varname:node_5054,prsc:2|A-1832-OUT,B-3945-OUT;n:type:ShaderForge.SFN_Length,id:3069,x:32676,y:32828,varname:node_3069,prsc:2|IN-9276-OUT;n:type:ShaderForge.SFN_Subtract,id:3268,x:32207,y:32883,varname:node_3268,prsc:2|A-3039-XYZ,B-8359-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9276,x:32427,y:32774,varname:node_9276,prsc:2|A-3268-OUT,B-5054-OUT;proporder:7241-3039-1832-3945;pass:END;sub:END;*/

Shader "Shader Forge/PerturbShader" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Position ("Position", Vector) = (0.5,0.5,0,0)
        _XScale ("XScale", Float ) = 1
        _YScale ("YScale", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles ps4 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Position;
            uniform float _XScale;
            uniform float _YScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_1514_if_leA = step(length(((_Position.rgb-float3(i.uv0,0.0))*float3(float2(_XScale,_YScale),0.0))),0.05);
                float node_1514_if_leB = step(0.05,length(((_Position.rgb-float3(i.uv0,0.0))*float3(float2(_XScale,_YScale),0.0))));
                float node_9880 = 0.0;
                clip((_Color.a*lerp((node_1514_if_leA*1.0)+(node_1514_if_leB*node_9880),node_9880,node_1514_if_leA*node_1514_if_leB)) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_Color.rgb*_Color.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
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
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles ps4 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Position;
            uniform float _XScale;
            uniform float _YScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_1514_if_leA = step(length(((_Position.rgb-float3(i.uv0,0.0))*float3(float2(_XScale,_YScale),0.0))),0.05);
                float node_1514_if_leB = step(0.05,length(((_Position.rgb-float3(i.uv0,0.0))*float3(float2(_XScale,_YScale),0.0))));
                float node_9880 = 0.0;
                clip((_Color.a*lerp((node_1514_if_leA*1.0)+(node_1514_if_leB*node_9880),node_9880,node_1514_if_leA*node_1514_if_leB)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
