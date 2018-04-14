using AtarashiiMono.Framework.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AtarashiiMono.Framework.XNA
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class AmGameBase : Game
	{
		public AmGame game;
		public GraphicsDeviceManager graphics;
		public AmSpriteBatch spriteBatch;
		
		
		public AmGameBase()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			game.Initialize();

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new AmSpriteBatch(GraphicsDevice);
			game.LoadContent();
			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
			game.UnloadContent();
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			
			game.Update(gameTime);
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			// https://docs.microsoft.com/en-us/previous-versions/windows/xna/bb199041%28v%3dxnagamestudio.41%29
			spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);

			// TODO: Add your drawing code here
			game.Draw(gameTime);
			
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}