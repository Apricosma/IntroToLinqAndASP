using IntroToLinqAndASP.Models;
using System.Runtime.CompilerServices;

namespace IntroToLinqAndASP.Data
{
	public class Context
	{
		// this is a colossal mess but refactoring it would take too much time 
		public static HashSet<Actor> Actors = new HashSet<Actor>();
		public static HashSet<Movie> Movies = new HashSet<Movie>();
		public static List<Rating> Ratings = new List<Rating>();
		public static HashSet<User> Users = new HashSet<User>();

		private static int _actorIdCounter = 0;
		private static int _movieIdCounter = 1000;
		private static int _userIdCounter = 100000;

		public static void CreateRating(double rating, string comment, int MovieId, int UserId)
		{
			User user = Context.Users.First(u => u.Id == UserId);
			Movie movie = Context.Movies.First(m => m.Id == MovieId);
			Rating newRating = new Rating(rating, user, movie, comment);

			Ratings.Add(newRating);
			user.Ratings.Add(newRating);
			movie.Ratings.Add(newRating);
		}

		static Context()
		{           
			// Users
			User userOne = new User(_userIdCounter++, "Tim");
			User userTwo = new User(_userIdCounter++, "Larry");
			User userThree = new User(_userIdCounter++, "Bill");

			Users.Add(userOne);
			Users.Add(userTwo);
			Users.Add(userThree);

			// first movie
			Actor jenny = new Actor(_actorIdCounter++, "Jenny Monroe", 1539243.23);
			Actors.Add(jenny);
			Movie avgRomcom = new Movie(_movieIdCounter++, "An average romcom", "Just the average romcom where " +
				"both characters move away at the end but then meet again a few years later", 10000000, "Romcom", 1993);

			avgRomcom.Actors.Add(jenny);
			Movies.Add(avgRomcom);
			jenny.Movies.Add(avgRomcom);

			Rating RomcomRating1 = new Rating(7.3, userOne, avgRomcom);
			userOne.Ratings.Add(RomcomRating1);
			avgRomcom.Ratings.Add(RomcomRating1);

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

			Rating stardustRating1 = new Rating(8.7, userOne, stardustCrusaders);
			userOne.Ratings.Add(stardustRating1);
			stardustCrusaders.Ratings.Add(stardustRating1);

			Rating stardustRating2 = new Rating(8.4, userTwo, stardustCrusaders);
			userTwo.Ratings.Add(stardustRating2);
			stardustCrusaders.Ratings.Add(stardustRating2);

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

			Rating fluoriteRating1 = new Rating(9.1, userOne, fluoriteEyesSong);
			userOne.Ratings.Add(fluoriteRating1);
			fluoriteEyesSong.Ratings.Add(fluoriteRating1);

			Rating fluoriteRating2 = new Rating(9.4, userTwo, fluoriteEyesSong);
			userTwo.Ratings.Add(fluoriteRating2);
			fluoriteEyesSong.Ratings.Add(fluoriteRating2);

			Rating fluoriteRating3 = new Rating(9.3, userThree, fluoriteEyesSong);
			userThree.Ratings.Add(fluoriteRating3);
			fluoriteEyesSong.Ratings.Add(fluoriteRating3);

		}
	}
}
