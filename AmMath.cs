using System;
using System.Runtime.CompilerServices;

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
	}
}
