using Microsoft.AspNetCore.Mvc;
using ValiantApp.Data;
using ValiantApp.Repository;
using ValiantApp.ViewModel;

namespace ValiantApp.Controllers
{
    public class SwitchController : Controller
    {

            private readonly ISwitchRepository dashboardRespository;
            private readonly IPhotoRepository photoService;

            public SwitchController(ISwitchRepository dashboardRespository, IPhotoRepository photoService)
            {
                this.dashboardRespository = dashboardRespository;
                this.photoService = photoService;
            }

            public async Task<IActionResult> Index()
            {
                return View();
            }
     }
}
