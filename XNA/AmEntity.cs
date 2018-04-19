using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AtarashiiMono.Framework.XNA
{
	public class AmEntity
	{
		public Vector2 Location;
		public SortedDictionary<string,Vector2> HotSpots = new SortedDictionary<string, Vector2>();

		public AmEntity()
		{
			HotSpots["Am/Center"] = new Vector2(0, 0);
		}

		public Vector2 GetHotSpotLocation(string hotSpotName)
		{
			return Location + HotSpots[hotSpotName];
		}
	}
}
