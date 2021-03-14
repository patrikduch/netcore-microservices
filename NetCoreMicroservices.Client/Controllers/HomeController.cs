using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreMicroservices.Client.Data;
using NetCoreMicroservices.Client.Models;
using System.Diagnostics;

namespace NetCoreMicroservices.Client.Controllers
{
    /// <summary>
    /// MVC controller for root page.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Default constructor for HomeController
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Index page of the app
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(ProductContext.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
