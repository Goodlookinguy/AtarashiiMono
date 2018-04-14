using Microsoft.Xna.Framework;

namespace AtarashiiMono.Framework.XNA
{
	public class AmTileLayer : IAmDrawable
	{
		public int[,] Tiles; // same as using a 1D array, but with the benefit of easy 2D access
		private AmTilemap tilemap;

		public AmTileLayer(AmTilemap tilemap)
		{
			this.tilemap = tilemap;
			Tiles = new int[tilemap.GridWidth, tilemap.GridHeight];
		}

		public void SetTile(int x, int y, int tilesheetIndex, int tileIndex)
		{
			Tiles[x, y] = (tilesheetIndex << 24) | (tileIndex & 0x00FFFFFF);
		}

		public void Draw(GameTime gameTime, AmSpriteBatch graphics, int x = 0, int y = 0)
		{
			for (int i = 0; i < Tiles.Length; ++i)
			{
				int gx = i % tilemap.GridWidth;
				int gy = i / tilemap.GridWidth;
				int rx = gx * tilemap.TileWidth + x;
				int ry = gy * tilemap.TileHeight + y;

				int tileData = Tiles[gx, gy];
				int tilesheetId = (tileData >> 24) & 0xFF;
				int tileId = tileData & 0xFFFFFF;

				if (tilesheetId == 127)
					continue;

				AmImage2D curTile = tilemap.tilesheets[tilesheetId].GetImage(tileId);

				graphics.DrawImage(curTile, rx, ry);
			}
		}
	}
}
