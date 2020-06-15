// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33673,y:32914,varname:node_2865,prsc:2|diff-5327-RGB,spec-4733-OUT,gloss-4467-OUT,amspl-91-OUT,alpha-9957-OUT,clip-8474-OUT,refract-7187-OUT;n:type:ShaderForge.SFN_Slider,id:4733,x:32678,y:32573,ptovrint:False,ptlb:Metallic_copy,ptin:_Metallic_copy,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Color,id:5327,x:32945,y:32456,ptovrint:False,ptlb:Color_copy,ptin:_Color_copy,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:91,x:32903,y:32811,varname:node_91,prsc:2|A-778-RGB,B-6530-OUT,C-4386-OUT;n:type:ShaderForge.SFN_Color,id:778,x:32445,y:32647,ptovrint:False,ptlb:node_9973,ptin:_node_9973,varname:node_9973,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:4467,x:32944,y:32994,ptovrint:False,ptlb:Gloss_copy,ptin:_Gloss_copy,varname:_Gloss_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:8884,x:32084,y:32872,ptovrint:False,ptlb:specular,ptin:_specular,varname:node_4927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Slider,id:221,x:32244,y:33315,ptovrint:False,ptlb:reflectionfrenel,ptin:_reflectionfrenel,varname:_node_2962_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.1,max:10;n:type:ShaderForge.SFN_Slider,id:7047,x:32322,y:33158,ptovrint:False,ptlb:opacityfrenel,ptin:_opacityfrenel,varname:node_2962,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:3;n:type:ShaderForge.SFN_Fresnel,id:6530,x:32501,y:32843,varname:node_6530,prsc:2|EXP-8884-OUT;n:type:ShaderForge.SFN_Fresnel,id:5865,x:32700,y:33130,varname:node_5865,prsc:2|EXP-7047-OUT;n:type:ShaderForge.SFN_Multiply,id:6126,x:32664,y:33290,varname:node_6126,prsc:2|A-5865-OUT,B-221-OUT;n:type:ShaderForge.SFN_TexCoord,id:4076,x:33063,y:33559,varname:node_4076,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7187,x:33267,y:33547,varname:node_7187,prsc:2|A-6126-OUT,B-4076-UVOUT,C-5573-OUT;n:type:ShaderForge.SFN_Power,id:5573,x:33320,y:33845,varname:node_5573,prsc:2|VAL-9953-RGB,EXP-2853-OUT;n:type:ShaderForge.SFN_Tex2d,id:9953,x:32901,y:33813,ptovrint:False,ptlb:node_9953,ptin:_node_9953,varname:node_9953,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b43b14f80345cbe48ac1d6a1e9e2ac1e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:2853,x:33011,y:33896,ptovrint:False,ptlb:melt_kusseturitu,ptin:_melt_kusseturitu,varname:node_2853,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Rotator,id:2479,x:32184,y:33547,varname:node_2479,prsc:2|UVIN-5133-UVOUT,ANG-4528-OUT;n:type:ShaderForge.SFN_TexCoord,id:5133,x:31947,y:33478,varname:node_5133,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:4528,x:32226,y:33746,ptovrint:False,ptlb:texturekakudo,ptin:_texturekakudo,varname:node_4528,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:8935,x:32418,y:33395,varname:_node_9953_copy,prsc:2,ntxv:2,isnm:False|UVIN-2479-UVOUT,TEX-7544-TEX;n:type:ShaderForge.SFN_Fresnel,id:1891,x:33098,y:33259,varname:node_1891,prsc:2|NRM-8474-OUT;n:type:ShaderForge.SFN_Multiply,id:9957,x:33066,y:33106,varname:node_9957,prsc:2|A-5865-OUT,B-1891-OUT;n:type:ShaderForge.SFN_Fresnel,id:4386,x:32716,y:32978,varname:node_4386,prsc:2|NRM-5470-RGB,EXP-9278-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9278,x:32373,y:33048,ptovrint:False,ptlb:melt_speculaar,ptin:_melt_speculaar,varname:_melt_toumeido_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:5470,x:32111,y:32985,ptovrint:False,ptlb:node_9953_copy_copy,ptin:_node_9953_copy_copy,varname:_node_9953_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b43b14f80345cbe48ac1d6a1e9e2ac1e,ntxv:0,isnm:False|UVIN-5082-UVOUT;n:type:ShaderForge.SFN_Rotator,id:5082,x:31876,y:33002,varname:node_5082,prsc:2|UVIN-7342-UVOUT,ANG-5134-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5134,x:31649,y:33193,ptovrint:False,ptlb:teexturekakudo,ptin:_teexturekakudo,varname:_node_4528_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3.14;n:type:ShaderForge.SFN_TexCoord,id:7342,x:31612,y:33003,varname:node_7342,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:7544,x:32047,y:33304,ptovrint:False,ptlb:node_7544,ptin:_node_7544,varname:node_7544,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:8474,x:32892,y:33442,varname:node_8474,prsc:2|A-8935-R,B-6451-OUT;n:type:ShaderForge.SFN_Slider,id:4906,x:32390,y:33582,ptovrint:False,ptlb:melt_opacityclip,ptin:_melt_opacityclip,varname:node_4906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:6451,x:32700,y:33504,varname:node_6451,prsc:2,frmn:0,frmx:1,tomn:-0.5,tomx:0.5|IN-4906-OUT;proporder:5327-4733-4467-778-8884-7047-221-9953-2853-4528-9278-5470-5134-4906-7544;pass:END;sub:END;*/

