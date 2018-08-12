#include "DeEtc.h"

pvrtexture::CPVRTexture* LoadPvr(char* path)
{
	pvrtexture::CPVRTexture pvr(path);
	pvrtexture::Transcode(
		pvr,
		pvrtexture::PVRStandard8PixelType,
		ePVRTVarTypeUnsignedByteNorm,
		ePVRTCSpacelRGB
	);

	return &pvr;
}

bool FlipPvrVertical(pvrtexture::CPVRTexture* pvr)
{
    return pvrtexture::Flip(*pvr, ePVRTAxisY);
}

bool FlipPvrHorizontal(pvrtexture::CPVRTexture* pvr)
{
    return pvrtexture::Flip(*pvr, ePVRTAxisX);
}

unsigned int GetDataSize(pvrtexture::CPVRTexture* pvr)
{
    return pvr->getDataSize();
}

void* GetDataPointer(pvrtexture::CPVRTexture* pvr)
{
    return pvr->getDataPtr();
}
