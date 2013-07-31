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

		public JanBecausViewController (IntPtr handle) : base (handle)
		{
		}

		#region View lifecycle
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//enable audio
			AudioSession.Initialize();
		
			foreach (var file in Directory.GetFiles (NSBundle.MainBundle.BundlePath, "*.mp3")) {
				soundList.Add (file.Substring (NSBundle.MainBundle.BundlePath.Length + 1));
			}
		}

		#endregion
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void ButtonTouched (MonoTouch.UIKit.UIButton sender)
		{
			if (sender.Tag >= soundList.Count)
				return;

			Sound = SystemSound.FromFile(soundList [sender.Tag]);

			Sound.PlaySystemSound ();
		}
	}
}

