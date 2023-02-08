namespace IntroToLinqAndASP.Models
{
	public class Movie
	{
		private int _id;
		public int Id { get { return _id; } }

		private string _name;
		public string Name { get { return _name; } }

		private string _description;
		public string Description { get { return _description; } }

		private int _budget;
		public int Budget { get { return _budget; } }

		// an int for the sake of simplicity instead of a datetime to a manual date
		private int _releaseYear;
		public int ReleaseYear { get { return _releaseYear; } }

		private string _genre;
		public string Genre { get { return _genre; } }

		public HashSet<Actor> Actors = new HashSet<Actor>();

		public List<Rating> Ratings = new List<Rating>();

		public Movie(int id, string name, string description, int budget, string genre, int releaseYear)
		{
			_id = id;
			_name = name;
			_description = description;
			_genre = genre;
			_budget = budget;
			_releaseYear = releaseYear;
		}
			
	}
}
