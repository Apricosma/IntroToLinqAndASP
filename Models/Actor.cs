namespace IntroToLinqAndASP.Models
{
	public class Actor
	{
		private int _id;
		public int Id { get { return _id; } }

		private string _name;
		public string Name { get { return _name;} }

		public HashSet<Movie> Movies = new HashSet<Movie>();

		private double _salary;
		public double Salary { get { return _salary; } }

		public Actor(int id, string name, double salary)
		{
			_id = id;
			_name = name;
			_salary = salary;
		}
	}
}
