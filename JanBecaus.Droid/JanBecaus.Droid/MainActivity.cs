using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Media;

namespace JanBecaus.Droid
{
	[Activity (Label = "JanBecaus.Droid", 
	           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		public static readonly int AmstelGoldRace;
		private AudioManager _audio;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SoundProvider provider = SoundProvider.Instance (this);

			SetTheme (Android.Resource.Style.ThemeLightNoTitleBar);
			SetContentView (Resource.Layout.Main);

			_audio = (AudioManager)GetSystemService (Context.AudioService);


			LinearLayout ll = FindViewById<LinearLayout> (Resource.Id.llRoot);
			foreach (string sound in provider.Sounds) {
				Button button = new Button (this);
				button.Text = sound;
				LinearLayout.LayoutParams btnParams = new LinearLayout.LayoutParams (
					LinearLayout.LayoutParams.FillParent, LinearLayout.LayoutParams.WrapContent);
				btnParams.SetMargins (20, 20, 20, 0);

				button.SetBackgroundResource (Resource.Drawable.button);
				Color color = new Color (0xff, 0xff, 0xff, 0xff);
				button.SetTextColor (color);

				button.LayoutParameters = btnParams;
				button.Click += delegate {
					provider.PlaySound (sound);
				};
				ll.AddView (button);
			}
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


