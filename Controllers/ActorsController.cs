using IntroToLinqAndASP.Data;
using IntroToLinqAndASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLinqAndASP.Controllers
{
	public class ActorsController : Controller
	{
		public IActionResult HighestPaidActor()
		{
			List<Actor> actors = Context.Actors.OrderBy(a => a.Salary).ToList();
			Actor actor = actors.First(); 

			return View("Details", actor);
		}
	}
}
