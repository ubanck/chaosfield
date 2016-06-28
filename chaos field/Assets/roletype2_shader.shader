Shader "Custom/roletype2_shader" {
	Properties{
		_MainTex("Base(RGB)",2D) = "white"{}
		_Color("MainColor(RGB)",Color) = (1,1,1,1)
		_process("pro",float)=1
	}
	SubShader{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			float4 _Color;
			float _process;
			sampler2D  _MainTex;
			float4 _MainTex_ST;
			struct v2f {
			float4  pos : SV_POSITION;
			float2 uv : TEXCOORD0;
		};
		v2f vert(appdata_base v)
		{
			v2f o;
			o.pos = mul(UNITY_MATRIX_MVP,v.vertex);
			o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
			return o;
		}
		float4 frag(v2f i) : COLOR
		{
			float4 texCol = tex2D(_MainTex,i.uv);

			if (i.uv.y < _process)
			{
				return float4(0,0,0,0);
			}
			else
			{
				return float4(1, 1, 1, 0);
			}

			float4 outp = _Color*texCol;
			return outp;
		}
		ENDCG
	}

	}
	FallBack "Diffuse"
}