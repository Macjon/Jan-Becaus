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
	public class Sound
	{
		public Sound (string name, int resource)
		{
			Name = name;
			Resource = resource;
		}

		public string Name { get; set; }

		public int Resource { get; set; }
	}

	public class SoundProvider
	{
		public static string AmstelGoldRace = "Amstel Gold Race";
		public static string BeeGees = "BeeGees";
		public static string BlackEyedPeas = "Black Eyed Peas";
		public static string Ciudadjuarez = "Ciudadjuarez";
		public static string doscervezas = "Dos Cervezas";
		public static string dowjones = "Dow Jones";
		public static string DrieKwartier = "Drie Kwartier";
		public static string europeanmotorshow = "European Motorshow";
		public static string eyjafjallajokull = "Eyjafjallajokull";
		public static string gameofshadows = "Game Of Shadows";
		public static string goldenglobes = "Golden Globes";
		public static string iowa = "Iowa";
		public static string JudeLaw = "Jude Law";
		public static string Kattepis = "Kattepis";
		public static string markwebber = "Mark Webber";
		public static string Milow = "Milow";
		public static string NorahJones = "Norah Jones";
		public static string Obama = "Obama";
		public static string PartOfTheJob = "Part Of The Job";
		public static string Pussy = "Pussy";
		public static string RauweBlues = "Rauwe Blues";
		public static string RockNRoll = "Rock'n'Roll";
		public static string Score = "Score";
		public static string sherlockholmes = "Sherlock Holmes";
		public static string Sighnomore = "Sigh No More";
		public static string tomorrowland = "Tomorrowland";
		public static string TonyBlair = "Tony Blair";
		public static string UsainBolt = "Usain Bolt";
		public static string VayaCondios = "Vayacondios";
		public static string WallStreet = "Wall Street";
		Dictionary<string, int> _sounds;
		private static SoundPool _soundPool;
		private static SoundProvider _instance;
		private Context _ctx;

		public static SoundProvider Instance (Context ctx)
		{
			if (_instance == null) {
				_instance = new SoundProvider (ctx);
			}
			return _instance;
		}

		public SoundProvider (Context ctx)
		{
			_soundPool = new SoundPool (3, Android.Media.Stream.Music, 0);
			_sounds = new Dictionary<string, int> ();
			_ctx = ctx;

			// Add all sounds
			_sounds.Add (AmstelGoldRace, _soundPool.Load (ctx, Resource.Raw.amstelgoldrace, 1));
			_sounds.Add (BeeGees, _soundPool.Load (ctx, Resource.Raw.beegees, 1));
			_sounds.Add (BlackEyedPeas, _soundPool.Load (ctx, Resource.Raw.blackeyedpeas, 1));
			_sounds.Add (Ciudadjuarez, _soundPool.Load (ctx, Resource.Raw.ciudadjuarez, 1));
			_sounds.Add (doscervezas, _soundPool.Load (ctx, Resource.Raw.doscervezas, 1));
			_sounds.Add (dowjones, _soundPool.Load (ctx, Resource.Raw.dowjones, 1));
			_sounds.Add (DrieKwartier, _soundPool.Load (ctx, Resource.Raw.driekwartier, 1));
			_sounds.Add (europeanmotorshow, _soundPool.Load (ctx, Resource.Raw.europeanmotorshow, 1));
			_sounds.Add (eyjafjallajokull, _soundPool.Load (ctx, Resource.Raw.eyjafjallajokull, 1));
			_sounds.Add (gameofshadows, _soundPool.Load (ctx, Resource.Raw.gameofshadows, 1));
			_sounds.Add (goldenglobes, _soundPool.Load (ctx, Resource.Raw.goldenglobes, 1));
			_sounds.Add (iowa, _soundPool.Load (ctx, Resource.Raw.iowa, 1));
			_sounds.Add (JudeLaw, _soundPool.Load (ctx, Resource.Raw.judelaw, 1));
			_sounds.Add (Kattepis, _soundPool.Load (ctx, Resource.Raw.kattepis, 1));
			_sounds.Add (markwebber, _soundPool.Load (ctx, Resource.Raw.markwebber, 1));
			_sounds.Add (Milow, _soundPool.Load (ctx, Resource.Raw.milow, 1));
			_sounds.Add (NorahJones, _soundPool.Load (ctx, Resource.Raw.norahjones, 1));
			_sounds.Add (Obama, _soundPool.Load (ctx, Resource.Raw.obama, 1));
			_sounds.Add (PartOfTheJob, _soundPool.Load (ctx, Resource.Raw.partofthejob, 1));
			_sounds.Add (Pussy, _soundPool.Load (ctx, Resource.Raw.pussy, 1));
			_sounds.Add (RauweBlues, _soundPool.Load (ctx, Resource.Raw.rauweblues, 1));
			_sounds.Add (RockNRoll, _soundPool.Load (ctx, Resource.Raw.rocknroll, 1));
			_sounds.Add (Score, _soundPool.Load (ctx, Resource.Raw.score, 1));
			_sounds.Add (sherlockholmes, _soundPool.Load (ctx, Resource.Raw.sherlockholmes, 1));
			_sounds.Add (Sighnomore, _soundPool.Load (ctx, Resource.Raw.sighnomore, 1));
			_sounds.Add (tomorrowland, _soundPool.Load (ctx, Resource.Raw.tomorrowland, 1));
			_sounds.Add (TonyBlair, _soundPool.Load (ctx, Resource.Raw.tonyblair, 1));
			_sounds.Add (UsainBolt, _soundPool.Load (ctx, Resource.Raw.usainbolt, 1));
			_sounds.Add (VayaCondios, _soundPool.Load (ctx, Resource.Raw.vayacondios, 1));
			_sounds.Add (WallStreet, _soundPool.Load (ctx, Resource.Raw.wallstreet, 1));
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

