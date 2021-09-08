// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebExampleAppMvc.Controllers
{
	public class HelloWorldController : BaseController
	{
		#region Constructor and destructor

		public HelloWorldController(ILogger<HelloWorldController> logger) : base(logger)
		{
		}

        #endregion

        #region Public and private methods

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

        #endregion
    }
}
