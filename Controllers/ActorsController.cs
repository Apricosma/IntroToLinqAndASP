using IntroToLinqAndASP.Data;
using IntroToLinqAndASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLinqAndASP.Controllers
{
	public class ActorsController : Controller
	{
		public IActionResult Index()
		{
			List<Actor> actors = Context.Actors.Where(a => a.Id >= 0).ToList();

			return View("Index", actors);
		}

		public IActionResult Details(int id)
		{
			Actor actor = Context.Actors.First();

			return View("Details", actor);
		}

		public IActionResult HighestPaidActor()
		{
			List<Actor> actors = Context.Actors.OrderBy(a => a.Salary).ToList();
			Actor actor = actors.Last(); 

			return View("HighestPaidActor", actor);
		}
	}
}
