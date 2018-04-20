using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AtarashiiMono.Framework.XNA
{
	public partial class AmScreen
	{
		public AmGame Game;
		public bool InputIsLocked = false;

		public ContentManager Content => Game.Content;
		public GameWindow Window => Game.Window;
		public AmSpriteBatch Graphics => Game.Graphics;

		public virtual void Initialize()
		{

		}

		public virtual void LoadContent()
		{

		}

		public virtual void UnloadContent()
		{

		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw(GameTime gameTime, AmSpriteBatch graphics)
		{

		}
	}
}