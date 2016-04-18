// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32896,y:32660,varname:node_4013,prsc:2|diff-8851-OUT,emission-3359-OUT;n:type:ShaderForge.SFN_Tex2d,id:5111,x:32180,y:32384,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_5111,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e2acacc7bcc3cdf41a5a04db6ce34aad,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:5240,x:32440,y:32560,varname:node_5240,prsc:2|A-5111-RGB,B-4217-OUT,T-3314-OUT;n:type:ShaderForge.SFN_Tex2d,id:4164,x:31807,y:32543,ptovrint:False,ptlb:Texture2,ptin:_Texture2,varname:node_4164,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aa762ee7680f35f4fb9a9210fa94ce61,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:3314,x:32167,y:32882,ptovrint:False,ptlb:TransitionA,ptin:_TransitionA,varname:node_3314,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:4458,x:31807,y:32733,ptovrint:False,ptlb:Texture3,ptin:_Texture3,varname:node_4458,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:4217,x:32167,y:32651,varname:node_4217,prsc:2|A-4164-RGB,B-4458-RGB,T-2858-OUT;n:type:ShaderForge.SFN_Slider,id:2858,x:31788,y:32939,ptovrint:False,ptlb:TransitionB,ptin:_TransitionB,varname:node_2858,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:3534,x:32490,y:32864,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3534,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:0;n:type:ShaderForge.SFN_Multiply,id:8851,x:32673,y:32654,varname:node_8851,prsc:2|A-5240-OUT,B-3534-RGB;n:type:ShaderForge.SFN_Tex2d,id:6495,x:32212,y:33022,ptovrint:False,ptlb:EmissionMap,ptin:_EmissionMap,varname:node_6495,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b116bf56b843a432b96dc6e7e0788e93,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Lerp,id:3359,x:32490,y:33045,varname:node_3359,prsc:2|A-6495-RGB,B-6611-OUT,T-3314-OUT;n:type:ShaderForge.SFN_Tex2d,id:6942,x:31945,y:33084,ptovrint:False,ptlb:EmissionMap2,ptin:_EmissionMap2,varname:node_6942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a67aa329325af46d4a9c18d7ad10dc51,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9911,x:31760,y:33269,ptovrint:False,ptlb:EmissionMap3,ptin:_EmissionMap3,varname:node_9911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c8556aeb20f6a3b43b2b8990f591f19a,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6611,x:32212,y:33228,varname:node_6611,prsc:2|A-6942-RGB,B-9911-RGB,T-2858-OUT;proporder:5111-4164-3314-4458-2858-3534-6495-6942-9911;pass:END;sub:END;*/

Shader "Shader Forge/TexturesBlender" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Texture2 ("Texture2", 2D) = "white" {}
        _TransitionA ("TransitionA", Range(0, 1)) = 0
        _Texture3 ("Texture3", 2D) = "white" {}
        _TransitionB ("TransitionB", Range(0, 1)) = 0
        _Color ("Color", Color) = (1,1,1,0)
        _EmissionMap ("EmissionMap", 2D) = "black" {}
        _EmissionMap2 ("EmissionMap2", 2D) = "black" {}
        _EmissionMap3 ("EmissionMap3", 2D) = "black" {}
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Texture2; uniform float4 _Texture2_ST;
            uniform float _TransitionA;
            uniform sampler2D _Texture3; uniform float4 _Texture3_ST;
            uniform float _TransitionB;
            uniform float4 _Color;
            uniform sampler2D _EmissionMap; uniform float4 _EmissionMap_ST;
            uniform sampler2D _EmissionMap2; uniform float4 _EmissionMap2_ST;
            uniform sampler2D _EmissionMap3; uniform float4 _EmissionMap3_ST;
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _Texture2_var = tex2D(_Texture2,TRANSFORM_TEX(i.uv0, _Texture2));
                float4 _Texture3_var = tex2D(_Texture3,TRANSFORM_TEX(i.uv0, _Texture3));
                float3 diffuseColor = (lerp(_MainTex_var.rgb,lerp(_Texture2_var.rgb,_Texture3_var.rgb,_TransitionB),_TransitionA)*_Color.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _EmissionMap_var = tex2D(_EmissionMap,TRANSFORM_TEX(i.uv0, _EmissionMap));
                float4 _EmissionMap2_var = tex2D(_EmissionMap2,TRANSFORM_TEX(i.uv0, _EmissionMap2));
                float4 _EmissionMap3_var = tex2D(_EmissionMap3,TRANSFORM_TEX(i.uv0, _EmissionMap3));
                float3 emissive = lerp(_EmissionMap_var.rgb,lerp(_EmissionMap2_var.rgb,_EmissionMap3_var.rgb,_TransitionB),_TransitionA);
/// Final Color:
                float3 finalColor = diffuse + emissive;
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Texture2; uniform float4 _Texture2_ST;
            uniform float _TransitionA;
            uniform sampler2D _Texture3; uniform float4 _Texture3_ST;
            uniform float _TransitionB;
            uniform float4 _Color;
            uniform sampler2D _EmissionMap; uniform float4 _EmissionMap_ST;
            uniform sampler2D _EmissionMap2; uniform float4 _EmissionMap2_ST;
            uniform sampler2D _EmissionMap3; uniform float4 _EmissionMap3_ST;
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
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _Texture2_var = tex2D(_Texture2,TRANSFORM_TEX(i.uv0, _Texture2));
                float4 _Texture3_var = tex2D(_Texture3,TRANSFORM_TEX(i.uv0, _Texture3));
                float3 diffuseColor = (lerp(_MainTex_var.rgb,lerp(_Texture2_var.rgb,_Texture3_var.rgb,_TransitionB),_TransitionA)*_Color.rgb);
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
    CustomEditor "ShaderForgeMaterialInspector"
}
