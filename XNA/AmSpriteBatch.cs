﻿using AtarashiiMono.Framework;
using AtarashiiMono.Framework.XNA.Extensions;

namespace AtarashiiMono.Framework.XNA
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	class AmSpriteBatch : SpriteBatch
	{
		// I didn't want to implement a full matrix system because I only need translations for right now.

		private int[] _translation = new int[32];
		private int _translationIndex = 0;

		public AmSpriteBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice)
		{
			Matrix mat = new Matrix();
			
		}

		public void DrawImage(AmImage2D image, double x, double y)
		{
			Draw(
				image.Texture,
				new Rectangle(
					_translation[_translationIndex] + (int)x,
					_translation[_translationIndex + 1] + (int)y,
					image.Width, image.Height),
				new Rectangle(image.SubX, image.SubY, image.Width, image.Height),
				Color.White
			);
		}
		/*
		public void DrawImage(Image2D image, double x, double y, double scale)
		{
			Draw(
				image.Texture,
				new Rectangle(
					_translation[_translationIndex] + (int)x,
					_translation[_translationIndex + 1] + (int)y, 
					(int)(image.Width * scale), (int)(image.Height * scale)),
				new Rectangle(image.SubX, image.SubY, image.Width, image.Height),
				Color.White
			);
		}
		*/
		public void DrawImage(AmImage2D image, double x, double y, double scaleX, double scaleY)
		{
			Draw(
				image.Texture,
				new Rectangle(
					_translation[_translationIndex] + (int)x,
					_translation[_translationIndex + 1] + (int)y,
					(int)(image.Width * scaleX), (int)(image.Height * scaleY)),
				new Rectangle(image.SubX, image.SubY, image.Width, image.Height),
				Color.White
			);

			
		}

		public void DrawImage(AmImage2D image, double x, double y, double rotation)
		{
			/*
			 (Texture2D texture,
			Rectangle destinationRectangle,
			Rectangle? sourceRectangle,
			Color color,
			float rotation,
			Vector2 origin,
			SpriteEffects effects,
            float layerDepth)
			 */
			/*Draw(
				image.Texture,
				new Rectangle(
					_translation[_translationIndex] + (int)x,
					_translation[_translationIndex + 1] + (int)y,
					image.Width, image.Height),
				new Rectangle(image.SubX, image.SubY, image.Width, image.Height),
				Color.White,
				rotation,
				Vector2.Zero,
				SpriteEffects.None,
				0.0f
			);*/
			//this.Draw();
		}

		public void PushMatrix()
		{
			_translation[_translationIndex + 2] = _translation[_translationIndex];
			_translation[_translationIndex + 3] = _translation[_translationIndex + 1];
			_translationIndex += 2;
		}

		public void PopMatrix()
		{
			_translationIndex -= 2;
		}

		public void Translate(int x, int y)
		{
			_translation[_translationIndex] += x;
			_translation[_translationIndex + 1] += y;
		}

		public void TranslateX(int x)
		{
			_translation[_translationIndex] += x;
		}

		public void TranslateY(int y)
		{
			_translation[_translationIndex + 1] += y;
		}

		public void SetIdentityMatrix()
		{
			_translation[_translationIndex] = 0;
			_translation[_translationIndex + 1] = 0;
		}

		public void ResetTranslation()
		{
			_translation[_translationIndex] = 0;
			_translation[_translationIndex + 1] = 0;
		}

		public Vector2 GetRealPosition(double x, double y)
		{
			return new Vector2
			(
				(float)(_translation[_translationIndex] + x),
				(float)(_translation[_translationIndex + 1] + y)
			);
		}

		public Vector2 GetRealPosition(Vector2 vector2)
		{
			return new Vector2
			(
				(float)(_translation[_translationIndex] + vector2.X),
				(float)(_translation[_translationIndex + 1] + vector2.Y)
			);
		}

		public Vector2 InvTranslate(Vector2 vector2)
		{
			return new Vector2
			(
				(float)(vector2.X - _translation[_translationIndex]),
				(float)(vector2.Y - _translation[_translationIndex + 1])
			);
		}

		public void DrawText(SpriteFont spriteFont, string text, float x, float y, Color color)
		{
			DrawString(spriteFont, text, new Vector2(x, y), color, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
		}

		public void DrawText(SpriteFont spriteFont, string text, float x, float y, Color color, float layerDepth)
		{
			DrawString(spriteFont, text, new Vector2(x, y), color, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, layerDepth);
		}

		public void DrawText(SpriteFont spriteFont, string text, float x, float y, Color color, SpriteEffects spriteEffects, float layerDepth)
		{
			DrawString(spriteFont, text, new Vector2(x, y), color, 0, Vector2.Zero, Vector2.One, spriteEffects, layerDepth);
		}

		public new void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
		{
			position = position.Clone(_translation[_translationIndex], _translation[_translationIndex + 1]);
			base.DrawString(spriteFont, text, position, color);
		}

		// this one just calls another DrawString, so avoid changing
		//public new void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation,
		//	Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
		//{
		//	base.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		//}

		public new void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation,
			Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			position = position.Clone(_translation[_translationIndex], _translation[_translationIndex + 1]);
			base.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		}

		public new void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
		{
			position = position.Clone(_translation[_translationIndex], _translation[_translationIndex + 1]);
			base.DrawString(spriteFont, text, position, color);
		}

		// This one just calls another DrawString, so avoid changing
		//public new void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation,
		//	Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
		//{
		//	base.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		//}

		public new void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation,
			Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			position = position.Clone(_translation[_translationIndex], _translation[_translationIndex + 1]);
			base.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		}


		#region Private Members

		private static readonly Dictionary<String, List<Vector2>> CircleCache = new Dictionary<string, List<Vector2>>();
		//private static readonly Dictionary<String, List<Vector2>> arcCache = new Dictionary<string, List<Vector2>>();
		private static Texture2D _pixel;

		#endregion


		#region Private Methods

		private void CreateThePixel()
		{
			_pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			_pixel.SetData(new[] { Color.White });
		}


		/// <summary>
		/// Draws a list of connecting points
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// /// <param name="position">Where to position the points</param>
		/// <param name="points">The points to connect with lines</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the lines</param>
		private void DrawPoints(Vector2 position, List<Vector2> points, Color color, float thickness)
		{
			if (points.Count < 2)
				return;

			for (int i = 1; i < points.Count; i++)
				DrawLine(points[i - 1] + position, points[i] + position, color, thickness);
		}


		/// <summary>
		/// Creates a list of vectors that represents a circle
		/// </summary>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <returns>A list of vectors that, if connected, will create a circle</returns>
		private static List<Vector2> CreateCircle(double radius, int sides)
		{
			// Look for a cached version of this circle
			String circleKey = radius + "x" + sides;
			if (CircleCache.ContainsKey(circleKey))
				return CircleCache[circleKey];

			List<Vector2> vectors = new List<Vector2>();

			const double max = 2.0 * Math.PI;
			double step = max / sides;

			for (double theta = 0.0; theta < max; theta += step)
				vectors.Add(new Vector2((float)(radius * Math.Cos(theta)), (float)(radius * Math.Sin(theta))));

			// then add the first vector again so it's a complete loop
			vectors.Add(new Vector2((float)(radius * Math.Cos(0)), (float)(radius * Math.Sin(0))));

			// Cache this circle so that it can be quickly drawn next time
			CircleCache.Add(circleKey, vectors);

			return vectors;
		}


		/// <summary>
		/// Creates a list of vectors that represents an arc
		/// </summary>
		/// <param name="radius">The radius of the arc</param>
		/// <param name="sides">The number of sides to generate in the circle that this will cut out from</param>
		/// <param name="startingAngle">The starting angle of arc, 0 being to the east, increasing as you go clockwise</param>
		/// <param name="radians">The radians to draw, clockwise from the starting angle</param>
		/// <returns>A list of vectors that, if connected, will create an arc</returns>
		private static List<Vector2> CreateArc(float radius, int sides, float startingAngle, float radians)
		{
			var points = new List<Vector2>();
			points.AddRange(CreateCircle(radius, sides));
			points.RemoveAt(points.Count - 1); // remove the last point because it's a duplicate of the first

			// The circle starts at (radius, 0)
			double curAngle = 0.0;
			double anglePerSide = MathHelper.TwoPi / sides;

			// "Rotate" to the starting point
			while ((curAngle + (anglePerSide / 2.0)) < startingAngle)
			{
				curAngle += anglePerSide;

				// move the first point to the end
				points.Add(points[0]);
				points.RemoveAt(0);
			}

			// Add the first point, just in case we make a full circle
			points.Add(points[0]);

			// Now remove the points at the end of the circle to create the arc
			int sidesInArc = (int)((radians / anglePerSide) + 0.5);
			points.RemoveRange(sidesInArc + 1, points.Count - sidesInArc - 1);

			return points;
		}

		#endregion


		#region FillRectangle

		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(Rectangle rect, Color color)
		{
			if (_pixel == null)
				CreateThePixel();

			// Simply use the function already there
			var rect2 = new Rectangle(rect.X + _translation[_translationIndex], rect.Y + _translation[_translationIndex + 1], rect.Width, rect.Height);
			Draw(_pixel, rect2, color);
		}


		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="angle">The angle in radians to draw the rectangle at</param>
		public void FillRectangle(Rectangle rect, Color color, float angle)
		{
			if (_pixel == null)
				CreateThePixel();

			var rect2 = new Rectangle(rect.X + _translation[_translationIndex], rect.Y + _translation[_translationIndex + 1], rect.Width, rect.Height);
			Draw(_pixel, rect2, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
		}


		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(Vector2 location, Vector2 size, Color color)
		{
			FillRectangle(location, size, color, 0.0f);
		}


		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="angle">The angle in radians to draw the rectangle at</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(Vector2 location, Vector2 size, Color color, float angle)
		{
			if (_pixel == null)
				CreateThePixel();

			location = new Vector2(location.X + _translation[_translationIndex], location.Y + _translation[_translationIndex + 1]);
			// stretch the pixel between the two vectors
			Draw(_pixel,
				location,
				null,
				color,
				angle,
				Vector2.Zero,
				size,
				SpriteEffects.None,
				0);
		}


		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x">The X coord of the left side</param>
		/// <param name="y">The Y coord of the upper side</param>
		/// <param name="w">Width</param>
		/// <param name="h">Height</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void FillRectangle(float x, float y, float w, float h, Color color)
		{
			FillRectangle(new Vector2(x, y), new Vector2(w, h), color, 0.0f);
		}


		/// <summary>
		/// Draws a filled rectangle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x">The X coord of the left side</param>
		/// <param name="y">The Y coord of the upper side</param>
		/// <param name="w">Width</param>
		/// <param name="h">Height</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="angle">The angle of the rectangle in radians</param>
		public void FillRectangle(float x, float y, float w, float h, Color color, float angle)
		{
			FillRectangle(new Vector2(x, y), new Vector2(w, h), color, angle);
		}

		#endregion


		#region DrawRectangle

		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void DrawRectangle(Rectangle rect, Color color)
		{
			DrawRectangle(rect, color, 1.0f);
		}


		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="rect">The rectangle to draw</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="thickness">The thickness of the lines</param>
		public void DrawRectangle(Rectangle rect, Color color, float thickness)
		{

			// TODO: Handle rotations
			// TODO: Figure out the pattern for the offsets required and then handle it in the line instead of here

			DrawLine(new Vector2(rect.X, rect.Y), new Vector2(rect.Right, rect.Y), color, thickness); // top
			DrawLine(new Vector2(rect.X + 1f, rect.Y), new Vector2(rect.X + 1f, rect.Bottom + thickness), color, thickness); // left
			DrawLine(new Vector2(rect.X, rect.Bottom), new Vector2(rect.Right, rect.Bottom), color, thickness); // bottom
			DrawLine(new Vector2(rect.Right + 1f, rect.Y), new Vector2(rect.Right + 1f, rect.Bottom + thickness), color, thickness); // right
		}


		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		public void DrawRectangle(Vector2 location, Vector2 size, Color color)
		{
			DrawRectangle(new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y), color, 1.0f);
		}


		/// <summary>
		/// Draws a rectangle with the thickness provided
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="location">Where to draw</param>
		/// <param name="size">The size of the rectangle</param>
		/// <param name="color">The color to draw the rectangle in</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawRectangle(Vector2 location, Vector2 size, Color color, float thickness)
		{
			DrawRectangle(new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y), color, thickness);
		}

		#endregion


		#region DrawLine

		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x1">The X coord of the first point</param>
		/// <param name="y1">The Y coord of the first point</param>
		/// <param name="x2">The X coord of the second point</param>
		/// <param name="y2">The Y coord of the second point</param>
		/// <param name="color">The color to use</param>
		public void DrawLine(float x1, float y1, float x2, float y2, Color color)
		{
			DrawLine(new Vector2(x1, y1), new Vector2(x2, y2), color, 1.0f);
		}


		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x1">The X coord of the first point</param>
		/// <param name="y1">The Y coord of the first point</param>
		/// <param name="x2">The X coord of the second point</param>
		/// <param name="y2">The Y coord of the second point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawLine(float x1, float y1, float x2, float y2, Color color, float thickness)
		{
			DrawLine(new Vector2(x1, y1), new Vector2(x2, y2), color, thickness);
		}


		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point1">The first point</param>
		/// <param name="point2">The second point</param>
		/// <param name="color">The color to use</param>
		public void DrawLine(Vector2 point1, Vector2 point2, Color color)
		{
			DrawLine(point1, point2, color, 1.0f);
		}


		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point1">The first point</param>
		/// <param name="point2">The second point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness)
		{
			// calculate the distance between the two vectors
			var distance = Vector2.Distance(point1, point2);

			// calculate the angle between the two vectors
			var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

			DrawLine(point1, distance, angle, color, thickness);
		}


		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point">The starting point</param>
		/// <param name="length">The length of the line</param>
		/// <param name="angle">The angle of this line from the starting point in radians</param>
		/// <param name="color">The color to use</param>
		public void DrawLine(Vector2 point, float length, float angle, Color color)
		{
			DrawLine(point, length, angle, color, 1.0f);
		}


		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point">The starting point</param>
		/// <param name="length">The length of the line</param>
		/// <param name="angle">The angle of this line from the starting point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public void DrawLine(Vector2 point, float length, float angle, Color color, float thickness)
		{
			if (_pixel == null)
				CreateThePixel();

			point = new Vector2(point.X + _translation[_translationIndex], point.Y + _translation[_translationIndex + 1]);
			// stretch the pixel between the two vectors
			Draw(_pixel,
				point,
				null,
				color,
				angle,
				Vector2.Zero,
				new Vector2(length, thickness),
				SpriteEffects.None,
				0);
		}

		#endregion


		#region PutPixel

		public void PutPixel(float x, float y, Color color)
		{
			PutPixel(new Vector2(x, y), color);
		}


		public void PutPixel(Vector2 position, Color color)
		{
			if (_pixel == null)
				CreateThePixel();

			Draw(_pixel, position, color);
		}

		#endregion


		#region DrawCircle

		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		public void DrawCircle(Vector2 center, float radius, int sides, Color color)
		{
			DrawPoints(center, CreateCircle(radius, sides), color, 1.0f);
		}


		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		/// <param name="thickness">The thickness of the lines used</param>
		public void DrawCircle(Vector2 center, float radius, int sides, Color color, float thickness)
		{
			DrawPoints(center, CreateCircle(radius, sides), color, thickness);
		}


		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x">The center X of the circle</param>
		/// <param name="y">The center Y of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		public void DrawCircle(float x, float y, float radius, int sides, Color color)
		{
			DrawPoints(new Vector2(x, y), CreateCircle(radius, sides), color, 1.0f);
		}


		/// <summary>
		/// Draw a circle
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="x">The center X of the circle</param>
		/// <param name="y">The center Y of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="color">The color of the circle</param>
		/// <param name="thickness">The thickness of the lines used</param>
		public void DrawCircle(float x, float y, float radius, int sides, Color color, float thickness)
		{
			DrawPoints(new Vector2(x, y), CreateCircle(radius, sides), color, thickness);
		}

		#endregion


		#region DrawArc

		/// <summary>
		/// Draw a arc
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the arc</param>
		/// <param name="radius">The radius of the arc</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="startingAngle">The starting angle of arc, 0 being to the east, increasing as you go clockwise</param>
		/// <param name="radians">The number of radians to draw, clockwise from the starting angle</param>
		/// <param name="color">The color of the arc</param>
		public void DrawArc(Vector2 center, float radius, int sides, float startingAngle, float radians, Color color)
		{
			DrawArc(center, radius, sides, startingAngle, radians, color, 1.0f);
		}


		/// <summary>
		/// Draw a arc
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="center">The center of the arc</param>
		/// <param name="radius">The radius of the arc</param>
		/// <param name="sides">The number of sides to generate</param>
		/// <param name="startingAngle">The starting angle of arc, 0 being to the east, increasing as you go clockwise</param>
		/// <param name="radians">The number of radians to draw, clockwise from the starting angle</param>
		/// <param name="color">The color of the arc</param>
		/// <param name="thickness">The thickness of the arc</param>
		public void DrawArc(Vector2 center, float radius, int sides, float startingAngle, float radians, Color color, float thickness)
		{
			List<Vector2> arc = CreateArc(radius, sides, startingAngle, radians);
			//List<Vector2> arc = CreateArc2(radius, sides, startingAngle, degrees);
			DrawPoints(center, arc, color, thickness);
		}

		#endregion

	}
}