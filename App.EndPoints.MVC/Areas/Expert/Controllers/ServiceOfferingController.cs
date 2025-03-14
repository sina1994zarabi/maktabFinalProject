using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.ServiceOfferingDto;
using App.Domain.Core.DTOs.ServiceRequestDto;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Expert.Controllers
{
    [Area("Expert")]
    public class ServiceOfferingController : Controller
    {
        private readonly IExpertAppService _expertAppService;
        private readonly IServiceOfferingAppService _serviceOfferingAppService;
        private readonly IServiceRequestAppService _serviceRequestAppService;
        private readonly UserManager<AppUser> _userManager;

        public ServiceOfferingController(IExpertAppService expertAppService
                                         ,UserManager<AppUser> userManager,
                                          IServiceOfferingAppService serviceOfferingAppService,
                                          IServiceRequestAppService serviceRequestAppService)
        {
            _expertAppService = expertAppService;
            _userManager = userManager;
            _serviceOfferingAppService = serviceOfferingAppService;
            _serviceRequestAppService = serviceRequestAppService;
        }

        // view All My Offers
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var expert = await _expertAppService.GetExpertByUserId(user.Id, default);
            var model = await _expertAppService.GetServiceOfferings(expert.Id,default);
            ViewBag.Message = TempData["Message"] as string;
            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var model = await _serviceOfferingAppService.GetById(Id, default);
            return View(model);
        }

        public async Task<IActionResult> SubmitOffer(int Id)
        {
            var user = await _userManager.GetUserAsync(User);
            var expert = await _expertAppService.GetExpertByUserId(user.Id,default);
            var servicerequest = await _serviceRequestAppService.GetById(Id,default);
            ViewBag.Expert = expert;
            ViewBag.ServiceRequest = servicerequest;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOffer(CreateServiceOfferingDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _serviceOfferingAppService.Create(model, default);
            TempData["Message"] = "پیشنهاد با موفقیت ارسال شد";
            return RedirectToAction("Index");
        }
    }
}
