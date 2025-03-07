using App.Domain.Core.Contract.AppService;
using App.Domain.Core.DTOs.ServiceDto;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceAppService _serviceAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(IServiceAppService serviceAppService,
            ISubCategoryAppService subCategoryAppService,
            ILogger<ServiceController> logger
            )
        {
            _serviceAppService = serviceAppService;
            _subCategoryAppService = subCategoryAppService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceAppService.GetAll(default);
            return View(services);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SubCategories = await _subCategoryAppService.GetAll(default);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SubCategories = await _subCategoryAppService.GetAll(default);
                return View(model);
            }
            await _serviceAppService.Create(model, default,model.Image);
            var timeStamp = DateTime.Now;
            _logger.LogWarning("[{Timestamp}] اضافه شدن سرویس جدید: {Title}", timeStamp, model.Title);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) 
        {
            ViewBag.SubCategories = await _subCategoryAppService.GetAll(default);
            var service = await _serviceAppService.GetById(id,default);
            if (service == null)
                return NotFound();
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateServiceDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _serviceAppService.Update(model, default,model.Image);
            var timeStamp = DateTime.Now;
            _logger.LogWarning("[{Timestamp}] ویرایش سرویس: {Title}", timeStamp, model.Title);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _serviceAppService.GetById(id,default);
            if (service == null) return NotFound();
            return View(service);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _serviceAppService.Delete(id,default);
            return RedirectToAction("Index");
        }
    }
}
