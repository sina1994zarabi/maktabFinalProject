using App.Domain.Core.Entities.User;
using App.EndPoints.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace App.EndPoints.MVC.Controllers
{
    
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;


        public AccountController(SignInManager<AppUser> signInManager,
                                 UserManager<AppUser> userManager
                                 )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);


            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" , username = user.UserName});
                else if (roles.Contains("Client"))
                    return RedirectToAction("Index", "Dashboard", new { area = "Client", username = user.UserName });
                else if (roles.Contains("Expert"))
                    return RedirectToAction("Index", "Dashboard", new { area = "Expert", username = user.UserName });
            }

            ModelState.AddModelError("", "ورود ناموفق");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (model.Role == "Client")
                    await _userManager.AddToRoleAsync(user, "Client");
                else if (model.Role == "Expert")
                    await _userManager.AddToRoleAsync(user, "Expert");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
