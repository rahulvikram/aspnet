using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Controllers
{
    // all action methods in this controller require user to be authenticated
    // i.e. check for valid user session before allowing access to any action
    [Authorize] // applies authorization to all actions in this controller
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
