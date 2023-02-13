using IntroToLinqAndASP.Data;
using IntroToLinqAndASP.Models;
using IntroToLinqAndASP.Models.ViewModels;
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

		[HttpPost]
		public IActionResult CreateRating(double Rating, string Comment, int UserId, int MovieId)
		{
			Movie movie = Context.Movies.First(m => m.Id == MovieId);
			try
			{
				if (Rating >= 1 && Rating <= 10)
				{
					Context.CreateRating(Rating, Comment, MovieId, UserId);
				}
				else
				{
					// deny the input? I don't know how to do this other than to return an error
					return BadRequest("Rating must be between 1 and 10");
				}
			} catch(Exception ex)
			{
				return BadRequest();
			}
			return RedirectToAction("Details", movie);
		}

		// I'm really struggling with httpget and httppost, I don't really understand what
		// they're doing. 
		// I understand vm passing, but not "passing an object from a get to a post" etc
		[HttpGet]
		public IActionResult CompareMovies()
		{
			CompareMovies vm = new CompareMovies(Context.Movies);

			return View(vm);
		}

		[HttpPost]
		public IActionResult CompareMovies(CompareMovies vm)
		{
			Movie selectMovieOne = Context.Movies.First(m => m.Id == vm.movieOne);
			Movie selectMovieTwo = Context.Movies.First(m => m.Id == vm.movieTwo);

			return RedirectToAction("DisplayComparedMovies", vm);
		}

		public IActionResult DisplayComparedMovies(int movieOne, int movieTwo) 
		{
			List<Movie> movies = new List<Movie>();

			Movie movie1 = Context.Movies.First(m => m.Id == movieOne);
			Movie movie2 = Context.Movies.First(m => m.Id == movieTwo);

			movies.Add(movie1);
			movies.Add(movie2);

			return View("DisplayComparedMovies", movies);
		}
	}
}
