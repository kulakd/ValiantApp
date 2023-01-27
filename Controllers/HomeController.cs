using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValiantApp.Models;

namespace ValiantApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}