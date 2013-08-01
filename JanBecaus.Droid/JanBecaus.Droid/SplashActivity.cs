using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace JanBecaus.Droid
{
	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, 
	          NoHistory = true,
	          ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class SplashActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Thread.Sleep (1500); 
			StartActivity (typeof(MainActivity));
		}
	}
}

