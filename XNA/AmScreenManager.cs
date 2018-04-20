using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtarashiiMono.Framework.Extensions;
using Microsoft.Xna.Framework;

namespace AtarashiiMono.Framework.XNA
{
	public class AmScreenManager
	{
		private enum Phase
		{
			Idle = 0,
			FadingIn = 1,
			FadingOut = 2
		}

		public SortedDictionary<string,AmScreen> Screens = new SortedDictionary<string, AmScreen>();

		public AmScreen ActiveScreen = null;
		public AmScreen FadingInScreen = null;
		private Phase phase = Phase.Idle;

		public long StartFadingOutTime = 0;
		public long StartFadingInTime = 0;
		public int FadeOutTime = 0;
		public int FadeInTime = 0;

		public AmScreenManager()
		{
			Screens.Add("Am/Blank", new AmScreen());
			SetActiveScreen("Am/Blank");
		}

		public void SetActiveScreen(string name)
		{
			ActiveScreen = Screens[name];
			ActiveScreen.Game = AmGameBase.Instance.game;
			ActiveScreen.Initialize();
			ActiveScreen.LoadContent();
		}

		public void FadeToScreen(string name, int fadeOutTime = 500, int fadeInTime = 500)
		{
			FadingInScreen = Screens[name];
			FadingInScreen.Game = AmGameBase.Instance.game;
			FadingInScreen.Initialize();

			ActiveScreen.InputIsLocked = true;
			StartFadingOutTime = DateTime.Now.TotalMillisecs();
			StartFadingInTime = DateTime.Now.TotalMillisecs() + fadeOutTime;
			FadeOutTime = fadeOutTime;
			FadeInTime = fadeInTime;
			phase = Phase.FadingOut;
		}

		public virtual void Update(GameTime gameTime)
		{
			if (phase == Phase.FadingOut)
			{
				var fadeTime = Math.Min(DateTime.Now.TotalMillisecs() - StartFadingOutTime, FadeOutTime);

				if (fadeTime == FadeOutTime)
				{
					phase = Phase.FadingIn;
					ActiveScreen.UnloadContent();
					ActiveScreen = FadingInScreen;
					FadingInScreen = null;
					ActiveScreen.LoadContent();
				}
			}

			if (phase == Phase.FadingIn)
			{
				
				var fadeTime = Math.Min(DateTime.Now.TotalMillisecs() - StartFadingInTime, FadeInTime);
				if (fadeTime == FadeInTime)
				{
					ActiveScreen.InputIsLocked = false;
					phase = Phase.Idle;
				}
			}

			ActiveScreen.Update(gameTime);
		}

		public virtual void Draw(GameTime gameTime, AmSpriteBatch graphics)
		{
			var width = AmGameBase.Instance.graphics.PreferredBackBufferWidth;
			var height = AmGameBase.Instance.graphics.PreferredBackBufferHeight;

			ActiveScreen.Draw(gameTime, graphics);

			if (phase == Phase.FadingOut)
			{
				var fadeTime = Math.Min(DateTime.Now.TotalMillisecs() - StartFadingOutTime, FadeOutTime);
				var fadePer = (float)fadeTime / (float)FadeOutTime;
				Console.Out.WriteLine("FadeOut% " + fadePer);

				graphics.FillRectangle(new Rectangle(0, 0, width, height), Color.Black * fadePer);
			}
			else if (phase == Phase.FadingIn)
			{
				var fadeTime = Math.Min(DateTime.Now.TotalMillisecs() - StartFadingInTime, FadeInTime);
				var fadePer = (float)fadeTime / (float)FadeInTime;
				Console.Out.WriteLine("FadeIn% " + (1.0f - fadePer));
				
				graphics.FillRectangle(new Rectangle(0, 0, width, height), Color.Black * (1.0f - fadePer));
			}
		}
	}
}
