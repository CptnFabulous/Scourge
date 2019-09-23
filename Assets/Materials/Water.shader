Shader "Custom/Water"
{
    Properties
    {
		_Color("Tex Color",Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Speed ("Speed", Range(1, 10)) = 1
		_Direction ("Direction", Range(0, 1)) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _ParallaxMap ("Height Map", 2D) = "black" {}
		_ParallaxSpeed ("Parallax Speed", Range(.5, 5)) = 1
		_ParallaxDirection ("Parallax Direction", Range(0, 1)) = 0
		_ParallaxStrength ("Parallax Strength", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_ParallaxMap;
        };

        half _Glossiness;
        half _Metallic;
		float _Speed;
		float _Direction;
		float _Parallax;
		sampler2D _ParallaxMap;
		float _ParallaxSpeed;
		float _ParallaxDirection;
		float _ParallaxStrength;
		float4 _Color;
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			float2 direction = float2(cos(_Direction * UNITY_PI * 2), sin(_Direction * UNITY_PI * 2));
			float2 parallaxDirection = float2(cos(_ParallaxDirection * UNITY_PI * 2), sin(_ParallaxDirection * UNITY_PI * 2));
			IN.uv_MainTex += tex2D(_ParallaxMap, IN.uv_ParallaxMap + parallaxDirection * _Time.x * _ParallaxSpeed) * _ParallaxStrength;
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex + direction * _Time.x * _Speed);
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
			//o.Albedo = _Color;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
