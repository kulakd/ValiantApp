using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValiantApp.Data;
using ValiantApp.Models;
using ValiantApp.Repository;
using ValiantApp.ViewModel;

namespace ValiantApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository eventRepository;
        private readonly IPhotoRepository photoRepository;

        public EventController(IEventRepository eventRepository, IPhotoRepository photoRepository)
        {
            this.eventRepository = eventRepository;
            this.photoRepository = photoRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await eventRepository.GetAll();
            return View(events);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Event events = await eventRepository.GetByIdAsync(id);
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateEventVM CEVM)
        {
            if (ModelState.IsValid)
            {
                var image = await photoRepository.AddPhotoAsync(CEVM.Image);
                var events = new Event
                {
                    Name = CEVM.Name,
                    Desc = CEVM.Desc,
                    Image = image.Url.ToString(),
                    Address = new Address
                    {
                        Street = CEVM.Address.Street,
                        City = CEVM.Address.City,
                    }
                };
                eventRepository.Add(events);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Failed");
            return View(CEVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var events = await eventRepository.GetByIdAsync(id);
            if (events == null)
                return View("Error");
            var CEVM = new EditEventVM
            {
                Name = events.Name,
                Desc = events.Desc,
                AddressId = events.AddressId,
                URL = events.Image,
                Address = new Address
                {
                    Street = events.Address.Street,
                    City = events.Address.City,
                },
                eventCategory = events.EventCategory
            };
            return View(CEVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventVM EEVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                return View("Edit", EEVM);
            }
            var Uevent = await eventRepository.GetByIdAsyncNoTrack(id);
            if (Uevent != null)
            {
                await photoRepository.DeletePhotoAsync(Uevent.Image);
                var result = await photoRepository.AddPhotoAsync(EEVM.Image);
                var events = new Event
                {
                    Id = id,
                    Name = EEVM.Name,
                    Desc = EEVM.Desc,
                    Image = result.Url.ToString(),
                    AddressId = EEVM.AddressId,
                    Address = new Address
                    {
                        Street = EEVM.Address.Street,
                        City = EEVM.Address.City
                    }
                };
                eventRepository.Update(events);
                return RedirectToAction("Index");
            }
            else
                return View(EEVM);

        }

    }
}
