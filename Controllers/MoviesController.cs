using IntroToLinqAndASP.Data;
using IntroToLinqAndASP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IntroToLinqAndASP.Controllers
{
	public class MoviesController : Controller
	{
		public IActionResult Index()
		{
			List<Movie> movies = Context.Movies.Where(m => m.Id >= 0).ToList();

			return View("Index", movies);
		}

		public IActionResult Details(int id)
		{
			Movie movie = Context.Movies.First(m => m.Id == id);

			ViewBag.AverageRating = CalculateOverallRating(id);

			return View("Details", movie);
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
		public double CalculateOverallRating(int id)
		{
			// get movie of id
			Movie movie = Context.Movies.First(m => m.Id == id);

			if (movie.Ratings.Any())
			{ 
				return movie.Ratings.Average(r =>
				{
					return (double)r.UserRating;
				});
			} else
			{
				return 0;
			}
		}

		//[HttpGet]
		//public IActionResult AddRating(Rating rating)
		//{
		//	if (rating == null)
		//	{
		//		return NotFound();
		//	} else if (rating.UserRating == null)
		//	{
		//		ViewBag.Rating = rating;
		//		return View();
		//	} else
		//	{
		//		return RedirectToAction("Error");
		//	}
		//}

		//[HttpPost]
		//public IActionResult AddRating(Rating rating, int movieId, int userId)
		//{
		//	Movie movie = Context.Movies.First(s => s.Id == movieId);
		//	User user = Context.Users.First(u => u.Id == userId);

		//	user.Ratings.Add(rating);
		//	movie.Ratings.Add(rating);
			
		//	return RedirectToAction("Details", movieId);
		//}

		//[HttpGet]
		//public IActionResult Create()
		//{
		//	return View();
		//}

		[HttpPost]
		public IActionResult CreateRating(double Rating, string Comment, int UserId, int MovieId)
		{
			Context.CreateRating(Rating, Comment, MovieId, UserId);
			Movie movie = Context.Movies.First(m => m.Id == MovieId);

			return View("Details", movie);
		}
	}
}
