// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34430,y:32628,varname:node_3138,prsc:2|emission-2190-OUT,alpha-3185-OUT;n:type:ShaderForge.SFN_Vector4Property,id:7304,x:32570,y:32893,ptovrint:False,ptlb:Position,ptin:_Position,varname:node_7304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_TexCoord,id:7397,x:32710,y:32911,varname:node_7397,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector4Property,id:971,x:32753,y:32450,ptovrint:False,ptlb:Position,ptin:_Position,varname:node_971,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0.5,v3:0,v4:0;n:type:ShaderForge.SFN_Distance,id:455,x:33098,y:32792,varname:node_455,prsc:2|A-9331-OUT,B-7397-V;n:type:ShaderForge.SFN_OneMinus,id:45,x:33307,y:32838,varname:node_45,prsc:2|IN-455-OUT;n:type:ShaderForge.SFN_Power,id:9337,x:33613,y:32700,varname:node_9337,prsc:2|VAL-45-OUT,EXP-7239-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7239,x:33406,y:33004,ptovrint:False,ptlb:WaveGradient,ptin:_WaveGradient,varname:node_7239,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Multiply,id:6056,x:32989,y:32460,varname:node_6056,prsc:2|A-6387-OUT,B-971-X;n:type:ShaderForge.SFN_Add,id:9331,x:33098,y:32622,varname:node_9331,prsc:2|A-6056-OUT,B-971-Y;n:type:ShaderForge.SFN_Subtract,id:6387,x:32893,y:32710,varname:node_6387,prsc:2|A-7397-U,B-8583-OUT;n:type:ShaderForge.SFN_Vector1,id:8583,x:32730,y:32744,varname:node_8583,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Color,id:456,x:33448,y:33116,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_456,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9274,x:33861,y:32832,varname:node_9274,prsc:2|A-9337-OUT,B-456-RGB;n:type:ShaderForge.SFN_Multiply,id:3561,x:33875,y:33113,varname:node_3561,prsc:2|A-9337-OUT,B-456-A;n:type:ShaderForge.SFN_Clamp01,id:2190,x:34025,y:32678,varname:node_2190,prsc:2|IN-9274-OUT;n:type:ShaderForge.SFN_Clamp01,id:3185,x:34161,y:33028,varname:node_3185,prsc:2|IN-3561-OUT;proporder:971-7239-456;pass:END;sub:END;*/

Shader "Shader Forge/OceanPerturbShader" {
    Properties {
        _Position ("Position", Vector) = (0,0.5,0,0)
        _WaveGradient ("WaveGradient", Float ) = 8
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
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
            uniform float4 _Position;
            uniform float _WaveGradient;
            uniform float4 _Color;
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
                float node_9337 = pow((1.0 - distance((((i.uv0.r-0.5)*_Position.r)+_Position.g),i.uv0.g)),_WaveGradient);
                float3 emissive = saturate((node_9337*_Color.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,saturate((node_9337*_Color.a)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
