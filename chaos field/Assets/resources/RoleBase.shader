Shader "Unlit/RoleBase"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MainCol("MainCol", Color) = (1, 1, 1, 1)
		_PowerCol("PowerCol", Color) = (0, 0, 0, 1)
		_PowerVal("PowerVal", float) = 1.0

	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			#pragma multi_compile_fwdadd
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			half4 _MainCol;
			half4 _PowerCol;
			half _PowerVal;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{


				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv) * _MainCol;

				if (i.uv.y > _PowerVal)
				{
					col = _PowerCol;
				}
				else {
					
				}

				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
