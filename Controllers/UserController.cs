using Microsoft.AspNetCore.Mvc;

namespace ValiantApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
