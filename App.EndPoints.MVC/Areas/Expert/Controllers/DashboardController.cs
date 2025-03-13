using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Expert.Controllers
{
    [Area("Expert")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IExpertAppService _expertAppService;


        public DashboardController(UserManager<AppUser> userManager,
                                   IExpertAppService expertAppService)
        {
            _userManager = userManager;
            _expertAppService = expertAppService;
        }

        public async Task<IActionResult> Index(string username)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUser = currentUser;
            return View();
        }

        public async Task<IActionResult> Profile()
        {
           var model = await _userManager.GetUserAsync(User);
           return View(model);
        }

        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var expert = await _expertAppService.GetExpertByUserId(user.Id, default);
            var model = new UpdateExpertDto
            {
                Id = expert.Id,
                AppUserId = expert.AppUserId,
                Email = expert.AppUser.Email,
                FullName = expert.FullName,
                PhoneNumber = expert.PhoneNumber,
                ImagePath = expert.AppUser.ProfilePicture,
                Username = expert.AppUser.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UpdateExpertDto model)
        {
            if (!ModelState.IsValid) { return View(model); }
            await _expertAppService.Update(model, default, model.Image);
            return RedirectToAction("Profile");
        }






    }
}
