using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AtarashiiMono.Framework.XNA
{
	public class AmTilemap : IAmDrawable
	{
		public SortedDictionary<int,AmTilesheet> tilesheets = new SortedDictionary<int,AmTilesheet>();
		//public int[,] Tiles;
		// going to store both the tilesheet and the id in an int
		//       tilesheet  tile id
		// tiles = [0xFF]  [0xFFFFFF] 

		public int TileWidth;
		public int TileHeight;
		public int GridWidth;
		public int GridHeight;
		public Vector2 Location = new Vector2(0, 0);
		public List<AmTileLayer> Layers = new List<AmTileLayer>();

		public AmTilemap(string path, ContentManager content)
		{
			int tileX = 0;
			int tileY = 0;
			bool init = false;
			int layer = 0;

			using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
			{
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine()?.Trim();

					if (line == null)
						break;

					if (line == "" || line.StartsWith("#"))
						continue;

					if (line.StartsWith(">"))
					{
						string[] data = line.Substring(1).Split(',');
						var tilesheetId = Convert.ToInt32(data[0].Trim());
						var tilesheetType = data[1].Trim();
						var tilesheetPath = data[2].Trim();

						var tilesheetTex = content.Load<Texture2D>(tilesheetPath);

						if (tilesheetType == "static")
						{
							var tilesheetSize = data[3].Split('x');
							var sizeX = Convert.ToInt32(tilesheetSize[0].Trim());
							var sizeY = Convert.ToInt32(tilesheetSize[1].Trim());

							var tilesheet = new AmStaticTilesheet(tilesheetTex, sizeX, sizeY);
							tilesheets[tilesheetId] = tilesheet;
						}

						continue;
					}

					if (line.StartsWith("!layer"))
					{
						++layer;
						tileX = 0;
						tileY = 0;
						Layers.Add(new AmTileLayer(this));
						continue;
					}

					if (!init)
					{
						var data = line.Split(',');
						var grid = data[0].Split('x');
						var size = data[1].Split('x');

						GridWidth = Convert.ToInt32(grid[0].Trim());
						GridHeight = Convert.ToInt32(grid[1].Trim());
						TileWidth = Convert.ToInt32(size[0].Trim());
						TileHeight = Convert.ToInt32(size[1].Trim());

						Layers.Add(new AmTileLayer(this));
						
						init = true;
					}
					else
					{
						string[] indexes = line.Split(',');
						for (int i = 0; i < indexes.Length; ++i)
						{
							string[] data = indexes[i].Split(':');
							var tilesheetIndex = Convert.ToInt32(data[0].Trim());
							var tileIndex = Convert.ToInt32(data[1].Trim());

							SetTile(tileX++, tileY, tilesheetIndex, tileIndex, layer);
						}

						tileX = 0;
						++tileY;
					}
				}
			}
		}

		public AmTilemap(int width, int height, int tileWidth, int tileHeight)
		{
			var layer = new AmTileLayer(this);
			layer.Tiles = new int[width,height];
			GridWidth = width;
			GridHeight = height;
			TileWidth = tileWidth;
			TileHeight = tileHeight;
		}

		public void SetTile(int x, int y, int tilesheetIndex, int tileIndex, int layer = 0)
		{
			Layers[layer].SetTile(x, y, tilesheetIndex, tileIndex);
		}

		//TODO: Later, maybe, bother to check if the tile is in bounds before drawing
		public void Draw(GameTime gameTime, AmSpriteBatch graphics, int x = 0, int y = 0)
		{
			x += (int)Location.X;
			y += (int)Location.Y;
			foreach (var layer in Layers)
			{
				layer.Draw(gameTime, graphics, x, y);
			}
		}

		//TODO: Add layer-by-layer drawing for top-down type angle drawing
	}
}
