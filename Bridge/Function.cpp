#pragma unmanaged

#include "Export.h"
#include <chrono>

DllExport void ThreadSleep(uint time) {
	return scriptWait(time);
}

DllExport void InitFunc(ulong hash) {
	return nativeInit(hash);
}

DllExport void PushArg(ulong val) {
	return nativePush64(val);
}

DllExport ulong* Invoke() {
	return nativeCall();
}

DllExport ulong* GetGamePtr(int globalId) {
	return getGlobalPtr(globalId);
}

DllExport int WorldGetAllVehicles(int* arr, int arrSize) {
	return worldGetAllVehicles(arr, arrSize);
}

DllExport int WorldGetAllPeds(int* arr, int arrSize) {
	return worldGetAllPeds(arr, arrSize);
}

DllExport int WorldGetAllObjects(int* arr, int arrSize) {
	return worldGetAllObjects(arr, arrSize);
}

DllExport int WorldGetAllPickups(int* arr, int arrSize) {
	return worldGetAllPickups(arr, arrSize);
}

DllExport byte* GetScriptHandleBaseAddress(int handle) {
	return getScriptHandleBaseAddress(handle);
}

const char* _VarStringFlag = "LITERAL_STRING";
DllExport ulong VarString(char* text) {
	nativeInit(0xFA925AC00EB830B9);
	nativePush64(10);
	nativePush64((ulong)_VarStringFlag);
	nativePush64((ulong)text);
	return *nativeCall();
}

DllExport long long GetTimeTicks() {
	return std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch()).count();
}

DllExport byte* CreateBuffer(int size) {
	if (size <= 0) {
		return nullptr;
	}
	return (byte*)calloc(size, 1);
}

DllExport void FreeBuffer(byte* ptr) {
	free(ptr);
}