// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33329,y:32545,varname:node_3138,prsc:2|emission-9428-OUT,alpha-6757-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32415,y:32551,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Vector4Property,id:3039,x:32457,y:32947,ptovrint:False,ptlb:Position,ptin:_Position,varname:node_3039,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0,v4:0;n:type:ShaderForge.SFN_TexCoord,id:8359,x:32496,y:33212,varname:node_8359,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Distance,id:7177,x:32742,y:32909,varname:node_7177,prsc:2|A-3039-XYZ,B-8359-UVOUT;n:type:ShaderForge.SFN_If,id:1514,x:33005,y:32991,varname:node_1514,prsc:2|A-7177-OUT,B-8467-OUT,GT-9880-OUT,EQ-9880-OUT,LT-2701-OUT;n:type:ShaderForge.SFN_Vector1,id:9880,x:32750,y:33225,varname:node_9880,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2701,x:32780,y:33093,varname:node_2701,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:9428,x:32755,y:32574,varname:node_9428,prsc:2|A-7241-RGB,B-1514-OUT;n:type:ShaderForge.SFN_Vector1,id:8467,x:32750,y:33151,varname:node_8467,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Multiply,id:6757,x:33025,y:32736,varname:node_6757,prsc:2|A-7241-A,B-1514-OUT;proporder:7241-3039;pass:END;sub:END;*/

Shader "Shader Forge/PerturbShader" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Position ("Position", Vector) = (0.5,0.5,0,0)
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
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Position;
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
////// Lighting:
////// Emissive:
                float node_1514_if_leA = step(distance(_Position.rgb,i.uv0),0.05);
                float node_1514_if_leB = step(0.05,distance(_Position.rgb,i.uv0));
                float node_9880 = 0.0;
                float node_1514 = lerp((node_1514_if_leA*1.0)+(node_1514_if_leB*node_9880),node_9880,node_1514_if_leA*node_1514_if_leB);
                float3 emissive = (_Color.rgb*node_1514);
                float3 finalColor = emissive;
                return fixed4(finalColor,(_Color.a*node_1514));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
