using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.AVFoundation;
using MonoTouch.AudioToolbox;
using System.IO;

namespace JanBecaus
{
	public partial class JanBecausViewController : UIViewController
	{
		private SystemSound Sound;

		List<string> soundList = new List<string> ();
		List<string> titles = new List<string> {
			"Amstel Gold Race",
			"BeeGees",
			"Black Eyed Peas",
			"Ciudadjuarez",
			"Dos Cervezas",
			"Dow Jones",
			"Drie Kwartier",
			"European Motorshow",
			"Eyjafjallajokull",
			"Game Of Shadows",
			"Golden Globes",
			"Iowa",
			"Jude Law",
			"Kattepis",
			"Mark Webber",
			"Milow",
			"Norah Jones",
			"Obama",
			"Part Of The Job",
			"Pussy",
			"Rauwe Blues",
			"Rock'n'Roll",
			"Score",
			"Sherlock Holmes",
			"Sigh No More",
			"Tomorrowland",
			"Tony Blair",
			"Usain Bolt",
			"Vayacondios",
			"Wall Street"
		};

		public JanBecausViewController (IntPtr handle) : base (handle)
		{
		}

		#region View lifecycle
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//enable audio
			AudioSession.Initialize();
		
			var i = 0;
			float bottom = 0;
			var rootPath = String.Format ("{0}/sounds", NSBundle.MainBundle.BundlePath);
			foreach (var file in Directory.GetFiles (rootPath, "*.mp3")) {
				var subStringIndex = rootPath.Length +1;
				var id = Convert.ToInt16 (file.Substring (subStringIndex, 2));
				soundList.Add (file.Substring (NSBundle.MainBundle.BundlePath.Length + 1));

				var button = new UIButton (new RectangleF (20, bottom, 280, 44));
				button.Tag = i;
				button.SetTitle (titles [id -1], UIControlState.Normal);
				button.Font = UIFont.FromName ("Futura-CondensedMedium", 26);
				button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
				button.TitleEdgeInsets = new UIEdgeInsets (0, 15, 0, 0);
				button.SetBackgroundImage (Utils.UIColorFromHexString ("#7AC143").ImageFromColor (), UIControlState.Normal);
				button.SetBackgroundImage (Utils.UIColorFromHexString ("#579231").ImageFromColor (), UIControlState.Highlighted);
				button.TouchUpInside += ButtonTouched;

				bottom = button.Frame.Bottom + 20;

				ScrollView.Add (button);

				i++;
			}

			ScrollView.ContentSize = new SizeF (320, bottom);
		}

		#endregion
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		void ButtonTouched (object sender, EventArgs e)
		{
			var button = sender as UIButton;
			if (button.Tag >= soundList.Count)
				return;

			Sound = SystemSound.FromFile(soundList [button.Tag]);

			Sound.PlaySystemSound ();
		}
	}
}

