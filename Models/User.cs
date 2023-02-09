using IntroToLinqAndASP.Controllers;

namespace IntroToLinqAndASP.Models
{
	public class User
	{
		private int _id;
		public int Id { get { return _id; } }

		private string _name;
		public string Name { get { return _name; } }

		public List<Rating> Ratings { get; set; }
		public HashSet<Movie> Movies { get; set; }

		public User(int id, string name)
		{
			_id = id;
			_name = name;
		}
	}
}
