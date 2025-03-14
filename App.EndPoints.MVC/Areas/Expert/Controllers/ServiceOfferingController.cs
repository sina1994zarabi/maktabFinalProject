using App.Domain.Core.Contract.AppService;
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
        private readonly UserManager<AppUser> _userManager;

        public ServiceOfferingController(IExpertAppService expertAppService
                                         ,UserManager<AppUser> userManager,
                                          IServiceOfferingAppService serviceOfferingAppService)
        {
            _expertAppService = expertAppService;
            _userManager = userManager;
            _serviceOfferingAppService = serviceOfferingAppService;
        }

        // view All My Offers
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var expert = await _expertAppService.GetExpertByUserId(user.Id, default);
            var model = await _expertAppService.GetServiceOfferings(expert.Id,default);
            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var model = await _serviceOfferingAppService.GetById(Id, default);
            return View(model);
        }


    }
}
