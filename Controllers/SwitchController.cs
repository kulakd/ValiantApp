using Microsoft.AspNetCore.Mvc;
using ValiantApp.Data;
using ValiantApp.Repository;
using ValiantApp.ViewModel;

namespace ValiantApp.Controllers
{
    public class SwitchController : Controller
    {
            public async Task<IActionResult> Index()
            {
                return View();
            }
     }
}
