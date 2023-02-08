namespace IntroToLinqAndASP.Models
{
	public class Rating
	{
		private List<double> _movieRating;
		public List<double> movieRating { get { return _movieRating; } }

		public Movie Movie { get; set; }

		public Rating(List<double> movieRating)
		{
			_movieRating = movieRating;
		}
	}
}
