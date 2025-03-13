using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.ReviewDto;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace App.EndPoints.MVC.Areas.Client.Controllers
{
    public class ServiceOfferingController : Controller
    {

        private readonly IClientAppService _clientAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IServiceRequestAppService _requestAppService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMemoryCache _memoryCache;

        public ServiceOfferingController(IClientAppService clientAppService,
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

        public async Task<IActionResult> ViewServiceOfferings(int Id)
        {
            ViewBag.ServiceRequest = await _requestAppService.GetById(Id, default);
            var model = await _clientAppService.GetServicesOffering(Id, default);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SelectServiceOffer(int id)
        {
            await _clientAppService.SelectServiceOffering(id, default);
            return RedirectToAction("ViewServiceRequests");
        }

        [HttpPost]
        public async Task<IActionResult> CancelServiceOffering(int Id)
        {
            await _clientAppService.CancelServiceOffering(Id, default);
            TempData["SuccessMessage"] = "سفارش با موفقیت لغو شد";
            return RedirectToAction("ViewServiceRequests");
        }

        public async Task<IActionResult> LeaveReview(int Id)
        {
            var request = await _requestAppService.GetById(Id, default);
            var createReviewDto = new CreateReviewDto
            {
                ClientId = request.ClientId,
                ServiceOfferingId = request.ServiceOfferings.FirstOrDefault()?.Id ?? 0
            };

            ViewBag.ServiceRequestId = request.Id;
            ViewBag.ServiceOfferingId = createReviewDto.ServiceOfferingId;
            ViewBag.ClientId = createReviewDto.ClientId;


            return View(createReviewDto);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(CreateReviewDto createReviewDto, CancellationToken cancellationToken)
        {
            await _clientAppService.SubmitReview(createReviewDto, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pay(int Id)
        {
            try
            {
                await _clientAppService.ProcessPayment(Id, default);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ViewServiceRequests");
            }
            TempData["SuccessMessage"] = "پرداخت با موفقیت انجام شد";
            return RedirectToAction("ViewServiceRequests");

        }
    }
}
