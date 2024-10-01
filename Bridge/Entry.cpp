#include "CS_CPP_Bridge.h"

#pragma unmanaged
int __stdcall DllMain(HMODULE hModule, uint ul_reason_for_call, void* lpReserved)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		scriptRegister(hModule, ScriptMain);
		keyboardHandlerRegister(ScriptKeyboardMessage);
		break;
	case DLL_PROCESS_DETACH:
		Release();
		scriptUnregister(hModule);
		keyboardHandlerUnregister(ScriptKeyboardMessage);
		break;
	}
	return 1;
}

