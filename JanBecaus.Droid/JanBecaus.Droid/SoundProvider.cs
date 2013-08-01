using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace JanBecaus.Droid
{
	public class SoundProvider
	{
		public static string AmstelGoldRace = "Amstel Gold Race";
		public static string BeeGees = "BeeGees";
		public static string BlackEyedPeas = "Black Eyed Peas";
		public static string Ciudadjuarez = "Ciudadjuarez";
		public static string DosCervezas = "Dos Cervezas";
		public static string DowJones = "Dow Jones";
		public static string DrieKwartier = "Drie Kwartier";
		public static string EuropeanMotorshow = "European Motorshow";
		public static string Eyjafjallajokull = "Eyjafjallajokull";
		public static string GameOfShadows = "Game Of Shadows";
		public static string GoldenGlobes = "Golden Globes";
		public static string Iowa = "Iowa";
		public static string JudeLaw = "Jude Law";
		public static string Kattepis = "Kattepis";
		public static string MarkWebber = "Mark Webber";
		public static string Milow = "Milow";
		public static string NorahJones = "Norah Jones";
		public static string Obama = "Obama";
		public static string PartOfTheJob = "Part Of The Job";
		public static string Pussy = "Pussy";
		public static string RauweBlues = "Rauwe Blues";
		public static string RockNRoll = "Rock'n'Roll";
		public static string Score = "Score";
		public static string SherlockHolmes = "Sherlock Holmes";
		public static string Sighnomore = "Sigh No More";
		public static string Tomorrowland = "Tomorrowland";
		public static string TonyBlair = "Tony Blair";
		public static string UsainBolt = "Usain Bolt";
		public static string VayaCondios = "Vayacondios";
		public static string WallStreet = "Wall Street";
		private Dictionary<string, int> _sounds;
		private SoundPool _soundPool;
		private Context _ctx;

		public SoundProvider (Context ctx)
		{
			_soundPool = new SoundPool (3, Android.Media.Stream.Music, 0);
			_sounds = new Dictionary<string, int> ();
			_ctx = ctx;

			// Add all sounds
			_sounds.Add (AmstelGoldRace, _soundPool.Load (_ctx, Resource.Raw.amstelgoldrace, 1));
			_sounds.Add (BeeGees, _soundPool.Load (_ctx, Resource.Raw.beegees, 1));
			_sounds.Add (BlackEyedPeas, _soundPool.Load (_ctx, Resource.Raw.blackeyedpeas, 1));
			_sounds.Add (Ciudadjuarez, _soundPool.Load (_ctx, Resource.Raw.ciudadjuarez, 1));
			_sounds.Add (DosCervezas, _soundPool.Load (_ctx, Resource.Raw.doscervezas, 1));
			_sounds.Add (DowJones, _soundPool.Load (_ctx, Resource.Raw.dowjones, 1));
			_sounds.Add (DrieKwartier, _soundPool.Load (_ctx, Resource.Raw.driekwartier, 1));
			_sounds.Add (EuropeanMotorshow, _soundPool.Load (_ctx, Resource.Raw.europeanmotorshow, 1));
			_sounds.Add (Eyjafjallajokull, _soundPool.Load (_ctx, Resource.Raw.eyjafjallajokull, 1));
			_sounds.Add (GameOfShadows, _soundPool.Load (_ctx, Resource.Raw.gameofshadows, 1));
			_sounds.Add (GoldenGlobes, _soundPool.Load (_ctx, Resource.Raw.goldenglobes, 1));
			_sounds.Add (Iowa, _soundPool.Load (_ctx, Resource.Raw.iowa, 1));
			_sounds.Add (JudeLaw, _soundPool.Load (_ctx, Resource.Raw.judelaw, 1));
			_sounds.Add (Kattepis, _soundPool.Load (_ctx, Resource.Raw.kattepis, 1));
			_sounds.Add (MarkWebber, _soundPool.Load (_ctx, Resource.Raw.markwebber, 1));
			_sounds.Add (Milow, _soundPool.Load (_ctx, Resource.Raw.milow, 1));
			_sounds.Add (NorahJones, _soundPool.Load (_ctx, Resource.Raw.norahjones, 1));
			_sounds.Add (Obama, _soundPool.Load (_ctx, Resource.Raw.obama, 1));
			_sounds.Add (PartOfTheJob, _soundPool.Load (_ctx, Resource.Raw.partofthejob, 1));
			_sounds.Add (Pussy, _soundPool.Load (_ctx, Resource.Raw.pussy, 1));
			_sounds.Add (RauweBlues, _soundPool.Load (_ctx, Resource.Raw.rauweblues, 1));
			_sounds.Add (RockNRoll, _soundPool.Load (_ctx, Resource.Raw.rocknroll, 1));
			_sounds.Add (Score, _soundPool.Load (_ctx, Resource.Raw.score, 1));
			_sounds.Add (SherlockHolmes, _soundPool.Load (_ctx, Resource.Raw.sherlockholmes, 1));
			_sounds.Add (Sighnomore, _soundPool.Load (_ctx, Resource.Raw.sighnomore, 1));
			_sounds.Add (Tomorrowland, _soundPool.Load (_ctx, Resource.Raw.tomorrowland, 1));
			_sounds.Add (TonyBlair, _soundPool.Load (_ctx, Resource.Raw.tonyblair, 1));
			_sounds.Add (UsainBolt, _soundPool.Load (_ctx, Resource.Raw.usainbolt, 1));
			_sounds.Add (VayaCondios, _soundPool.Load (_ctx, Resource.Raw.vayacondios, 1));
			_sounds.Add (WallStreet, _soundPool.Load (_ctx, Resource.Raw.wallstreet, 1));
		}

		public void Release ()
		{
			_soundPool.Release ();
		}

		public List<string> Sounds { 
			get { return new List<string> (_sounds.Keys); }
		}

		public void PlaySound (string sound)
		{
			AudioManager audio = (AudioManager)_ctx.GetSystemService (Context.AudioService);
			int currentVolume = audio.GetStreamVolume (Android.Media.Stream.System);
			Console.WriteLine (currentVolume);

			float volume = 0.7f;
			// play sound with same right and left volume, with a priority of 1,
			// zero repeats (i.e play once), and a playback rate of 1f
			_soundPool.Play (_sounds [sound], volume, volume, 1, 0, 1f);
		}
	}
}

