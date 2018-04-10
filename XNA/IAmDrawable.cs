using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AtarashiiMono.Framework.XNA
{
	public interface IAmDrawable // yes I am
	{
		void Draw(GameTime gameTime, AmSpriteBatch graphics, int x = 0, int y = 0);
	}
}