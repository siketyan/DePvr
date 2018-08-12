#include "DeEtc.h"

pvrtexture::CPVRTexture _pvr;

pvrtexture::CPVRTexture* LoadFromFile(char* path)
{
	pvrtexture::CPVRTexture pvr(path);
    Decode(&pvr);

    _pvr = pvr;
	return &_pvr;
}

pvrtexture::CPVRTexture* LoadFromMemory(void* pointer)
{
    pvrtexture::CPVRTexture pvr(pointer);
    Decode(&pvr);

    _pvr = pvr;
    return &_pvr;
}

bool Decode(pvrtexture::CPVRTexture* pvr)
{
    return pvrtexture::Transcode(
        *pvr,
        pvrtexture::PVRStandard8PixelType,
        ePVRTVarTypeUnsignedByteNorm,
        ePVRTCSpacelRGB
    );
}

bool FlipVertical(pvrtexture::CPVRTexture* pvr)
{
    return pvrtexture::Flip(*pvr, ePVRTAxisY);
}

bool FlipHorizontal(pvrtexture::CPVRTexture* pvr)
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
