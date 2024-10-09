using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace RDR2Trainer
{
	internal unsafe static class Native
	{
		#region DLLImport

		private const string RDR2Asi = "RDR2Asi.asi";

		[DllImport(RDR2Asi)]
		private static extern void ThreadSleep(uint time);

		[DllImport(RDR2Asi)]
		private static extern void InitFunc(ulong hash);

		[DllImport(RDR2Asi)]
		private static extern void PushArg(ulong val);

		[DllImport(RDR2Asi)]
		private static extern ulong* Invoke();

		[DllImport(RDR2Asi)]
		private static extern ulong* GetGamePtr(int globalId);

		[DllImport(RDR2Asi)]
		private static extern int WorldGetAllVehicles(int* arr, int arrSize);

		[DllImport(RDR2Asi)]
		private static extern int WorldGetAllPeds(int* arr, int arrSize);

		[DllImport(RDR2Asi)]
		private static extern int WorldGetAllObjects(int* arr, int arrSize);

		[DllImport(RDR2Asi)]
		private static extern int WorldGetAllPickups(int* arr, int arrSize);

		[DllImport(RDR2Asi)]
		private static extern byte* GetScriptHandleBaseAddress(int handle);

		[DllImport(RDR2Asi)]
		private static extern ulong VarString(byte* ptr);

		[DllImport(RDR2Asi)]
		private static extern long GetTimeTicks();

		[DllImport(RDR2Asi)]
		private static extern int FreeBuffer(byte* ptr);

		[DllImport(RDR2Asi)]
		private static extern byte* CreateBuffer(int size);

		#endregion

		private delegate void DThreadSleep(uint time);
		private delegate void DInitFunc(ulong hash);
		private delegate void DPushArg(ulong val);
		private delegate ulong* DInvoke();
		private delegate ulong* DGetGamePtr(int globalId);
		private delegate int DWorldGetAllVehicles(int* arr, int arrSize);
		private delegate int DWorldGetAllPeds(int* arr, int arrSize);
		private delegate int DWorldGetAllObjects(int* arr, int arrSize);
		private delegate int DWorldGetAllPickups(int* arr, int arrSize);
		private delegate byte* DGetScriptHandleBaseAddress(int handle);
		private delegate ulong DVarString(byte* ptr);
		private delegate long DGetTimeTicks();
		private delegate int DFreeBuffer(byte* ptr);
		private delegate byte* DCreateBuffer(int size);

		private static DThreadSleep _ThreadSleep;
		private static DInitFunc _InitFunc;
		private static DPushArg _PushArg;
		private static DInvoke _Invoke;
		private static DGetGamePtr _GetGamePtr;
		private static DWorldGetAllVehicles _WorldGetAllVehicles;
		private static DWorldGetAllPeds _WorldGetAllPeds;
		private static DWorldGetAllObjects _WorldGetAllObjects;
		private static DWorldGetAllPickups _WorldGetAllPickups;
		private static DGetScriptHandleBaseAddress _GetScriptHandleBaseAddress;
		private static DVarString _VarString;
		private static DGetTimeTicks _GetTimeTicks;
		private static DFreeBuffer _FreeBuffer;
		private static DCreateBuffer _CreateBuffer;

		static Native()
		{
			_ThreadSleep += ThreadSleep;
			_InitFunc += InitFunc;
			_PushArg += PushArg;
			_Invoke += Invoke;
			_GetGamePtr += GetGamePtr;
			_WorldGetAllVehicles += WorldGetAllVehicles;
			_WorldGetAllPeds += WorldGetAllPeds;
			_WorldGetAllObjects += WorldGetAllObjects;
			_WorldGetAllPickups += WorldGetAllPickups;
			_GetScriptHandleBaseAddress += GetScriptHandleBaseAddress;
			_VarString += VarString;
			_GetTimeTicks += GetTimeTicks;
			_FreeBuffer += FreeBuffer;
			_CreateBuffer += CreateBuffer;
		}

		public static void Sleep(uint time)
		{
			_ThreadSleep(time);
		}

		public static long GetTickCount()
		{
			return _GetTimeTicks();
		}

		private static readonly Dictionary<string, int> _stringPool = [];
		private static readonly Encoding _encoding = Encoding.UTF8;

		private static byte* _buffer = default;
		private static int _bufferSize;
		private static int _bufferPosition;

		public static void Release()
		{
			if (_bufferSize > 0)
			{
				_FreeBuffer(_buffer);
				_buffer = default;
				_bufferSize = 0;
				_bufferPosition = 0;
			}
			_ThreadSleep -= ThreadSleep;
			_InitFunc -= InitFunc;
			_PushArg -= PushArg;
			_Invoke -= Invoke;
			_GetGamePtr -= GetGamePtr;
			_WorldGetAllVehicles -= WorldGetAllVehicles;
			_WorldGetAllPeds -= WorldGetAllPeds;
			_WorldGetAllObjects -= WorldGetAllObjects;
			_WorldGetAllPickups -= WorldGetAllPickups;
			_GetScriptHandleBaseAddress -= GetScriptHandleBaseAddress;
			_VarString -= VarString;
			_GetTimeTicks -= GetTimeTicks;
			_FreeBuffer -= FreeBuffer;
			_CreateBuffer -= CreateBuffer;
		}

		private static byte* GetBytePtr(int position)
		{
			if (_bufferSize == 0)
			{
				return default;
			}
			return _buffer + position;
		}

		private static int StoreBytes(byte[] bytes)
		{
			if (_bufferSize <= 0)
			{
				_buffer = _CreateBuffer(2048);
				_bufferSize = 2048;
				_bufferPosition = 0;
			}
			if (_bufferPosition + bytes.Length >= _bufferSize)
			{
				var buffer = _CreateBuffer((_bufferPosition + bytes.Length) * 2);
				for (int i = 0; i < _bufferPosition; i++)
				{
					*(buffer + i) = *(_buffer + i);
				}
				_FreeBuffer(_buffer);
				_buffer = buffer;
			}
			for (int i = 0; i < bytes.Length; i++)
			{
				*(_buffer + _bufferPosition + i) = bytes[i];
			}
			var result = _bufferPosition;
			_bufferPosition += bytes.Length;
			return result;
		}

		public static byte* GetBytePtr(string s)
		{
			if (_stringPool.TryGetValue(s, out var offset))
			{
				return GetBytePtr(offset);
			}

			offset = StoreBytes(_encoding.GetBytes($"{s}\0"));
			if (offset < 0)
			{
				return default;
			}

			_stringPool.Add(s, offset);
			return GetBytePtr(offset);
		}

		public static ulong* GetGlobalPtr(int globalId)
		{
			return _GetGamePtr(globalId);
		}

		public static ulong V(void* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V<T>(T value) where T : unmanaged
		{
			return *(ulong*)&value;
		}

		public static ulong V(string value, bool showAtScreen = false)
		{
			if (showAtScreen)
			{
				return _VarString(GetBytePtr(value));
			}
			return V(GetBytePtr(value));
		}

		public static void Invoke(ulong function, params ulong[] args)
		{
			_InitFunc(function);
			for (int i = 0; i < args.Length; i++)
			{
				_PushArg(args[i]);
			}
			_Invoke();
		}

		public static T* PInvoke<T>(ulong function, params ulong[] args) where T : unmanaged
		{
			_InitFunc(function);
			for (int i = 0; i < args.Length; i++)
			{
				_PushArg(args[i]);
			}
			return (T*)_Invoke();
		}

		public static T Invoke<T>(ulong function, params ulong[] args) where T : unmanaged
		{
			return *PInvoke<T>(function, args);
		}
	}
}
