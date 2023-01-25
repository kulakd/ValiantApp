using Microsoft.AspNetCore.Mvc;

namespace Valiant.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
