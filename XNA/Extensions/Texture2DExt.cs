using AtarashiiMono.Framework.XNA;

namespace AtarashiiMono.Framework.XNA.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.Xna.Framework.Graphics;

	public static class Texture2DExt
	{
		public static AmImage2D GetImage2D(this Texture2D texture2D)
		{
			return new AmImage2D(texture2D);
		}

		public static AmImage2D GetImage2D(this Texture2D texture2D, int subX, int subY, int w, int h)
		{
			return new AmImage2D(texture2D, subX, subY, w, h);
		}

		public static AmImage2D[] GetTilesheet(this Texture2D texture2D, int tileWidth, int tileHeight)
		{
			var xTiles = texture2D.Width / tileWidth;
			var yTiles = texture2D.Height / tileHeight;
			var totalTiles = xTiles * yTiles;

			var sheet = new AmImage2D[totalTiles];
			for (int tile = 0; tile < totalTiles; ++tile)
			{
				var x = tile % xTiles;
				var y = tile / xTiles;

				sheet[tile] = texture2D.GetImage2D(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
			}

			return sheet;
		}
	}
}
