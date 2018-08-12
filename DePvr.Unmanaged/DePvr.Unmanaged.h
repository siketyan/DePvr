#pragma once

#define _WINDLL_IMPORT
#define DLLEXPORT __declspec(dllexport)

#include <stdio.h>
#include <string.h>
#include <iostream>
#include <fstream>
#include "PVRTString.h"
#include "PVRTexture.h"
#include "PVRTextureUtilities.h"

using namespace pvrtexture;

extern "C"
{
	DLLEXPORT CPVRTexture* LoadFromFile(char* path);
    DLLEXPORT CPVRTexture* LoadFromMemory(void* pointer);
    DLLEXPORT bool Decode(CPVRTexture* pointer);
    DLLEXPORT bool FlipVertical(CPVRTexture* pvr);
    DLLEXPORT bool FlipHorizontal(CPVRTexture* pvr);
    DLLEXPORT unsigned int GetWidth(CPVRTexture* pvr);
    DLLEXPORT unsigned int GetHeight(CPVRTexture* pvr);
    DLLEXPORT unsigned int GetDataSize(CPVRTexture* pvr);
    DLLEXPORT void* GetDataPointer(CPVRTexture* pvr);
    DLLEXPORT void Dispose(CPVRTexture* pvr);
}
