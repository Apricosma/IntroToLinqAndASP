namespace IntroToLinqAndASP.Models
{
	public class Rating
	{
		private int _userRating;
		public int UserRating { get { return _userRating; } }
		public User User { get; set; }

		public Movie Movie { get; set; }

		public Rating(int rating, User user, Movie movie)
		{
			_userRating = rating;
			User = user;
			Movie = movie;
		}
	}
}
