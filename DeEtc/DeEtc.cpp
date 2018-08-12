#include "DeEtc.h"

pvrtexture::CPVRTexture _pvr;

pvrtexture::CPVRTexture* LoadPvrFromFile(char* path)
{
	pvrtexture::CPVRTexture pvr(path);
    TranscodePvr(&pvr);

    _pvr = pvr;
	return &_pvr;
}

pvrtexture::CPVRTexture* LoadPvrFromMemory(void* pointer)
{
    pvrtexture::CPVRTexture pvr(pointer);
    TranscodePvr(&pvr);

    _pvr = pvr;
    return &_pvr;
}

bool TranscodePvr(pvrtexture::CPVRTexture* pvr)
{
    return pvrtexture::Transcode(
        *pvr,
        pvrtexture::PVRStandard8PixelType,
        ePVRTVarTypeUnsignedByteNorm,
        ePVRTCSpacelRGB
    );
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
