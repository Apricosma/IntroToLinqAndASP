using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntroToLinqAndASP.Models.ViewModels
{
	public class CompareMovies
	{
		public HashSet<Movie> Movies { get; set; }

		public List<SelectListItem> MovieSelects { get; } = new List<SelectListItem>();

		public int movieOne { get; set; }
		public int movieTwo { get; set; }

		public CompareMovies(HashSet<Movie> movies) 
		{
			foreach(Movie m in movies)
			{
				MovieSelects.Add(new SelectListItem(m.Name, m.Id.ToString()));
			}
		}

		public CompareMovies()
		{

		}
	}
}
