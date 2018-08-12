#include "DeEtc.h"

CPVRTexture* LoadFromFile(char* path)
{
	CPVRTexture* pvr = new CPVRTexture(path);
    Decode(pvr);

    return pvr;
}

CPVRTexture* LoadFromMemory(void* pointer)
{
    CPVRTexture* pvr = new CPVRTexture(pointer);
    Decode(pvr);

    return pvr;
}

bool Decode(CPVRTexture* pvr)
{
    return Transcode(
        *pvr,
        PVRStandard8PixelType,
        ePVRTVarTypeUnsignedByteNorm,
        ePVRTCSpacelRGB
    );
}

bool FlipVertical(CPVRTexture* pvr)
{
    return Flip(*pvr, ePVRTAxisY);
}

bool FlipHorizontal(CPVRTexture* pvr)
{
    return Flip(*pvr, ePVRTAxisX);
}

unsigned int GetWidth(CPVRTexture* pvr)
{
    return pvr->getWidth();
}

unsigned int GetHeight(CPVRTexture* pvr)
{
    return pvr->getHeight();
}

unsigned int GetDataSize(CPVRTexture* pvr)
{
    return pvr->getDataSize();
}

void* GetDataPointer(CPVRTexture* pvr)
{
    return pvr->getDataPtr();
}

void Dispose(CPVRTexture* pvr)
{
    delete pvr;
}
