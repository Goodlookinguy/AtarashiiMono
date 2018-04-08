using System;

namespace AtarashiiMono.Framework
{
	public static partial class AmMath
	{
		public static class Interpolation
		{
			public static double Lerp(double start, double end, double percent)
			{
				return start + (end - start) * percent;
			}

			public static double LerpSafe(double start, double end, double percent)
			{
				return start + (end - start) * percent.ClampAsPercent();
			}

			public static double LerpAngle(double start, double end, double percent)
			{
				var change = (end - start) % 360.0;
				if (change > 180.0) change -= 360.0;
				return start + change * percent;
			}

			public static double LerpAngleSafe(double start, double end, double percent)
			{
				var change = (end - start) % 360.0;
				if (change > 180.0) change -= 360.0;
				return start + change * percent.ClampAsPercent();
			}

			public static double InvLerp(double start, double end, double value)
			{
				if (start < end)
				{
					if (value < start) return 0.0;
					if (value > end) return 1.0;

					value -= start;
					value /= end - start;
					return value;
				}

				if (start <= end) return 0.0;
				if (value < end) return 1.0;
				if (value > start) return 0.0;
				return 1.0 - (value - end) / (start - end);
			}

			public static double QuadEaseIn(double start, double end, double percent)
			{
				return start + (end - start) * percent * percent;
			}

			public static double QuadEaseInSafe(double start, double end, double percent)
			{
				return start + (end - start) * (percent * percent).ClampAsPercent();
			}

			public static double QuadEaseOut(double start, double end, double percent)
			{
				percent = 1.0 - percent;
				return start + (end - start) * percent * percent;
			}

			public static double QuadEaseOutSafe(double start, double end, double percent)
			{
				percent = 1.0 - percent;
				return start + (end - start) * (percent * percent).ClampAsPercent();
			}

			public static double QuadEaseInOut(double start, double end, double percent)
			{
				return start + (end - start) *
					(3.0 * percent * percent - 2.0 * percent * percent * percent);
			}

			public static double QuadEaseInOutSafe(double start, double end, double percent)
			{
				return start + (end - start) *
						(3.0 * percent * percent - 2.0 * percent * percent * percent).
							ClampAsPercent();
			}

			public static double LinearOut(double start, double end, double percent)
			{
				return start + (end - start) * (1.0 - percent);
			}

			public static double LinearOutSafe(double start, double end, double percent)
			{
				return start + (end - start) * (1.0 - percent).ClampAsPercent();
			}

			public static double LinearInOut(double start, double end, double percent)
			{
				return start + (end - start) * (Math.Abs(percent - 0.5) * 2.0);
			}

			public static double LinearInOutSafe(double start, double end, double percent)
			{
				return start + (end - start) * (Math.Abs(percent - 0.5) * 2.0).ClampAsPercent();
			}

			public static double LinearOutIn(double start, double end, double percent)
			{
				return start + (end - start) * (1.0 - Math.Abs(percent - 0.5) * 2.0);
			}

			public static double LinearOutInSafe(double start, double end, double percent)
			{
				return start + (end - start) * (1.0 - Math.Abs(percent - 0.5) * 2.0).ClampAsPercent();
			}
		}
	}
}
