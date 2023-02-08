namespace IntroToLinqAndASP.Models
{
	public class User
	{
		private int _id;
		public int Id { get { return _id; } }

		private string _name;
		public string Name { get { return _name; } }

		public User(int id, string name)
		{
			_id = id;
			_name = name;
		}
	}
}
