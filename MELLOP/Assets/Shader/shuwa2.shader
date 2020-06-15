// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32832,y:32600,varname:node_4013,prsc:2|diff-1304-RGB,emission-846-OUT,transm-3833-OUT,alpha-392-OUT,refract-3424-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32411,y:32501,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5091265,c3:0,c4:0.8;n:type:ShaderForge.SFN_Multiply,id:3424,x:32599,y:32972,varname:node_3424,prsc:2|A-716-OUT,B-2180-UVOUT;n:type:ShaderForge.SFN_Fresnel,id:716,x:32347,y:32887,varname:node_716,prsc:2|EXP-4063-OUT;n:type:ShaderForge.SFN_Slider,id:4063,x:31935,y:32881,ptovrint:False,ptlb:node_4063,ptin:_node_4063,varname:node_4063,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_TexCoord,id:2180,x:32347,y:33081,varname:node_2180,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:392,x:32376,y:32806,ptovrint:False,ptlb:node_392,ptin:_node_392,varname:node_392,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7113499,max:1;n:type:ShaderForge.SFN_Color,id:8584,x:32036,y:32549,ptovrint:False,ptlb:Color_copy,ptin:_Color_copy,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.509804,c3:0,c4:0.8;n:type:ShaderForge.SFN_Slider,id:2765,x:31935,y:32717,ptovrint:False,ptlb:node_2765,ptin:_node_2765,varname:node_2765,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:846,x:32245,y:32592,varname:node_846,prsc:2|A-8584-RGB,B-2765-OUT;n:type:ShaderForge.SFN_Slider,id:3833,x:32332,y:32720,ptovrint:False,ptlb:node_3833,ptin:_node_3833,varname:node_3833,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:1304-4063-392-8584-2765-3833;pass:END;sub:END;*/

Shader "Shader Forge/shuwa2" {
    Properties {
        _Color ("Color", Color) = (1,0.5091265,0,0.8)
        _node_4063 ("node_4063", Range(0, 1)) = 1
        _node_392 ("node_392", Range(0, 1)) = 0.7113499
        _Color_copy ("Color_copy", Color) = (1,0.509804,0,0.8)
        _node_2765 ("node_2765", Range(0, 1)) = 1
        _node_3833 ("node_3833", Range(0, 1)) = 0
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4063)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_392)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2765)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_3833)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float _node_4063_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4063 );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_4063_var)*i.uv0);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float _node_3833_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_3833 );
                float3 backLight = max(0.0, -NdotL ) * float3(_node_3833_var,_node_3833_var,_node_3833_var);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 diffuseColor = _Color_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _Color_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color_copy );
                float _node_2765_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2765 );
                float3 emissive = (_Color_copy_var.rgb*_node_2765_var);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                float _node_392_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_392 );
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,_node_392_var),1);
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4063)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_392)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2765)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_3833)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float _node_4063_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4063 );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_4063_var)*i.uv0);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float _node_3833_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_3833 );
                float3 backLight = max(0.0, -NdotL ) * float3(_node_3833_var,_node_3833_var,_node_3833_var);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 diffuseColor = _Color_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float _node_392_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_392 );
                fixed4 finalRGBA = fixed4(finalColor * _node_392_var,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
