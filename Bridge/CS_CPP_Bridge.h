#pragma once

#pragma unmanaged
#include "Base.h"
#include "Export.h"

#pragma managed

#ifndef CS_CPP_Bridge_h
#define CS_CPP_Bridge_h

using namespace System;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Collections::Generic;

public ref class ProxyObject : public MarshalByRefObject
{
private:
	Assembly^ assembly = nullptr;
	Dictionary<String^, Type^>^ types = gcnew Dictionary<String^, Type^>();
	Dictionary<String^, MethodInfo^>^ methods = gcnew Dictionary<String^, MethodInfo^>();
	Dictionary<String^, Object^>^ objects = gcnew Dictionary<String^, Object^>();

public:
	void Load()
	{
		assembly = Assembly::LoadFile(Path::GetFullPath("RDR2Script.dll"));
	}

	void Invoke(String^ fullClassName, String^ methodName)
	{
		Type^ tp = nullptr;
		MethodInfo^ method = nullptr;
		Object^ obj = nullptr;
		if (!types->TryGetValue(fullClassName, tp))
		{
			tp = assembly->GetType(fullClassName);
			types->Add(fullClassName, tp);
		}
		if (!methods->TryGetValue(fullClassName + methodName, method))
		{
			method = tp->GetMethod(methodName);
			methods->Add(fullClassName + methodName, method);
		}

		if (!objects->TryGetValue(fullClassName + methodName, obj))
		{

			obj = Activator::CreateInstance(tp);
			objects->Add(fullClassName + methodName, obj);
		}
		method->Invoke(obj, nullptr);
	}

	void Invoke(String^ fullClassName, String^ methodName, array<Object^>^ args)
	{
		Type^ tp = nullptr;
		MethodInfo^ method = nullptr;
		Object^ obj = nullptr;
		if (!types->TryGetValue(fullClassName, tp))
		{
			tp = assembly->GetType(fullClassName);
			types->Add(fullClassName, tp);
		}
		if (!methods->TryGetValue(fullClassName + methodName, method))
		{
			method = tp->GetMethod(methodName);
			methods->Add(fullClassName + methodName, method);
		}
		if (!objects->TryGetValue(fullClassName + methodName, obj))
		{
			obj = Activator::CreateInstance(tp);
			objects->Add(fullClassName + methodName, obj);
		}
		method->Invoke(obj, args);
	}
};

public enum ScriptState {
	Loading,
	Loaded,
	Unloading,
	Unloaded
};

public ref class Bridge
{
private:
	static AppDomain^ ScriptDomain = nullptr;
	static ProxyObject^ _obj = nullptr;
	static long long _operateTime = 0;
	static ScriptState _scriptState = ScriptState::Unloaded;
public:

	static void Unload()
	{
		long long time = GetTimeTicks();
		if (_scriptState == ScriptState::Loaded && time - _operateTime > 3000)
		{
			_operateTime = time;
			_scriptState = ScriptState::Unloading;
		}
	}

	static void OnUnload()
	{
		_obj->Invoke("Entry", "OnClose");
		AppDomain::Unload(ScriptDomain);
		_obj = nullptr;
		ScriptDomain = nullptr;
		_operateTime = GetTimeTicks();
		_scriptState = ScriptState::Unloaded;
	}

	static void Load()
	{
		long long time = GetTimeTicks();
		if (_scriptState == ScriptState::Unloaded && time - _operateTime > 3000)
		{
			_operateTime = time;
			_scriptState = ScriptState::Loading;
		}
	}

	static void OnLoad()
	{
		String^ callingDomainName = Path::GetFullPath("RDR2Asi.asi");
		ScriptDomain = AppDomain::CreateDomain(Guid::NewGuid().ToString());
		_obj = static_cast<ProxyObject^>(ScriptDomain->CreateInstanceFromAndUnwrap(callingDomainName, "ProxyObject"));
		_obj->Load();
		_obj->Invoke("Entry", "OnStart");
		_operateTime = GetTimeTicks();
		_scriptState = ScriptState::Loaded;
	}


	static void OnTick()
	{
		switch (_scriptState)
		{
		case ScriptState::Loaded:
			_obj->Invoke("Entry", "OnGameFrame");
			break;
		case ScriptState::Loading:
			OnLoad();
			break;
		case ScriptState::Unloading:
			OnUnload();
			break;
		}
	}

	static void SendKeyoardMessage(uint key, ushort repeats, byte scanCode, int isExtended, int isWithAlt, int wasDownBefore, int isUpNow)
	{
		switch (_scriptState)
		{
		case ScriptState::Loaded:
			if (key == VK_F8)
			{
				Unload();
			}
			else if (0 < key && key < 256)
			{
				array<Object^>^ args = { key, isUpNow == 1 };
				_obj->Invoke("Entry", "OnReceiveInputMessage", args);
			}
			break;
		case ScriptState::Unloaded:
			if (key == VK_F8)
			{
				Load();
			}
			break;
		}
	}
};

static void Execute() {
	while (true) {
		Bridge::OnTick();
		scriptWait(0);
	}
}

static void Release() {
	Bridge::OnUnload();
}

static void ScriptMain() {
	Bridge::Load();
	Execute();
}

static void ScriptKeyboardMessage(uint key, ushort repeats, byte scanCode, int isExtended, int isWithAlt, int wasDownBefore, int isUpNow) {
	Bridge::SendKeyoardMessage(key, repeats, scanCode, isExtended, isWithAlt, wasDownBefore, isUpNow);
}

#endif // !CS_CPP_Bridge_h
