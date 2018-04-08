namespace AtarashiiMono.Framework.XNA
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.Xna.Framework.Graphics;

	public class AmImage2D
	{
		public readonly Texture2D Texture;
		private int w = -1, h = -1;

		/// <summary>
		/// Set image to entire Texture2D
		/// </summary>
		/// <param name="texture2D"></param>
		public AmImage2D(Texture2D texture2D)
		{
			Texture = texture2D;
			Width = texture2D.Width;
			Height = texture2D.Height;
		}

		/// <summary>
		/// Set image to subsection of Texture2D
		/// </summary>
		/// <param name="texture2D"></param>
		/// <param name="subX"></param>
		/// <param name="subY"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		public AmImage2D(Texture2D texture2D, int subX, int subY, int w, int h)
		{
			Texture = texture2D;
			SubX = subX;
			SubY = subY;
			Width = w;
			Height = h;
		}

		public int SubX { get; set; } = 0;
		public int SubY { get; set; } = 0;

		public int Width
		{
			get => w == -1 ? Texture.Width : w;
			set => w = value;
		}

		public int Height
		{
			get => h == -1 ? Texture.Height : h;
			set => h = value;
		}
	}
}
