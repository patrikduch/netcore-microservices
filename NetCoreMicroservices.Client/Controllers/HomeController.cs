using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreMicroservices.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreMicroservices.Client.Controllers
{
    /// <summary>
    /// MVC controller for root page.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Default constructor for HomeController
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _httpClient = httpClientFactory.CreateClient("NetcoreMicroservicesAPIClient");
            _logger = logger;
        }

        /// <summary>
        /// Index page of the app
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/product");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            return View(productList);
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
