using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
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
}
