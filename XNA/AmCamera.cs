using Microsoft.Xna.Framework;

namespace AtarashiiMono.Framework.XNA
{
	public abstract class AmCamera : IAmDrawable
	{
		public AmEntity Target = null;
		public Rectangle Bounds = new Rectangle(0, 0, 640, 480);

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime, AmSpriteBatch graphics, int x = 0, int y = 0);

		public void StartCamera(AmSpriteBatch graphics)
		{
			graphics.PushMatrix();
		}

		public void StopCamera(AmSpriteBatch graphics)
		{
			graphics.PopMatrix();
		}

		
	}
}