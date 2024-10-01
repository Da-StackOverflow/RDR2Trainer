#pragma once

#pragma unmanaged
#include "Base.h"

#ifndef Export_h
#define Export_h

#define DllExport extern "C" __declspec(dllexport)

DllExport void ThreadSleep(uint time);
DllExport void InitFunc(ulong hash);
DllExport void PushArg(ulong val);
DllExport ulong* Invoke();
DllExport ulong* GetGamePtr(int globalId);
DllExport int WorldGetAllVehicles(int* arr, int arrSize);
DllExport int WorldGetAllPeds(int* arr, int arrSize);
DllExport int WorldGetAllObjects(int* arr, int arrSize);
DllExport int WorldGetAllPickups(int* arr, int arrSize);
DllExport byte* GetScriptHandleBaseAddress(int handle);

DllExport ulong VarString(char* c);
DllExport long long GetTimeTicks();
DllExport byte* CreateBuffer(int size);
DllExport void FreeBuffer(byte* ptr);
#endif // !Export_h
