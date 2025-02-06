using AspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNet.Controllers
{
    public class HomeController : Controller // inherits base class from ASP.NET core 
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor for HomeController
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")] // flag: attribute routing, when / is requested, this method is called (default route)
        public IActionResult Index()
        {
            return View();
        }

        // example: this specifies website/HomeController/Privacy as the route (HomeController controller, Privacy action)
        [HttpGet("Privacy")] // flag: attribute routing, when /Privacy is requested, this method is called
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("AboutMe")]
        public IActionResult AboutMe()
        {
            // dictionary of current jobs
            var jobs = new Dictionary<string, string>
            {
                { "Software Engineer", "OSU CASS" },
                { "ML Researcher", "STAR Lab" }
            };

            // ViewBag is a dynamic object that can be used to pass data between the controller and the view at runtime (very similar to Vue.js' props or reactive([]) data)
            ViewBag.Jobs = jobs;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
