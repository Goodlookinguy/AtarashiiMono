using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AtarashiiMono.Framework.XNA.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AtarashiiMono.Framework.XNA
{
	public abstract class AmTilesheet
	{
		public readonly Texture2D texture;

		protected AmTilesheet(Texture2D texture)
		{
			this.texture = texture;
		}

		public abstract AmImage2D GetImage(int index);
	}

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

	// TODO: Setup animation before implementing the animated tilesheet bit
	public class AmAnimatedTilesheet : AmTilesheet
	{
		public AmAnimatedTilesheet(Texture2D texture) : base(texture)
		{

		}

		public override AmImage2D GetImage(int index)
		{
			throw new NotImplementedException();
		}
	}

	public class AmTilemap : IAmDrawable
	{
		public List<AmTilesheet> tilesheets = new List<AmTilesheet>();
		public int[,] Tiles; // same as using a 1D array, but with the benefit of easy 2D access
		// going to store both the tilesheet and the id in an int
		//       tilesheet  tile id
		// tiles = [0xFF]  [0xFFFFFF] 

		public int TileWidth;
		public int TileHeight;
		public int GridWidth;
		public int GridHeight;
		public Vector2 Location = new Vector2(0, 0);

		public AmTilemap(int width, int height, int tileWidth, int tileHeight)
		{
			Tiles = new int[width,height];
			GridWidth = width;
			GridHeight = height;
			TileWidth = tileWidth;
			TileHeight = tileHeight;
		}

		public void SetTile(int x, int y, int tilesheetIndex, int tileIndex)
		{
			Tiles[x, y] = (tilesheetIndex << 24) | (tileIndex & 0x00FFFFFF);
		}

		//TODO: Later, maybe, bother to check if the tile is in bounds before drawing
		public void Draw(GameTime gameTime, AmSpriteBatch graphics, int x = 0, int y = 0)
		{
			for (int i = 0; i < Tiles.Length; ++i)
			{
				int gx = i % GridWidth;
				int gy = i / GridWidth;
				int rx = gx * TileWidth + x + (int)Location.X;
				int ry = gy * TileHeight + y + (int)Location.Y;

				int tileData = Tiles[gx,gy];
				int tilesheetId = (tileData >> 24) & 0xFF;
				int tileId = tileData & 0xFFFFFF;
				AmImage2D curTile = tilesheets[tilesheetId].GetImage(tileId);

				graphics.DrawImage(curTile, rx, ry);
			}
		}

		//TODO: Add layer-by-layer drawing for top-down type angle drawing
	}
}
