Shader "Custom/OutlineShader"
{
    Properties
    {
        _OutlineColor("Outline Color", Color) = (1,0,0,1)	// 외곽선의 색깔 (기본값을 빨간색으로)
        _Outline("Outline width", Range(0, 1)) = .1			// 외곽선의 두께
    }

	CGINCLUDE
	// 셰이더를 위한 내장함수
	#include "UnityCG.cginc"

	struct appdata
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f
	{
		float4 pos : POSITION;
		float4 color : COLOR;
	};

	uniform float _Outline;
	uniform float4 _OutlineColor;

	v2f vert(appdata v) {
		v2f o;

		v.vertex *= (1 + _Outline);

		o.pos = UnityObjectToClipPos(v.vertex);

		o.color = _OutlineColor;
		return o;
	}
	ENDCG

	SubShader{
		Tags { "DisableBatching" = "True" }

		Pass
		{
			Name "OUTLINE"
			Tags {"LightMode" = "Always" }
			Cull Front
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			// CG언어로 작성하겠다는 선언문.
			CGPROGRAM

			// 지시자. 셰이더에서 어떠한 기능을 사용한다고 명칭.
			#pragma vertex vert	
			#pragma fragment frag

			half4 frag(v2f i) :COLOR { return i.color; }

			// CG언어를 끝내겠다.
			ENDCG
		}
	}
    FallBack "Diffuse"
}
