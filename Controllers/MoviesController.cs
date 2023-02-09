using IntroToLinqAndASP.Data;
using IntroToLinqAndASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLinqAndASP.Controllers
{
	public class MoviesController : Controller
	{
		public IActionResult Index()
		{
			List<Movie> movies = Context.Movies.Where(m => m.Id >= 0).ToList();

			return View("Index", movies);
		}

		public IActionResult GetMovieInfo(int id)
		{
			Movie movie = Context.Movies.First(m => m.Id == id);

			return View("Details", movie);
		}

		public IActionResult GetAllInGenre(string genre)
		{
			List<Movie> movies = Context.Movies.Where(m => m.Genre.Contains(genre)).ToList();

			return View("Index", movies);
		}

		public IActionResult MoviesInBudget(double budget)
		{
			List<Movie> movies = Context.Movies.Where(m =>
			{
				return m.Budget < budget;
			}).ToList();

			return View("Index", movies);
		}

		public IActionResult MoviesInThe90s()
		{
			List<Movie> movies = Context.Movies.Where(m => m.ReleaseYear >= 1990 && m.ReleaseYear < 2000).ToList();
			
			return View("Index", movies);
		}

		// I know I screwed this one up somehow but I don't know how to fix it 
		// I can't call .average on movie.Ratings.Average(); unless I use .first and then I don't know how to return it 
		// So I'm just returning the movie context and solving average in the view 
		public IActionResult CalculateOverallRating(int id)
		{
			// get movie of id
			Movie movie = Context.Movies.First(m => m.Id == id);

			return View("AverageRating", movie);
		}

	}
}
