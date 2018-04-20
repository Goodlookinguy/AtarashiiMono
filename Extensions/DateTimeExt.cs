using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtarashiiMono.Framework.Extensions
{
	public static class DateTimeExt
	{
		public static long TotalMillisecs(this DateTime dateTime)
		{
			return (long)(dateTime.Ticks / 10000.0);
		}
	}
}
