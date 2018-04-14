using System;
using Microsoft.Xna.Framework.Graphics;

namespace AtarashiiMono.Framework.XNA
{
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
}
