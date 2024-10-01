#pragma once

#pragma unmanaged

#ifndef Base_h
#define Base_h

#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include <WinBase.h>
#include <stdlib.h>

#define DllImport __declspec(dllimport)

typedef unsigned long uint;
typedef unsigned short ushort;
typedef unsigned long long ulong;
typedef unsigned char byte;

/* keyboard */

// DWORD key, WORD repeats, BYTE scanCode, BOOL isExtended, BOOL isWithAlt, BOOL wasDownBefore, BOOL isUpNow
typedef void(*KeyboardHandler)(uint, ushort, byte, int, int, int, int);
typedef void(*ScriptMainHandler)();

#pragma comment(lib, "Extension/ScriptHookRDR2.lib")

// Register keyboard handler
// must be called on dll attach
DllImport void keyboardHandlerRegister(KeyboardHandler handler);
// Unregister keyboard handler
// must be called on dll detach
DllImport void keyboardHandlerUnregister(KeyboardHandler handler);
/* scripts */
DllImport void scriptWait(uint time);
DllImport void scriptRegister(HMODULE module, ScriptMainHandler handler);
DllImport void scriptRegisterAdditionalThread(HMODULE module, ScriptMainHandler handler);
DllImport void scriptUnregister(HMODULE module);
DllImport void scriptUnregister(ScriptMainHandler handler); // deprecated
DllImport void nativeInit(ulong hash);
DllImport void nativePush64(ulong val);
DllImport ulong* nativeCall();
DllImport ulong* getGlobalPtr(int globalId);
DllImport int worldGetAllVehicles(int* arr, int arrSize);
DllImport int worldGetAllPeds(int* arr, int arrSize);
DllImport int worldGetAllObjects(int* arr, int arrSize);
DllImport int worldGetAllPickups(int* arr, int arrSize);
DllImport byte* getScriptHandleBaseAddress(int handle);

#endif // !Base_h


