using AspNet.Models;
using AspNet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNet.Controllers
{
    public class HomeController : Controller // inherits base class from ASP.NET core 
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProfileService _profileService;

        // Constructor for HomeController
        public HomeController(ILogger<HomeController> logger, IProfileService profileService)
        {
            // Dependency Injection: injects an instance of the logger and profile service into the controller; now our controller depends on these services
            // here we instantiate the logger and profile service
            _logger = logger;
            _profileService = profileService;
        }

        [HttpGet("")] // flag: attribute routing, when / is requested, this method is called (default route)
        [HttpGet("Home")] // flag: attribute routing, when /Home is requested, this method is called
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
            // Get the data for the About Me page using the profile service thru dependency injection (DI)
            var model = _profileService.GetAboutMeData();
            return View(model);
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            return RedirectToAction(actionName: "AboutMe", controllerName: "Home");
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("Contact")]
        // Model binding: the process of mapping data from an HTTP request to an object in the application
        // pass in our ContactViewModel model as a parameter
        public RedirectToActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the contact form submission (e.g., send an email)
                // For now, just log the message
                _logger.LogInformation("Contact form submitted by {Name} with message: {Message}", model.Name, model.Message);

                return RedirectToAction(actionName: "AboutMe", controllerName: "Home");
            }

            // if model state is INVALID, just return the view with the model
            return RedirectToAction(actionName: "AboutMe", controllerName: "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
