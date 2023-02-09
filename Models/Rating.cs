namespace IntroToLinqAndASP.Models
{
	public class Rating
	{
		private double _userRating;
		public double UserRating { get { return _userRating; } }
		public User User { get; set; }

		public Movie Movie { get; set; }

		private string? _userComment;

		public string? UserComment {
			get { return _userComment; } 
			set
			{
				if (value.Length > 2 && value.Length < 250)
				{
					_userComment = value;
				} else
				{
					throw new ArgumentException("Comments must be between 2 and 250 characters");
				}
			}
		}

		public Rating(double rating, User user, Movie movie)
		{
			_userRating = rating;
			User = user;
			Movie = movie;
			UserComment = null;
		}

		public Rating(double rating, User user, Movie movie, string? comment)
		{
			_userRating = rating;
			User = user;
			Movie = movie;
			UserComment = comment;
		}
	}
}
