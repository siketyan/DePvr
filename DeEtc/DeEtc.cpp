#include "DeEtc.h"

pvrtexture::CPVRTexture _pvr;

pvrtexture::CPVRTexture* LoadPvr(char* path)
{
	pvrtexture::CPVRTexture pvr(path);
	pvrtexture::Transcode(
		pvr,
		pvrtexture::PVRStandard8PixelType,
		ePVRTVarTypeUnsignedByteNorm,
		ePVRTCSpacelRGB
	);

    _pvr = pvr;
	return &_pvr;
}

bool FlipPvrVertical(pvrtexture::CPVRTexture* pvr)
{
    return pvrtexture::Flip(*pvr, ePVRTAxisY);
}

bool FlipPvrHorizontal(pvrtexture::CPVRTexture* pvr)
{
    return pvrtexture::Flip(*pvr, ePVRTAxisX);
}

unsigned int GetWidth(pvrtexture::CPVRTexture* pvr)
{
    return pvr->getWidth();
}

unsigned int GetHeight(pvrtexture::CPVRTexture* pvr)
{
    return pvr->getHeight();
}

unsigned int GetDataSize(pvrtexture::CPVRTexture* pvr)
{
    return pvr->getDataSize();
}

void* GetDataPointer(pvrtexture::CPVRTexture* pvr)
{
    return pvr->getDataPtr();
}
