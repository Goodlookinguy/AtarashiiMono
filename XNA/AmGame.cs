using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AtarashiiMono.Framework.XNA
{
	public class AmGame : System.IDisposable
	{
		private AmGameBase gameBase;

		public ContentManager Content => gameBase.Content;

		[System.CLSCompliant(false)]
		public GameWindow Window => gameBase.Window;

		public GraphicsDeviceManager GraphicsManager => gameBase.graphics;
		
		public AmSpriteBatch Graphics => gameBase.spriteBatch;

		public void Run()
		{
			gameBase = new AmGameBase();
			gameBase.game = this;
			gameBase.Run();
		}

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

		public virtual void Draw(GameTime gameTime)
		{

		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Exit()
		{
			gameBase.Exit();
		}

		public void Dispose()
		{
			gameBase.Dispose();
		}
	}
}