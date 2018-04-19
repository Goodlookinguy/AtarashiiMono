using Microsoft.Xna.Framework;

namespace AtarashiiMono.Framework.XNA
{
	public class AmFollowCamera : AmCamera
	{
		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime, AmSpriteBatch graphics, int x = 0, int y = 0)
		{
			
			var targetLocation = Target.GetHotSpotLocation("Am/Center");
			var screenWidth = AmGameBase.Instance.graphics.PreferredBackBufferWidth;
			var screenHeight = AmGameBase.Instance.graphics.PreferredBackBufferHeight;

			var tpos = GetWithinBounds((int)targetLocation.X - screenWidth / 2, (int)targetLocation.Y - screenHeight / 2);

			graphics.Translate((int)-tpos.X, (int)-tpos.Y);
		}

		public Vector2 GetWithinBounds(Vector2 pos)
		{
			return GetWithinBounds((int)pos.X, (int)pos.Y);
		}

		public Vector2 GetWithinBounds(int x, int y)
		{
			var screenWidth = AmGameBase.Instance.graphics.PreferredBackBufferWidth;
			var screenHeight = AmGameBase.Instance.graphics.PreferredBackBufferHeight;

			if (x < Bounds.X) x = Bounds.X;
			if (x + screenWidth > (Bounds.X + Bounds.Width)) x = Bounds.X + Bounds.Width - screenWidth;
			if (y < Bounds.Y) y = Bounds.Y;
			if (y + screenHeight > (Bounds.Y + Bounds.Height)) y = Bounds.Y + Bounds.Height - screenHeight;
			return new Vector2(x, y);
		}
	}
}