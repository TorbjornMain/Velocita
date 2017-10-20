// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33872,y:32865,varname:node_3138,prsc:2|emission-5535-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32336,y:32652,ptovrint:False,ptlb:DistantColor,ptin:_DistantColor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:0.1;n:type:ShaderForge.SFN_Tex2d,id:1942,x:32351,y:32999,ptovrint:False,ptlb:ShieldPatternMask,ptin:_ShieldPatternMask,varname:node_1942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9eaa1aca4fbc3c147af2bc0b24a70653,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2009,x:32682,y:32747,varname:node_2009,prsc:2|A-7241-RGB,B-1942-RGB,C-9512-OUT;n:type:ShaderForge.SFN_Multiply,id:9512,x:32601,y:32939,varname:node_9512,prsc:2|A-7241-A,B-1942-A;n:type:ShaderForge.SFN_Add,id:5535,x:33654,y:32928,varname:node_5535,prsc:2|A-6944-OUT,B-2009-OUT,C-6518-OUT;n:type:ShaderForge.SFN_Tex2d,id:5769,x:32592,y:33744,ptovrint:False,ptlb:WaveMask,ptin:_WaveMask,varname:node_5769,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:1479,x:33088,y:33558,ptovrint:False,ptlb:WaveColor,ptin:_WaveColor,varname:node_1479,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6944,x:33459,y:33530,varname:node_6944,prsc:2|A-1479-RGB,B-4317-OUT,C-1479-A;n:type:ShaderForge.SFN_Color,id:4521,x:33235,y:33045,ptovrint:False,ptlb:ShieldTone,ptin:_ShieldTone,varname:node_4521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:1,c4:0.05;n:type:ShaderForge.SFN_Multiply,id:6518,x:33461,y:32993,varname:node_6518,prsc:2|A-4521-RGB,B-4521-A;n:type:ShaderForge.SFN_Multiply,id:813,x:32885,y:33746,varname:node_813,prsc:2|A-5769-RGB,B-1063-OUT;n:type:ShaderForge.SFN_Vector1,id:1063,x:32650,y:33915,varname:node_1063,prsc:2,v1:2;n:type:ShaderForge.SFN_Subtract,id:5990,x:33088,y:33781,varname:node_5990,prsc:2|A-813-OUT,B-1772-OUT;n:type:ShaderForge.SFN_Vector1,id:1772,x:32885,y:33974,varname:node_1772,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:4317,x:33290,y:33667,varname:node_4317,prsc:2|IN-5990-OUT;proporder:7241-1942-4521-5769-1479;pass:END;sub:END;*/

Shader "Shader Forge/ShieldWall" {
    Properties {
        _DistantColor ("DistantColor", Color) = (0.07843138,0.3921569,0.7843137,0.1)
        _ShieldPatternMask ("ShieldPatternMask", 2D) = "white" {}
        _ShieldTone ("ShieldTone", Color) = (0,0,1,0.05)
        _WaveMask ("WaveMask", 2D) = "white" {}
        _WaveColor ("WaveColor", Color) = (0,1,1,1)
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
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _DistantColor;
            uniform sampler2D _ShieldPatternMask; uniform float4 _ShieldPatternMask_ST;
            uniform sampler2D _WaveMask; uniform float4 _WaveMask_ST;
            uniform float4 _WaveColor;
            uniform float4 _ShieldTone;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _WaveMask_var = tex2D(_WaveMask,TRANSFORM_TEX(i.uv0, _WaveMask));
                float4 _ShieldPatternMask_var = tex2D(_ShieldPatternMask,TRANSFORM_TEX(i.uv0, _ShieldPatternMask));
                float3 emissive = ((_WaveColor.rgb*saturate(((_WaveMask_var.rgb*2.0)-1.0))*_WaveColor.a)+(_DistantColor.rgb*_ShieldPatternMask_var.rgb*(_DistantColor.a*_ShieldPatternMask_var.a))+(_ShieldTone.rgb*_ShieldTone.a));
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
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
