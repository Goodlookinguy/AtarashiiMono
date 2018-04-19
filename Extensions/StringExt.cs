using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtarashiiMono.Framework.Extensions
{
	public static class StringExt
	{
		//Rot5, Rot13, and Rot18 are interchanglable, Rot47 is not

		// Rotates numbers (0-9)
		public static string Rot5(this string self)
		{
			var sout = new char[self.Length];

			for (int i = 0; i < self.Length; ++i)
				sout[i] = self[i] >= 48 && self[i] <= 57 ? (char) (48 + ((self[i] - 43) % 10)) : self[i];

			return new string(sout);
		}

		// Rotates letters (A-Z and a-z)
		public static string Rot13(this string self)
		{
			var sout = new char[self.Length];

			for (int i = 0; i < self.Length; ++i)
			{
				sout[i] = (char) (64 ^ (self[i] & 223));

				sout[i] = sout[i] < 27 && sout[i] != 0 ? (char) (((self[i] & 96) | (sout[i] + 12) % 26) + 1) : self[i];
			}

			return new string(sout);
		}

		// Rotates letters and numbers (0-9, A-Z, and a-z)
		public static string Rot18(this string self)
		{
			var sout = new char[self.Length];

			for (int i = 0; i < self.Length; ++i)
			{
				sout[i] = (char) (64 ^ (self[i] & 223));

				if (sout[i] < 27 && sout[i] != 0)
					sout[i] = (char) (((self[i] & 96) | (sout[i] + 12) % 26) + 1);
				else if (self[i] >= 48 && self[i] <= 57)
					sout[i] = (char) (48 + ((self[i] - 43) % 10));
				else
					sout[i] = self[i];
			}

			return new string(sout);
		}

		// Rotates letters, numbers, and symbols
		public static string Rot47(this string self)
		{
			var sout = new char[self.Length];

			for (int i = 0; i < self.Length; ++i)
				sout[i] = self[i] > 32 && self[i] < 127 ? (char) (33 + ((self[i] + 14) % 94)) : self[i];

			return new string(sout);
		}
	}
}
