using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using ValiantApp.Data;
using ValiantApp.Models;
using ValiantApp.Repository;
using ValiantApp.ViewModel;

namespace ValiantApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository clubRepository;
        private readonly IPhotoRepository photoRepository;

        public ClubController(IClubRepository clubRepository, IPhotoRepository photoRepository)
        {
            this.clubRepository = clubRepository;
            this.photoRepository = photoRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await clubRepository.GetByIdAsync(id);
            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubVM CCVM)
        {
            if (ModelState.IsValid)
            {
                var image = await photoRepository.AddPhotoAsync(CCVM.Image);
                var club = new Club
                {
                    Name = CCVM.Name,
                    Desc = CCVM.Desc,
                    ProfileImage = image.Url.ToString(),
                    Address = new Address
                    {
                        Street = CCVM.Address.Street,
                        City = CCVM.Address.City,
                    }
                };
                clubRepository.Add(club);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Failed");
            return View(CCVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var club = await clubRepository.GetByIdAsync(id);
            if (club == null)
                return View("Error");
            var CVM = new EditClubVM
            {
                Name = club.Name,
                Desc = club.Desc,
                AddressId = club.AddressId,
                URL = club.ProfileImage,
                Address = new Address
                {
                    Street = club.Address.Street,
                    City = club.Address.City,
                },
                Category = club.Category
            };
            return View(CVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubVM ECVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                return View("Edit", ECVM);
            }
            var Uclub = await clubRepository.GetByIdAsyncNoTrack(id);
            if (Uclub != null)
            {
                await photoRepository.DeletePhotoAsync(Uclub.ProfileImage);
                var result = await photoRepository.AddPhotoAsync(ECVM.Image);
                var club = new Club
                {
                    Id = id,
                    Name = ECVM.Name,
                    Desc = ECVM.Desc,
                    ProfileImage = result.Url.ToString(),
                    AddressId = ECVM.AddressId,
                    Address = new Address
                    {
                        Street = ECVM.Address.Street,
                        City = ECVM.Address.City
                    }
                };
                clubRepository.Update(club);
                return RedirectToAction("Index");
            }
            else
                return View(ECVM);
        }

    }
}
