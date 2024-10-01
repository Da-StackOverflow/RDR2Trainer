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

		public static ulong V(long* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(ulong* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(int* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(uint* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(sbyte* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(byte* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(short* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(ushort* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(float* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(double* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(Vector3* ptr)
		{
			return (ulong)ptr;
		}

		public static ulong V(bool value)
		{
			return value ? 1ul : 0ul;
		}

		public static ulong V(long value)
		{
			return (ulong)value;
		}

		public static ulong V(ulong value)
		{
			return value;
		}

		public static ulong V(int value)
		{
			return (ulong)value;
		}

		public static ulong V(uint value)
		{
			return value;
		}
		public static ulong V(short value)
		{
			return (ulong)value;
		}

		public static ulong V(ushort value)
		{
			return value;
		}

		public static ulong V(byte value)
		{
			return value;
		}

		public static ulong V(sbyte value)
		{
			return (ulong)value;
		}

		public static ulong V(Vector3 value)
		{
			return *(ulong*)&value;
		}

		public static ulong V(double value)
		{
			return *(ulong*)&value;
		}

		public static ulong V(float value)
		{
			return *(ulong*)&value;
		}

		public static ulong V(string value, bool showAtScreen = true)
		{
			if (showAtScreen)
			{
				return _VarString(GetBytePtr(value));
			}
			return V(GetBytePtr(value));
		}

		public static ulong V(byte[] value)
		{
			fixed (byte* ptr = value)
			{
				return *(ulong*)ptr;
			}
		}

		public static void VoidInvoke(ulong function, params ulong[] args)
		{
			ULongPointerInvoke(function, args);
		}

		public static ulong ULongInvoke(ulong function, params ulong[] args)
		{
			return *ULongPointerInvoke(function, args);
		}

		public static long LongInvoke(ulong function, params ulong[] args)
		{
			return (long)*ULongPointerInvoke(function, args);
		}

		public static uint UIntInvoke(ulong function, params ulong[] args)
		{
			return (uint)*ULongPointerInvoke(function, args);
		}

		public static int IntInvoke(ulong function, params ulong[] args)
		{
			return (int)*ULongPointerInvoke(function, args);
		}

		public static ushort UShortInvoke(ulong function, params ulong[] args)
		{
			return (ushort)*ULongPointerInvoke(function, args);
		}

		public static short ShortInvoke(ulong function, params ulong[] args)
		{
			return (short)*ULongPointerInvoke(function, args);
		}

		public static byte ByteInvoke(ulong function, params ulong[] args)
		{
			return (byte)*ULongPointerInvoke(function, args);
		}

		public static sbyte SByteInvoke(ulong function, params ulong[] args)
		{
			return (sbyte)*ULongPointerInvoke(function, args);
		}

		public static bool BoolInvoke(ulong function, params ulong[] args)
		{
			return *ULongPointerInvoke(function, args) != 0ul;
		}

		public static float FloatInvoke(ulong function, params ulong[] args)
		{
			return *(float*)ULongPointerInvoke(function, args);
		}

		public static double DoubleInvoke(ulong function, params ulong[] args)
		{
			return *(double*)ULongPointerInvoke(function, args);
		}

		public static Vector3 Vector3Invoke(ulong function, params ulong[] args)
		{
			return new Vector3(ULongPointerInvoke(function, args));
		}

		public static void* PointerInvoke(ulong function, params ulong[] args)
		{
			return ULongPointerInvoke(function, args);
		}

		public static ulong* ULongPointerInvoke(ulong function, params ulong[] args)
		{
			_InitFunc(function);
			for (int i = 0; i < args.Length; i++)
			{
				_PushArg(args[i]);
			}
			return _Invoke();
		}

		public static long* LongPointerInvoke(ulong function, params ulong[] args)
		{
			return (long*)ULongPointerInvoke(function, args);
		}

		public static int* IntPointerInvoke(ulong function, params ulong[] args)
		{
			return (int*)ULongPointerInvoke(function, args);
		}

		public static uint* UIntPointerInvoke(ulong function, params ulong[] args)
		{
			return (uint*)ULongPointerInvoke(function, args);
		}

		public static short* ShortPointerInvoke(ulong function, params ulong[] args)
		{
			return (short*)ULongPointerInvoke(function, args);
		}

		public static ushort* UShortPointerInvoke(ulong function, params ulong[] args)
		{
			return (ushort*)ULongPointerInvoke(function, args);
		}

		public static byte* BytePointerInvoke(ulong function, params ulong[] args)
		{
			return (byte*)ULongPointerInvoke(function, args);
		}

		public static sbyte* SbytePointerInvoke(ulong function, params ulong[] args)
		{
			return (sbyte*)ULongPointerInvoke(function, args);
		}

		public static float* FloatPointerInvoke(ulong function, params ulong[] args)
		{
			return (float*)ULongPointerInvoke(function, args);
		}

		public static double* DoublePointerInvoke(ulong function, params ulong[] args)
		{
			return (double*)ULongPointerInvoke(function, args);
		}

		public static Vector3* Vector3PointerInvoke(ulong function, params ulong[] args)
		{
			return (Vector3*)ULongPointerInvoke(function, args);
		}
	}
}
