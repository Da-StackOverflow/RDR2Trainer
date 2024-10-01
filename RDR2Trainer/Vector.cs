using System.Runtime.InteropServices;

namespace RDR2Trainer
{
	internal struct Vector2(float x, float y) : System.IEquatable<Vector2>
	{
		public float X = x;
		public float Y = y;

		public override readonly string ToString()
		{
			return string.Format("X:{0}, Y:{1}", X, Y);
		}

		public readonly bool Equals(Vector2 other)
		{
			return X == other.X && Y == other.Y;
		}
	}

	[StructLayout(LayoutKind.Explicit, Size = 24)]
	internal unsafe struct Vector3
	{
		[FieldOffset(0)]
		public float X;

		[FieldOffset(8)]
		public float Y;

		[FieldOffset(16)]
		public float Z;

		public Vector3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Vector3(Vector3* p)
		{
			X = p->X;
			Y = p->Y;
			Z = p->Z;
		}

		public Vector3(ulong* addr)
		{
			var p = (Vector3*)addr;
			X = p->X;
			Y = p->Y;
			Z = p->Z;
		}

		public Vector3(long* addr)
		{
			var p = (Vector3*)addr;
			X = p->X;
			Y = p->Y;
			Z = p->Z;
		}

		public override readonly string ToString()
		{
			return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
		}

		public readonly bool Equals(Vector3 other)
		{
			return X == other.X && Y == other.Y && Z == other.Z;
		}
	}
}
