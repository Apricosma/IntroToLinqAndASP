﻿using IntroToLinqAndASP.Data;
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
	}
}
