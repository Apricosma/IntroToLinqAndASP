namespace IntroToLinqAndASP.Models
{
	public class Rating
	{
		private double _userRating;
		public double UserRating { get { return _userRating; } }
		public User User { get; set; }

		public Movie Movie { get; set; }

		public Rating(double rating, User user, Movie movie)
		{
			_userRating = rating;
			User = user;
			Movie = movie;
		}
	}
}
