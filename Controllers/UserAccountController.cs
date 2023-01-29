using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ValiantApp.Data;
using ValiantApp.Models;
using ValiantApp.ViewModel;

namespace ValiantApp.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        

        public UserAccountController(UserManager<User> userManager,SignInManager<User> signInManager,AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
               
        [HttpGet]
        [Route("UserAccount/Login")]
        public IActionResult Login()
        {
            var response = new LogVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogVM LVM)
        {
            if (!ModelState.IsValid) return View(LVM);
            var user = await userManager.FindByEmailAsync(LVM.EmailAddress);
            if (user != null)
            {
                var Checkpassword = await userManager.CheckPasswordAsync(user, LVM.Password);
                if (Checkpassword)
                {
                    var result = await signInManager.PasswordSignInAsync(user, LVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Event");
                    }
                }
                TempData["Error"] = "TRY AGAIN";
                return View(LVM);
            }
            TempData["Error"] = "TRY AGAIN";
            return View(LVM);
        }

        [HttpGet]
        [Route("UserAccount/Register")]
        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            User user = await userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "THIS EMAIL IS ALREADY IN USE";
                return View(registerVM);
            }
            User newUser = new User()
            {
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await userManager.CreateAsync(newUser, registerVM.Password);
            if (newUserResponse.Succeeded)
                await userManager.AddToRoleAsync(newUser, Roles.User);
            return RedirectToAction("Index", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Event");
        }

    }
}

