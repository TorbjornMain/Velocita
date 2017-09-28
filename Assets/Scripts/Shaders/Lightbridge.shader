// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32939,y:32694,varname:node_3138,prsc:2|emission-8859-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31366,y:32533,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Multiply,id:8859,x:32430,y:32580,varname:node_8859,prsc:2|A-2054-RGB,B-7241-RGB,C-6760-OUT,D-2054-A,E-7241-A;n:type:ShaderForge.SFN_Tex2d,id:2054,x:31863,y:32422,ptovrint:False,ptlb:Pattern Texture,ptin:_PatternTexture,varname:node_2054,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Sin,id:5694,x:32124,y:32934,varname:node_5694,prsc:2|IN-3269-OUT;n:type:ShaderForge.SFN_Time,id:4500,x:31578,y:32821,varname:node_4500,prsc:2;n:type:ShaderForge.SFN_Add,id:2560,x:32374,y:32867,varname:node_2560,prsc:2|A-5694-OUT,B-3677-OUT;n:type:ShaderForge.SFN_Vector1,id:3677,x:31350,y:32855,varname:node_3677,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:5519,x:32573,y:32902,varname:node_5519,prsc:2|A-2560-OUT,B-3950-OUT;n:type:ShaderForge.SFN_Vector1,id:3950,x:32407,y:33096,varname:node_3950,prsc:2,v1:2;n:type:ShaderForge.SFN_TexCoord,id:536,x:31045,y:33182,varname:node_536,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:3269,x:32223,y:33108,varname:node_3269,prsc:2|A-5664-OUT,B-3698-OUT;n:type:ShaderForge.SFN_Multiply,id:4746,x:32058,y:33302,varname:node_4746,prsc:2|A-8052-OUT,B-6208-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6208,x:31582,y:33439,ptovrint:False,ptlb:Wave Frequency,ptin:_WaveFrequency,varname:node_6208,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Subtract,id:3711,x:31379,y:33221,varname:node_3711,prsc:2|A-536-U,B-9337-OUT;n:type:ShaderForge.SFN_Add,id:6760,x:32665,y:33058,varname:node_6760,prsc:2|A-5519-OUT,B-6407-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6407,x:32474,y:33274,ptovrint:False,ptlb:Base Alpha,ptin:_BaseAlpha,varname:node_6407,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:9337,x:31167,y:33347,varname:node_9337,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5343,x:31558,y:33155,varname:node_5343,prsc:2|A-3711-OUT,B-3950-OUT;n:type:ShaderForge.SFN_Abs,id:4388,x:31691,y:33339,varname:node_4388,prsc:2|IN-5343-OUT;n:type:ShaderForge.SFN_Subtract,id:8052,x:31858,y:33232,varname:node_8052,prsc:2|A-5651-OUT,B-4388-OUT;n:type:ShaderForge.SFN_Vector1,id:5651,x:31045,y:33679,varname:node_5651,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:3698,x:32236,y:33496,varname:node_3698,prsc:2|A-4746-OUT,B-5516-OUT,T-4251-OUT;n:type:ShaderForge.SFN_Multiply,id:5516,x:31991,y:33519,varname:node_5516,prsc:2|A-4388-OUT,B-6208-OUT;n:type:ShaderForge.SFN_Multiply,id:854,x:31291,y:33465,varname:node_854,prsc:2|A-536-V,B-3032-OUT;n:type:ShaderForge.SFN_Vector1,id:3032,x:31101,y:33541,varname:node_3032,prsc:2,v1:3;n:type:ShaderForge.SFN_Sin,id:4466,x:31393,y:33643,varname:node_4466,prsc:2|IN-854-OUT;n:type:ShaderForge.SFN_Multiply,id:4251,x:31782,y:33656,varname:node_4251,prsc:2|A-4184-OUT,B-2744-OUT;n:type:ShaderForge.SFN_Vector1,id:2744,x:31393,y:33774,varname:node_2744,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:4184,x:31568,y:33688,varname:node_4184,prsc:2|A-4466-OUT,B-5651-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6233,x:31497,y:33001,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_6233,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:5664,x:31833,y:32925,varname:node_5664,prsc:2|A-4500-TTR,B-6233-OUT;proporder:7241-2054-6208-6407-6233;pass:END;sub:END;*/

Shader "Shader Forge/Lightbridge" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _PatternTexture ("Pattern Texture", 2D) = "white" {}
        _WaveFrequency ("Wave Frequency", Float ) = 1
        _BaseAlpha ("Base Alpha", Float ) = 0.1
        _Speed ("Speed", Float ) = 2
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
            uniform sampler2D _PatternTexture; uniform float4 _PatternTexture_ST;
            uniform float _WaveFrequency;
            uniform float _BaseAlpha;
            uniform float _Speed;
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
                float4 _PatternTexture_var = tex2D(_PatternTexture,TRANSFORM_TEX(i.uv0, _PatternTexture));
                float4 node_4500 = _Time;
                float node_5651 = 1.0;
                float node_3950 = 2.0;
                float node_4388 = abs(((i.uv0.r-0.5)*node_3950));
                float node_854 = (i.uv0.g*3.0);
                float node_3677 = 1.0;
                float3 emissive = (_PatternTexture_var.rgb*_Color.rgb*(((sin(((node_4500.a*_Speed)+lerp(((node_5651-node_4388)*_WaveFrequency),(node_4388*_WaveFrequency),((sin(node_854)+node_5651)*0.5))))+node_3677)/node_3950)+_BaseAlpha)*_PatternTexture_var.a*_Color.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
