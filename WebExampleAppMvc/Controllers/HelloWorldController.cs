using Microsoft.AspNetCore.Mvc;

namespace WebExampleAppMvc.Controllers
{
	public class HelloWorldController : Controller
	{
		/// <summary>
		/// https://localhost:5011/HelloWorld
		/// </summary>
		/// <returns></returns>
		[HttpGet()]
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// https://localhost:5011/HelloWorld/Welcome?name=Test&numtimes=3
		/// </summary>
		/// <param name="name"></param>
		/// <param name="numTimes"></param>
		/// <returns></returns>
		[HttpGet()]
		public IActionResult Welcome(string name, int numTimes = 1)
		{
			ViewData["Message"] = $"Hello {name}";
			ViewData["NumTimes"] = numTimes;
			return View();
		}
	}
}
