using Microsoft.AspNetCore.Mvc;

namespace AspNet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
