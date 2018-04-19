using System;
using System.Runtime.CompilerServices;
using AtarashiiMono.Framework.XNA.Extensions;
using Microsoft.Xna.Framework;
using OpenGL;

namespace AtarashiiMono.Framework
{
	public static partial class AmMath
	{
		public const double Deg2Rad = 0.0174532925199432;
		public const double Rad2Deg = 57.295779513082320;

		public static double Clamp(double value, double min, double max)
		{
			if (value < min) return min;
			if (value > max) return max;
			return value;
		}

		/// <summary>
		/// This is incomplete, only use with degrees min gte 0 and max lte 360
		/// </summary>
		/// <param name="degrees"></param>
		/// <param name="degreesMin"></param>
		/// <param name="degreesMax"></param>
		/// <returns></returns>
		public static double ClampAngle(this double degrees, double degreesMin, double degreesMax)
		{
			if (degrees > degreesMin && degrees < degreesMax)
				return degrees;

			var diff = (degreesMax - degreesMin) / 2.0;
			if (degrees <= degreesMin && degrees >= (degreesMin - diff)) return degreesMin;
			return degreesMax;
		}

		public static double ClampBetween(this double value, double min, double max)
		{
			if (value < min) return min;
			if (value > max) return max;
			return value;
		}

		public static double ClampPercent(double value)
		{
			if (value < 0.0) return 0.0;
			if (value > 1.0) return 1.0;
			return value;
		}

		public static double ClampAsPercent(this double value)
		{
			if (value < 0.0) return 0.0;
			if (value > 1.0) return 1.0;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Cosd(double degrees)
		{
			return Math.Cos(degrees * Deg2Rad);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Sind(double degrees)
		{
			return Math.Sin(degrees * Deg2Rad);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Atan2d(double y, double x)
		{
			return Math.Atan2(y, x) * Rad2Deg;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Acosd(double degrees)
		{
			return Math.Acos(degrees * Rad2Deg);
		}

		public static bool PointInRect(int pointX, int pointY, Rectangle rect)
		{
			return pointX >= rect.X && pointX < rect.X + rect.Width && pointY >= rect.Y && pointY < rect.Y + rect.Height;
		}

		public static bool PointInRect(Vector2 point, Rectangle rect)
		{
			return point.X >= rect.X && point.X < rect.X + rect.Width && point.Y >= rect.Y && point.Y < rect.Y + rect.Height;
		}

		public static bool RectsCollide(Rectangle a, Rectangle b)
		{
			if (a.IsEmpty || b.IsEmpty) return false;
			return !(a.Left >= b.Right || a.Right <= b.Left ||
					 a.Bottom <= b.Top || a.Top >= b.Bottom);
		}

		public static bool RectsOverlap(Rectangle a, Rectangle b)
		{
			double dx = Math.Abs(b.Center.X - a.Center.X) - (a.Width / 2 + b.Width / 2);
			double dy = Math.Abs(b.Center.Y - a.Center.Y) - (a.Height / 2 + b.Height / 2);
			return dx < 0.0 && dy < 0.0;
		}

		public static Vector2 ClosestPointToRect(Vector2 vec, Rectangle rect)
		{
			return vec.ClampBetween(new Vector2(rect.X, rect.Y), new Vector2(rect.X + rect.Width, rect.Y + rect.Height));
		}
	}
}
