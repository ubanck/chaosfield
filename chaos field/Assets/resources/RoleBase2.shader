Shader "Custom/RoleBase2" {
	Properties {
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_MainTex("Texture", 2D) = "white" {}
		_MainCol("MainCol", Color) = (1, 1, 1, 1)
		_PowerCol("PowerCol", Color) = (0, 0, 0, 1)
		_PowerVal("PowerVal", float) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		half4 _MainCol;
		half4 _PowerCol;
		half _PowerVal;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		half4 LightingStandard(SurfaceOutputStandard s, half3 lightDir, half atten) {
			half4 c = half4(s.Albedo, 1);
			c.a = s.Alpha;
			return c;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 col = tex2D(_MainTex, IN.uv_MainTex) * _MainCol;

			if (IN.uv_MainTex.y > _PowerVal)
			{
				col = _PowerCol;
			}
			else {

			}


			o.Albedo = col.rgb;

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = col.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
