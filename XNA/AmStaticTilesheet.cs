using AtarashiiMono.Framework.XNA.Extensions;
using Microsoft.Xna.Framework.Graphics;

namespace AtarashiiMono.Framework.XNA
{
	public class AmStaticTilesheet : AmTilesheet
	{
		private AmImage2D[] tiles;

		public AmStaticTilesheet(Texture2D texture, int tileWidth, int tileHeight) : base(texture)
		{
			tiles = texture.GetTilesheet(tileWidth, tileHeight);
		}

		public override AmImage2D GetImage(int index)
		{
			return tiles[index];
		}
	}
}
