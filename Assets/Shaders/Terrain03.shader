// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33826,y:32775,varname:node_4013,prsc:2|diff-8114-OUT;n:type:ShaderForge.SFN_Tex2d,id:3014,x:32350,y:32351,ptovrint:False,ptlb:Layer0,ptin:_Layer0,varname:_Layer5,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:7543,x:32619,y:32555,varname:node_7543,prsc:2|A-3014-RGB,B-1060-RGB,T-1378-OUT;n:type:ShaderForge.SFN_Tex2d,id:1060,x:32619,y:32351,ptovrint:False,ptlb:Layer1,ptin:_Layer1,varname:_Layer4,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8cc9e8443050e1e46bed1115206aa6ae,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Lerp,id:1226,x:32906,y:32592,varname:node_1226,prsc:2|A-7543-OUT,B-4705-RGB,T-2194-OUT;n:type:ShaderForge.SFN_Lerp,id:8229,x:33240,y:32678,varname:node_8229,prsc:2|A-1226-OUT,B-26-RGB,T-6643-OUT;n:type:ShaderForge.SFN_Lerp,id:4896,x:33305,y:32959,varname:node_4896,prsc:2|A-8229-OUT,B-7454-RGB,T-8260-OUT;n:type:ShaderForge.SFN_Tex2d,id:4705,x:32906,y:32401,ptovrint:False,ptlb:Layer2,ptin:_Layer2,varname:_Layer3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:339fd4bdb2fbb544d8ef74cac61b0d9b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:26,x:33240,y:32478,ptovrint:False,ptlb:Layer3,ptin:_Layer3,varname:_Layer2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:70bd37d7b9b7f404dae14046a544f9d0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7454,x:33573,y:32552,ptovrint:False,ptlb:Layer4,ptin:_Layer4,varname:_Layer1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e2acacc7bcc3cdf41a5a04db6ce34aad,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5879,x:33193,y:34002,varname:node_5879,prsc:2|A-8260-OUT,B-9478-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9478,x:33160,y:34284,ptovrint:False,ptlb:node_9478,ptin:_node_9478,varname:node_9478,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:3086,x:32186,y:33015,varname:node_3086,prsc:2|A-9243-RGB,B-9374-OUT;n:type:ShaderForge.SFN_Slider,id:9374,x:31803,y:33273,ptovrint:False,ptlb:Layer1Blend,ptin:_Layer1Blend,varname:node_9374,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1318015,max:1;n:type:ShaderForge.SFN_Blend,id:1378,x:32616,y:33022,varname:node_1378,prsc:2,blmd:7,clmp:True|SRC-3086-OUT,DST-4347-R;n:type:ShaderForge.SFN_Tex2d,id:9243,x:31899,y:33031,ptovrint:False,ptlb:Layer1Height,ptin:_Layer1Height,varname:node_9243,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:70bd37d7b9b7f404dae14046a544f9d0,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Blend,id:2194,x:32615,y:33313,varname:node_2194,prsc:2,blmd:7,clmp:True|SRC-2381-OUT,DST-4347-G;n:type:ShaderForge.SFN_Add,id:2381,x:32183,y:33420,varname:node_2381,prsc:2|A-2764-RGB,B-6256-OUT;n:type:ShaderForge.SFN_Tex2d,id:2764,x:31881,y:33416,ptovrint:False,ptlb:Layer2Height,ptin:_Layer2Height,varname:node_2764,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:339fd4bdb2fbb544d8ef74cac61b0d9b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:6256,x:31803,y:33628,ptovrint:False,ptlb:Layer2Blend,ptin:_Layer2Blend,varname:node_6256,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Blend,id:6643,x:32628,y:33717,varname:node_6643,prsc:2,blmd:7,clmp:True|SRC-9909-OUT,DST-4347-B;n:type:ShaderForge.SFN_Add,id:9909,x:32161,y:33816,varname:node_9909,prsc:2|A-9194-RGB,B-2712-OUT;n:type:ShaderForge.SFN_Tex2d,id:9194,x:31888,y:33812,ptovrint:False,ptlb:Layer3Height,ptin:_Layer3Height,varname:_Layer2Height_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8939db24287f71540b632f8886ca93e1,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:2712,x:31810,y:34024,ptovrint:False,ptlb:Layer3Blend,ptin:_Layer3Blend,varname:_Layer2Blend_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Blend,id:8260,x:32628,y:34110,varname:node_8260,prsc:2,blmd:7,clmp:True|SRC-512-OUT,DST-4347-A;n:type:ShaderForge.SFN_Add,id:512,x:32191,y:34209,varname:node_512,prsc:2|A-514-RGB,B-4067-OUT;n:type:ShaderForge.SFN_Tex2d,id:514,x:31888,y:34205,ptovrint:False,ptlb:Layer4Height,ptin:_Layer4Height,varname:_Layer2Height_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e2acacc7bcc3cdf41a5a04db6ce34aad,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Slider,id:4067,x:31810,y:34417,ptovrint:False,ptlb:Layer4Blend,ptin:_Layer4Blend,varname:_Layer2Blend_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:4347,x:31928,y:32685,ptovrint:False,ptlb:VertexColor,ptin:_VertexColor,varname:node_4347,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aa762ee7680f35f4fb9a9210fa94ce61,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:8114,x:33630,y:33019,varname:node_8114,prsc:2|A-4896-OUT,B-8449-OUT,T-9010-OUT;n:type:ShaderForge.SFN_Tex2d,id:354,x:33196,y:33268,ptovrint:False,ptlb:Shadows1,ptin:_Shadows1,varname:node_354,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7445,x:33232,y:33518,ptovrint:False,ptlb:Shadows2,ptin:_Shadows2,varname:node_7445,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e4cb71aae0af644468e2a43ce4576b51,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8449,x:33514,y:33457,varname:node_8449,prsc:2|A-354-RGB,B-7445-RGB;n:type:ShaderForge.SFN_Slider,id:9010,x:33278,y:33155,ptovrint:False,ptlb:Detail,ptin:_Detail,varname:node_9010,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;proporder:3014-1060-9243-9374-4705-2764-6256-26-9194-2712-7454-514-4067-9478-4347-354-7445-9010;pass:END;sub:END;*/

