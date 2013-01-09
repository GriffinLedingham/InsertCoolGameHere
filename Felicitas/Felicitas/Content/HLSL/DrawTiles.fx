// ------------------------------------------------------------------------------------
// MetaTunnel - Credits to Anatole Duprat - XT95 / Frequency
// Released at Numerica Artparty 2009
// http://pouet.net/prod.php?which=52777
// Effect compiled with: tkfxc.exe /FoMetaTunnel.fxo MetaTunnel.fx
// ------------------------------------------------------------------------------------

float2 TilePositions[1000];
float TileCount;

Texture2D TileTexture;
sampler Sampler;

float2 TextureSize;

float2 ImageSize;

float4 PSMain(float2 tex : TEXCOORD) : SV_TARGET
{

	float2 curPos = tex * ImageSize;
	float2 textureCoord = float2(-1,-1);
	[unroll(4)]
	for(int i = 0; i < TileCount; i++){
		if(curPos.x > TilePositions[i].x && curPos.x < TilePositions[i].x + TextureSize.x &&
			curPos.y > TilePositions[i].y && curPos.y < TilePositions[i].y + TextureSize.y){
				textureCoord = curPos - TilePositions[i];
				break;
		}
	}

	if(textureCoord.x >= 0){
		return TileTexture.Sample(Sampler, textureCoord/TextureSize);
	}else{
		return float4(1,0,0,1);
	}

}

technique 
{
	pass 
	{
		Profile = 9.3;
		PixelShader = PSMain;
	}
}