Shader "Shader Forge/glass2_melt" {
    Properties {
        _Color_copy ("Color_copy", Color) = (1,1,1,1)
        _Metallic_copy ("Metallic_copy", Range(0, 1)) = 1
        _Gloss_copy ("Gloss_copy", Range(0, 1)) = 1
        _node_9973 ("node_9973", Color) = (1,1,1,1)
        _specular ("specular", Range(0, 3)) = 1
        _opacityfrenel ("opacityfrenel", Range(0, 3)) = 3
        _reflectionfrenel ("reflectionfrenel", Range(0, 10)) = 2.1
        _node_9953 ("node_9953", 2D) = "white" {}
        _melt_kusseturitu ("melt_kusseturitu", Float ) = 0
        _texturekakudo ("texturekakudo", Float ) = 0
        _melt_speculaar ("melt_speculaar", Float ) = 0
        _node_9953_copy_copy ("node_9953_copy_copy", 2D) = "white" {}
        _teexturekakudo ("teexturekakudo", Float ) = 3.14
        _melt_opacityclip ("melt_opacityclip", Range(0, 1)) = 1
        _node_7544 ("node_7544", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _node_9953; uniform float4 _node_9953_ST;
            uniform sampler2D _node_9953_copy_copy; uniform float4 _node_9953_copy_copy_ST;
            uniform sampler2D _node_7544; uniform float4 _node_7544_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic_copy)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color_copy)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_9973)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _specular)
                UNITY_DEFINE_INSTANCED_PROP( float, _reflectionfrenel)
                UNITY_DEFINE_INSTANCED_PROP( float, _opacityfrenel)
                UNITY_DEFINE_INSTANCED_PROP( float, _melt_kusseturitu)
                UNITY_DEFINE_INSTANCED_PROP( float, _texturekakudo)
                UNITY_DEFINE_INSTANCED_PROP( float, _melt_speculaar)
                UNITY_DEFINE_INSTANCED_PROP( float, _teexturekakudo)
                UNITY_DEFINE_INSTANCED_PROP( float, _melt_opacityclip)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
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
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
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
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float _opacityfrenel_var = UNITY_ACCESS_INSTANCED_PROP( Props, _opacityfrenel );
                float node_5865 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_opacityfrenel_var);
                float _reflectionfrenel_var = UNITY_ACCESS_INSTANCED_PROP( Props, _reflectionfrenel );
                float4 _node_9953_var = tex2D(_node_9953,TRANSFORM_TEX(i.uv0, _node_9953));
                float _melt_kusseturitu_var = UNITY_ACCESS_INSTANCED_PROP( Props, _melt_kusseturitu );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + ((node_5865*_reflectionfrenel_var)*float3(i.uv0,0.0)*pow(_node_9953_var.rgb,_melt_kusseturitu_var)).rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float _texturekakudo_var = UNITY_ACCESS_INSTANCED_PROP( Props, _texturekakudo );
                float node_2479_ang = _texturekakudo_var;
                float node_2479_spd = 1.0;
                float node_2479_cos = cos(node_2479_spd*node_2479_ang);
                float node_2479_sin = sin(node_2479_spd*node_2479_ang);
                float2 node_2479_piv = float2(0.5,0.5);
                float2 node_2479 = (mul(i.uv0-node_2479_piv,float2x2( node_2479_cos, -node_2479_sin, node_2479_sin, node_2479_cos))+node_2479_piv);
                float4 _node_9953_copy = tex2D(_node_7544,TRANSFORM_TEX(node_2479, _node_7544));
                float _melt_opacityclip_var = UNITY_ACCESS_INSTANCED_PROP( Props, _melt_opacityclip );
                float node_8474 = (_node_9953_copy.r+(_melt_opacityclip_var*1.0+-0.5));
                clip(node_8474 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float _Gloss_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss_copy );
                float gloss = _Gloss_copy_var;
                float perceptualRoughness = 1.0 - _Gloss_copy_var;
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
                float4 _node_9973_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_9973 );
                float _specular_var = UNITY_ACCESS_INSTANCED_PROP( Props, _specular );
                float _teexturekakudo_var = UNITY_ACCESS_INSTANCED_PROP( Props, _teexturekakudo );
                float node_5082_ang = _teexturekakudo_var;
                float node_5082_spd = 1.0;
                float node_5082_cos = cos(node_5082_spd*node_5082_ang);
                float node_5082_sin = sin(node_5082_spd*node_5082_ang);
                float2 node_5082_piv = float2(0.5,0.5);
                float2 node_5082 = (mul(i.uv0-node_5082_piv,float2x2( node_5082_cos, -node_5082_sin, node_5082_sin, node_5082_cos))+node_5082_piv);
                float4 _node_9953_copy_copy_var = tex2D(_node_9953_copy_copy,TRANSFORM_TEX(node_5082, _node_9953_copy_copy));
                float _melt_speculaar_var = UNITY_ACCESS_INSTANCED_PROP( Props, _melt_speculaar );
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float _Metallic_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic_copy );
                float3 specularColor = _Metallic_copy_var;
                float specularMonochrome;
                float4 _Color_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color_copy );
                float3 diffuseColor = _Color_copy_var.rgb; // Need this for specular when using metallic
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
                float3 indirectSpecular = (gi.indirect.specular + (_node_9973_var.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_specular_var)*pow(1.0-max(0,dot(_node_9953_copy_copy_var.rgb, viewDirection)),_melt_speculaar_var)));
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
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,(node_5865*(1.0-max(0,dot(node_8474, viewDirection))))),1);
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
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
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _node_9953; uniform float4 _node_9953_ST;
            uniform sampler2D _node_7544; uniform float4 _node_7544_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic_copy)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _reflectionfrenel)
                UNITY_DEFINE_INSTANCED_PROP( float, _opacityfrenel)
                UNITY_DEFINE_INSTANCED_PROP( float, _melt_kusseturitu)
                UNITY_DEFINE_INSTANCED_PROP( float, _texturekakudo)
                UNITY_DEFINE_INSTANCED_PROP( float, _melt_opacityclip)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
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
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
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
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float _opacityfrenel_var = UNITY_ACCESS_INSTANCED_PROP( Props, _opacityfrenel );
                float node_5865 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_opacityfrenel_var);
                float _reflectionfrenel_var = UNITY_ACCESS_INSTANCED_PROP( Props, _reflectionfrenel );
                float4 _node_9953_var = tex2D(_node_9953,TRANSFORM_TEX(i.uv0, _node_9953));
                float _melt_kusseturitu_var = UNITY_ACCESS_INSTANCED_PROP( Props, _melt_kusseturitu );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + ((node_5865*_reflectionfrenel_var)*float3(i.uv0,0.0)*pow(_node_9953_var.rgb,_melt_kusseturitu_var)).rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float _texturekakudo_var = UNITY_ACCESS_INSTANCED_PROP( Props, _texturekakudo );
                float node_2479_ang = _texturekakudo_var;
                float node_2479_spd = 1.0;
                float node_2479_cos = cos(node_2479_spd*node_2479_ang);
                float node_2479_sin = sin(node_2479_spd*node_2479_ang);
                float2 node_2479_piv = float2(0.5,0.5);
                float2 node_2479 = (mul(i.uv0-node_2479_piv,float2x2( node_2479_cos, -node_2479_sin, node_2479_sin, node_2479_cos))+node_2479_piv);
                float4 _node_9953_copy = tex2D(_node_7544,TRANSFORM_TEX(node_2479, _node_7544));
                float _melt_opacityclip_var = UNITY_ACCESS_INSTANCED_PROP( Props, _melt_opacityclip );
                float node_8474 = (_node_9953_copy.r+(_melt_opacityclip_var*1.0+-0.5));
                clip(node_8474 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float _Gloss_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss_copy );
                float gloss = _Gloss_copy_var;
                float perceptualRoughness = 1.0 - _Gloss_copy_var;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float _Metallic_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic_copy );
                float3 specularColor = _Metallic_copy_var;
                float specularMonochrome;
                float4 _Color_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color_copy );
                float3 diffuseColor = _Color_copy_var.rgb; // Need this for specular when using metallic
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
                fixed4 finalRGBA = fixed4(finalColor * (node_5865*(1.0-max(0,dot(node_8474, viewDirection)))),0);
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
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
            #pragma target 3.0
            uniform sampler2D _node_7544; uniform float4 _node_7544_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _texturekakudo)
                UNITY_DEFINE_INSTANCED_PROP( float, _melt_opacityclip)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float _texturekakudo_var = UNITY_ACCESS_INSTANCED_PROP( Props, _texturekakudo );
                float node_2479_ang = _texturekakudo_var;
                float node_2479_spd = 1.0;
                float node_2479_cos = cos(node_2479_spd*node_2479_ang);
                float node_2479_sin = sin(node_2479_spd*node_2479_ang);
                float2 node_2479_piv = float2(0.5,0.5);
                float2 node_2479 = (mul(i.uv0-node_2479_piv,float2x2( node_2479_cos, -node_2479_sin, node_2479_sin, node_2479_cos))+node_2479_piv);
                float4 _node_9953_copy = tex2D(_node_7544,TRANSFORM_TEX(node_2479, _node_7544));
                float _melt_opacityclip_var = UNITY_ACCESS_INSTANCED_PROP( Props, _melt_opacityclip );
                float node_8474 = (_node_9953_copy.r+(_melt_opacityclip_var*1.0+-0.5));
                clip(node_8474 - 0.5);
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
            #pragma multi_compile_instancing
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
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic_copy)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss_copy)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 _Color_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color_copy );
                float3 diffColor = _Color_copy_var.rgb;
                float specularMonochrome;
                float3 specColor;
                float _Metallic_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic_copy );
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic_copy_var, specColor, specularMonochrome );
                float _Gloss_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss_copy );
                float roughness = 1.0 - _Gloss_copy_var;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