Shader "Shader Forge/Terrain03" {
    Properties {
        _Layer0 ("Layer0", 2D) = "white" {}
        _Layer1 ("Layer1", 2D) = "black" {}
        _Layer1Height ("Layer1Height", 2D) = "black" {}
        _Layer1Blend ("Layer1Blend", Range(0, 1)) = 0.1318015
        _Layer2 ("Layer2", 2D) = "white" {}
        _Layer2Height ("Layer2Height", 2D) = "white" {}
        _Layer2Blend ("Layer2Blend", Range(0, 1)) = 0
        _Layer3 ("Layer3", 2D) = "white" {}
        _Layer3Height ("Layer3Height", 2D) = "bump" {}
        _Layer3Blend ("Layer3Blend", Range(0, 1)) = 0
        _Layer4 ("Layer4", 2D) = "white" {}
        _Layer4Height ("Layer4Height", 2D) = "black" {}
        _Layer4Blend ("Layer4Blend", Range(0, 1)) = 0
        _node_9478 ("node_9478", Float ) = 0
        _VertexColor ("VertexColor", 2D) = "white" {}
        _Shadows1 ("Shadows1", 2D) = "white" {}
        _Shadows2 ("Shadows2", 2D) = "white" {}
        _Detail ("Detail", Range(0, 1)) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Layer0; uniform float4 _Layer0_ST;
            uniform sampler2D _Layer1; uniform float4 _Layer1_ST;
            uniform sampler2D _Layer2; uniform float4 _Layer2_ST;
            uniform sampler2D _Layer3; uniform float4 _Layer3_ST;
            uniform sampler2D _Layer4; uniform float4 _Layer4_ST;
            uniform float _Layer1Blend;
            uniform sampler2D _Layer1Height; uniform float4 _Layer1Height_ST;
            uniform sampler2D _Layer2Height; uniform float4 _Layer2Height_ST;
            uniform float _Layer2Blend;
            uniform sampler2D _Layer3Height; uniform float4 _Layer3Height_ST;
            uniform float _Layer3Blend;
            uniform sampler2D _Layer4Height; uniform float4 _Layer4Height_ST;
            uniform float _Layer4Blend;
            uniform sampler2D _VertexColor; uniform float4 _VertexColor_ST;
            uniform sampler2D _Shadows1; uniform float4 _Shadows1_ST;
            uniform sampler2D _Shadows2; uniform float4 _Shadows2_ST;
            uniform float _Detail;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Layer0_var = tex2D(_Layer0,TRANSFORM_TEX(i.uv0, _Layer0));
                float4 _Layer1_var = tex2D(_Layer1,TRANSFORM_TEX(i.uv0, _Layer1));
                float4 _Layer1Height_var = tex2D(_Layer1Height,TRANSFORM_TEX(i.uv0, _Layer1Height));
                float4 _VertexColor_var = tex2D(_VertexColor,TRANSFORM_TEX(i.uv0, _VertexColor));
                float4 _Layer2_var = tex2D(_Layer2,TRANSFORM_TEX(i.uv0, _Layer2));
                float4 _Layer2Height_var = tex2D(_Layer2Height,TRANSFORM_TEX(i.uv0, _Layer2Height));
                float4 _Layer3_var = tex2D(_Layer3,TRANSFORM_TEX(i.uv0, _Layer3));
                float3 _Layer3Height_var = UnpackNormal(tex2D(_Layer3Height,TRANSFORM_TEX(i.uv0, _Layer3Height)));
                float4 _Layer4_var = tex2D(_Layer4,TRANSFORM_TEX(i.uv0, _Layer4));
                float4 _Layer4Height_var = tex2D(_Layer4Height,TRANSFORM_TEX(i.uv0, _Layer4Height));
                float3 node_8260 = saturate((_VertexColor_var.a/(1.0-(_Layer4Height_var.rgb+_Layer4Blend))));
                float4 _Shadows1_var = tex2D(_Shadows1,TRANSFORM_TEX(i.uv0, _Shadows1));
                float4 _Shadows2_var = tex2D(_Shadows2,TRANSFORM_TEX(i.uv0, _Shadows2));
                float3 diffuseColor = lerp(lerp(lerp(lerp(lerp(_Layer0_var.rgb,_Layer1_var.rgb,saturate((_VertexColor_var.r/(1.0-(_Layer1Height_var.rgb+_Layer1Blend))))),_Layer2_var.rgb,saturate((_VertexColor_var.g/(1.0-(_Layer2Height_var.rgb+_Layer2Blend))))),_Layer3_var.rgb,saturate((_VertexColor_var.b/(1.0-(_Layer3Height_var.rgb+_Layer3Blend))))),_Layer4_var.rgb,node_8260),(_Shadows1_var.rgb*_Shadows2_var.rgb),_Detail);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Layer0; uniform float4 _Layer0_ST;
            uniform sampler2D _Layer1; uniform float4 _Layer1_ST;
            uniform sampler2D _Layer2; uniform float4 _Layer2_ST;
            uniform sampler2D _Layer3; uniform float4 _Layer3_ST;
            uniform sampler2D _Layer4; uniform float4 _Layer4_ST;
            uniform float _Layer1Blend;
            uniform sampler2D _Layer1Height; uniform float4 _Layer1Height_ST;
            uniform sampler2D _Layer2Height; uniform float4 _Layer2Height_ST;
            uniform float _Layer2Blend;
            uniform sampler2D _Layer3Height; uniform float4 _Layer3Height_ST;
            uniform float _Layer3Blend;
            uniform sampler2D _Layer4Height; uniform float4 _Layer4Height_ST;
            uniform float _Layer4Blend;
            uniform sampler2D _VertexColor; uniform float4 _VertexColor_ST;
            uniform sampler2D _Shadows1; uniform float4 _Shadows1_ST;
            uniform sampler2D _Shadows2; uniform float4 _Shadows2_ST;
            uniform float _Detail;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Layer0_var = tex2D(_Layer0,TRANSFORM_TEX(i.uv0, _Layer0));
                float4 _Layer1_var = tex2D(_Layer1,TRANSFORM_TEX(i.uv0, _Layer1));
                float4 _Layer1Height_var = tex2D(_Layer1Height,TRANSFORM_TEX(i.uv0, _Layer1Height));
                float4 _VertexColor_var = tex2D(_VertexColor,TRANSFORM_TEX(i.uv0, _VertexColor));
                float4 _Layer2_var = tex2D(_Layer2,TRANSFORM_TEX(i.uv0, _Layer2));
                float4 _Layer2Height_var = tex2D(_Layer2Height,TRANSFORM_TEX(i.uv0, _Layer2Height));
                float4 _Layer3_var = tex2D(_Layer3,TRANSFORM_TEX(i.uv0, _Layer3));
                float3 _Layer3Height_var = UnpackNormal(tex2D(_Layer3Height,TRANSFORM_TEX(i.uv0, _Layer3Height)));
                float4 _Layer4_var = tex2D(_Layer4,TRANSFORM_TEX(i.uv0, _Layer4));
                float4 _Layer4Height_var = tex2D(_Layer4Height,TRANSFORM_TEX(i.uv0, _Layer4Height));
                float3 node_8260 = saturate((_VertexColor_var.a/(1.0-(_Layer4Height_var.rgb+_Layer4Blend))));
                float4 _Shadows1_var = tex2D(_Shadows1,TRANSFORM_TEX(i.uv0, _Shadows1));
                float4 _Shadows2_var = tex2D(_Shadows2,TRANSFORM_TEX(i.uv0, _Shadows2));
                float3 diffuseColor = lerp(lerp(lerp(lerp(lerp(_Layer0_var.rgb,_Layer1_var.rgb,saturate((_VertexColor_var.r/(1.0-(_Layer1Height_var.rgb+_Layer1Blend))))),_Layer2_var.rgb,saturate((_VertexColor_var.g/(1.0-(_Layer2Height_var.rgb+_Layer2Blend))))),_Layer3_var.rgb,saturate((_VertexColor_var.b/(1.0-(_Layer3Height_var.rgb+_Layer3Blend))))),_Layer4_var.rgb,node_8260),(_Shadows1_var.rgb*_Shadows2_var.rgb),_Detail);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
}
