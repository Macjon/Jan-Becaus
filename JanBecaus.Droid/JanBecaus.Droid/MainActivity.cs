using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Media;
using System.Collections.Generic;

namespace JanBecaus.Droid
{
	[Activity (Label = "JanBecaus.Droid", 
	           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		public static readonly int AmstelGoldRace;
		//private AudioManager _audio;
		private SoundProvider _provider;
		private List<Button> _buttons;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			_provider = new SoundProvider (this);
			_buttons = new List<Button> ();

			SetTheme (Android.Resource.Style.ThemeLightNoTitleBar);
			SetContentView (Resource.Layout.Main);

			//_audio = (AudioManager)GetSystemService (Context.AudioService);


			LinearLayout ll = FindViewById<LinearLayout> (Resource.Id.llRoot);
			foreach (string sound in _provider.Sounds) {
				Button button = new Button (this);
				button.Text = sound;
				LinearLayout.LayoutParams btnParams = new LinearLayout.LayoutParams (
					LinearLayout.LayoutParams.FillParent, LinearLayout.LayoutParams.WrapContent);
				btnParams.SetMargins (20, 20, 20, 0);
				button.SetBackgroundResource (Resource.Drawable.button);
				Color color = new Color (0xff, 0xff, 0xff, 0xff);
				button.SetTextColor (color);
				button.Tag = sound;
				button.LayoutParameters = btnParams;
				_buttons.Add (button);
				ll.AddView (button);
			}
		}

		private void PlaySound (object sender = null, EventArgs e = null)
		{
			Button button = (Button)sender;
			string toPlay = (string)button.Tag;
			_provider.PlaySound (toPlay);
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			foreach (Button button in _buttons) {
				button.Click += PlaySound;
			}
		}

		protected override void OnPause ()
		{
			base.OnPause ();
			foreach (Button button in _buttons) {
				button.Click -= PlaySound;
			}
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			_provider.Release ();
		}
		/*public override bool OnKeyDown (int keyCode, KeyEvent e)
		{
			switch (keyCode) {
			case KeyEvent.:
				_audio.adjustStreamVolume (AudioManager.STREAM_MUSIC,
				                         AudioManager.ADJUST_RAISE, AudioManager.FLAG_SHOW_UI);
				return true;
			case KeyEvent.KEYCODE_VOLUME_DOWN:
				audio.adjustStreamVolume (AudioManager.STREAM_MUSIC,
				                         AudioManager.ADJUST_LOWER, AudioManager.FLAG_SHOW_UI);
				return true;
			default:
				return false;
			}
		}*/
	}
}


