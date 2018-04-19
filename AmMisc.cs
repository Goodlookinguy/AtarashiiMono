using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtarashiiMono.Framework
{
	public static class AmMisc
	{
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
		private struct FloatAndIntUnion
		{
			public static FloatAndIntUnion Instance = default(FloatAndIntUnion);

			[System.Runtime.InteropServices.FieldOffset(0)]
			public int IntValue;

			[System.Runtime.InteropServices.FieldOffset(0)]
			public float FloatValue;

			[System.Runtime.InteropServices.FieldOffset(0)]
			public long LongValue;

			[System.Runtime.InteropServices.FieldOffset(0)]
			public double DoubleValue;
		}

		public static float IntBitsToFloat(int value)
		{
			FloatAndIntUnion.Instance.IntValue = value;
			return FloatAndIntUnion.Instance.FloatValue;
		}

		public static int FloatToIntBits(float value)
		{
			FloatAndIntUnion.Instance.FloatValue = value;
			return FloatAndIntUnion.Instance.IntValue;
		}

		public static double LongBitsToDouble(long value)
		{
			FloatAndIntUnion.Instance.LongValue = value;
			return FloatAndIntUnion.Instance.DoubleValue;
		}

		public static long DoubleToLongBits(double value)
		{
			FloatAndIntUnion.Instance.DoubleValue = value;
			return FloatAndIntUnion.Instance.LongValue;
		}
	}
}
