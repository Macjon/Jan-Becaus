using System;
using MonoTouch.UIKit;

namespace JanBecaus
{
	public class Utils
	{
		public static UIColor UIColorFromHexString (string hex)
		{
			int red = 0, green = 0, blue = 0, alpha = 0;

			if (hex != null && hex.Length == 7) {
				red = Convert.ToInt32 (hex.Substring (1, 2), 16);
				green = Convert.ToInt32 (hex.Substring (3, 2), 16);
				blue = Convert.ToInt32 (hex.Substring (5, 2), 16);

				return UIColor.FromRGB (red, green, blue);
			}

			if (hex == null || hex.Length != 9) {
				Console.WriteLine ("Probably found a broken hex color string: '{0}', desired format: '#RRGGBBAA'.", hex);
			} else {
				red = Convert.ToInt32 (hex.Substring (1, 2), 16);
				green = Convert.ToInt32 (hex.Substring (3, 2), 16);
				blue = Convert.ToInt32 (hex.Substring (5, 2), 16);
				alpha = Convert.ToInt32 (hex.Substring (7, 2), 16);
			}

			return UIColor.FromRGBA (red, green, blue, alpha);
		}
	}
}

