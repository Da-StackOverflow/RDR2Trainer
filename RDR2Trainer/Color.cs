using System;

namespace RDR2Trainer
{
	internal readonly struct Color : IEquatable<Color>
	{
		public readonly byte A;
		public readonly byte R;
		public readonly byte G;
		public readonly byte B;

		public static readonly Color Red = new(0xff0000u);
		public static readonly Color Green = new(0x00ff00u);
		public static readonly Color Blue = new(0x0000ffu);
		public static readonly Color Yellow = new(0xffff00u);
		public static readonly Color White = new(0xffffffu);
		public static readonly Color Black = new(0x000000u);
		public static readonly Color Cyan = new(0x00ffffu);

		public Color(int colorNum, bool includeAlpha = false) : this((uint)colorNum, includeAlpha)
		{
		}

		public Color(uint colorNum, bool includeAlpha = false)
		{
			B = (byte)(colorNum & 0xff);
			G = (byte)((colorNum >> 8) & 0xff);
			R = (byte)((colorNum >> 16) & 0xff);
			A = includeAlpha ? (byte)((colorNum >> 24) & 0xff) : (byte)255;
		}

		public Color(byte r, byte g, byte b, byte a = 255)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}

		public override readonly string ToString()
		{
			return string.Format("A:{0:x}, R:{1:x}, G:{2:x}, B:{3:x}", A, R, G, B);
		}

		public readonly bool Equals(Color other)
		{
			return A == other.A && R == other.R && G == other.G && B == other.B;
		}
	}
}
