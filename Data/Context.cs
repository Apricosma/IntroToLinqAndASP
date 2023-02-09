using IntroToLinqAndASP.Models;
using System.Runtime.CompilerServices;

namespace IntroToLinqAndASP.Data
{
	public class Context
	{
		// this is a colossal mess but refactoring it would take too much time 
		public static HashSet<Actor> Actors= new HashSet<Actor>();
		public static HashSet<Movie> Movies= new HashSet<Movie>();
		public static List<Rating> Ratings = new List<Rating>();
		public static HashSet<User> Users = new HashSet<User>();

		private static int _actorIdCounter = 0;
		private static int _movieIdCounter = 1000;
		private static int _userIdCounter = 100000;

		static Context()
		{
			// first movie
			Actor jenny = new Actor(_actorIdCounter++, "Jenny Monroe", 1539243.23);
			Actors.Add(jenny);
			Movie avgRomcom = new Movie(_movieIdCounter++, "An average romcom", "Just the average romcom where " +
				"both characters move away at the end but then meet again a few years later", 10000000, "Romcom", 1993);

			avgRomcom.Actors.Add(jenny);
			Movies.Add(avgRomcom);
			jenny.Movies.Add(avgRomcom);

			List<double> romcomRatings = new List<double> { 6.4, 5.5, 7.3, 7.6 };
			Rating avgRomcomRatings = new Rating(romcomRatings);
			avgRomcomRatings.Movie = avgRomcom;
			avgRomcom.Ratings.Add(avgRomcomRatings);
			Ratings.Add(avgRomcomRatings);

			// second movie
			Actor jotaro = new Actor(_actorIdCounter++, "Jotaro Kujo", 2194234.99);
			Actor jonathan = new Actor(_actorIdCounter++, "Jonathan Joestar", 372183.45);
			Actors.Add(jotaro);
			Actors.Add(jonathan);
			Movie stardustCrusaders = new Movie(_movieIdCounter++, "Stardust Crusaders", "From 1988 to 1989, " +
				"the story follows Jotaro Kujo and his friends as they journey from Tokyo to Cairo to save " +
				"his mother's life by defeating his family's resurrected archenemy, DIO", 85000000, "Action", 2012);

			stardustCrusaders.Actors.Add(jotaro);
			stardustCrusaders.Actors.Add(jonathan);
			Movies.Add(stardustCrusaders);
			jotaro.Movies.Add(stardustCrusaders);
			jonathan.Movies.Add(stardustCrusaders);

			List<double> movie2Ratings = new List<double> { 9.3, 7.4, 8.5, 9.4 };
			Rating stardustCrusadersRatings = new Rating(movie2Ratings);
			stardustCrusadersRatings.Movie = stardustCrusaders;
			stardustCrusaders.Ratings.Add(stardustCrusadersRatings);
			Ratings.Add(stardustCrusadersRatings);

			// third movie
			Actor vivy = new Actor(_actorIdCounter++, "Vivy Fluorite", 3102973.55);
			Actors.Add(vivy);
			Movie fluoriteEyesSong = new Movie(_movieIdCounter++, "Fluorite Eye's Song", "When highly evolved AIs set " +
				"out to eradicate mankind, the carnage that ensues fills the air with the stench of fresh blood and " +
				"burning bodies. In a desperate bid to prevent the calamity from ever occurring, a scientist bets " +
				"everything on a remnant from the past.", 125000000, "Action", 2020);

			fluoriteEyesSong.Actors.Add(vivy);
			Movies.Add(fluoriteEyesSong);
			vivy.Movies.Add(fluoriteEyesSong);

			List<double> movie3Ratings = new List<double> { 9.3, 8.4, 9.5, 9.4 };
			Rating fluoriteEyesRatings = new Rating(movie3Ratings);
			stardustCrusadersRatings.Movie = fluoriteEyesSong;
			fluoriteEyesSong.Ratings.Add(fluoriteEyesRatings);
			Ratings.Add(fluoriteEyesRatings);

			// Users
			// I honestly got kind of stuck here because I hadn't planned it out from the beginning and it's really
			// hard to rework my entire program
			User userOne = new User(_userIdCounter++, "Tim");
			User userTwo = new User(_userIdCounter++, "Larry");

			Users.Add(userOne);
			Users.Add(userTwo);
		}
	}
}
