using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using AmMath = AtarashiiMono.Framework.AmMath;

namespace AtarashiiMono.Framework.XNA.Extensions
{
	public static class Vector2Ext
	{
		public static Vector2 Angle(this Vector2 self, double angle)
		{
			var len = self.Length();
			angle = (360.0 + angle) % 360.0;
			self.X = (float)(AmMath.Cosd(angle) * len);
			self.Y = (float)(AmMath.Sind(angle) * len);
			return self;
		}

		public static double Angle(this Vector2 self)
		{
			return (360.0 + AmMath.Atan2d(self.Y, self.X)) % 360.0;
		}

		public static Vector2 Rotate(this Vector2 self, double rotateBy)
		{
			return self.Angle(self.Angle() + rotateBy);
		}

		public static Vector2 Magnitude(this Vector2 self, double magnitude)
		{
			if (Math.Abs(self.X) < 0.000001 && Math.Abs(self.Y) < 0.000001)
				self.X = (float)magnitude;

			var normalized = Vector2.Normalize(self);
			self.X = (float)(normalized.X * magnitude);
			self.Y = (float)(normalized.Y * magnitude);

			return self;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Magnitude(this Vector2 self)
		{
			return self.Length();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double MagnitudeSquared(this Vector2 self)
		{
			return self.LengthSquared();
		}

		public static double AngleBetween(this Vector2 self, double x, double y)
		{
			return (360.0 + AmMath.Atan2d(y - self.Y, x - self.X)) % 360.0;
		}

		public static double AngleBetween(this Vector2 self, Vector2 vector2)
		{
			return (360.0 + AmMath.Atan2d(vector2.Y - self.Y, vector2.X - self.X)) % 360.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Clone(this Vector2 self)
		{
			return new Vector2(self.X, self.Y);
		}

		public static Vector2 Clone(this Vector2 self, double xChange, double yChange)
		{
			return new Vector2((float)(self.X + xChange), (float)(self.Y + yChange));
		}
	}
}
