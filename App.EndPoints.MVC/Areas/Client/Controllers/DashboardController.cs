using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.DTOs.ReviewDto;
using App.Domain.Core.DTOs.ServiceRequestDto;
using App.Domain.Core.Entities.Services;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace App.EndPoints.MVC.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "Client")]
    public class DashboardController : Controller
    {

        private readonly IClientAppService _clientAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IServiceRequestAppService _requestAppService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMemoryCache _memoryCache;

        public DashboardController(IClientAppService clientAppService,
            UserManager<AppUser> userManager,
            IServiceAppService serviceAppService,
            IServiceRequestAppService serviceRequestAppService,
            IMemoryCache memoryCache)
        {
            _clientAppService = clientAppService;
            _userManager = userManager;
            _serviceAppService = serviceAppService;
            _requestAppService = serviceRequestAppService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index(string username)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUser = currentUser;
            return View();
        }

        public async Task<IActionResult> ViewProfile()
        {
            //string cachKey = "CurrentUser";
            //if (!_memoryCache.TryGetValue(cachKey, out AppUser model))
            //{
                var model = await _userManager.GetUserAsync(User);
                //_memoryCache.Set(cachKey, model,TimeSpan.FromMinutes(30));
            //}
            return View(model);
        }

        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var client = await _clientAppService.GetClientByUserId(user.Id,default);
            var model = new UpdateClientprofileDto
            {
                Id = client.Id,
                AppUserId = client.AppUserId,
                Email = client.AppUser.Email,
                FullName = client.FullName,
                PhoneNumber = client.PhoneNumber,
                ImagePath = client.AppUser.ProfilePicture,
                Username = client.AppUser.UserName
            };
            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UpdateClientprofileDto model)
        {
            if (!ModelState.IsValid) { return View(model); }
            await _clientAppService.Update(model, default,model.Image);
            return RedirectToAction("ViewProfile");
        }


        public async Task<IActionResult> UpdateBalance()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBalance(decimal balance)
        {
            if (balance <= 100)
            {
                TempData["ErrorMessage"] = "لطفاً مبلغ صحیح وارد کنید.";
                return View(); 
            }
            var user = await _userManager.GetUserAsync(User);
            var client = await _clientAppService.GetClientByUserId(user.Id, default);
            await _clientAppService.UpdateBalance(client.Id, balance, default);
            TempData["SuccessMessage"] = "افزایش موجودی با موفقیت انجام شد.";
            return View();
        }
    }
}
