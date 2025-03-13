using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Entities.Services;
using App.Domain.Services.AppServices;
using App.EndPoints.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace App.EndPoints.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICategoryAppService _categoryAppService;
		private readonly ISubCategoryAppService _subCategoryAppService;
		private readonly IServiceAppService _serviceAppService;
		private readonly IMemoryCache _memoryCache;

		public HomeController(ILogger<HomeController> logger,
            ICategoryAppService categoryAppService,
            ISubCategoryAppService subCategoryAppService,
            IServiceAppService serviceAppService,
			IMemoryCache memoryCache)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _serviceAppService = serviceAppService;
            _subCategoryAppService = subCategoryAppService;
			_memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
		{
            string categoriesCacheKey = "CategoriesCacheKey";
            string servicesCacheKey = "ServicesCacheKey";

            if (!_memoryCache.TryGetValue(servicesCacheKey, out List<Service> services))
            {
                services = await _serviceAppService.GetAll(default);
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _memoryCache.Set(servicesCacheKey, services, cacheEntryOptions);
            }
            ViewBag.Services = services;

            if (!_memoryCache.TryGetValue(categoriesCacheKey, out List<Category> categories))
            {
                categories = await _categoryAppService.GetAll(default);
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _memoryCache.Set(categoriesCacheKey, categories, cacheEntryOptions);
            }
            var model = categories;

            return View(model);
        }


        public async Task<IActionResult> Categories()
        {
            string categoriesCacheKey = "CategoriesCacheKey";
            if (!_memoryCache.TryGetValue(categoriesCacheKey, out List<Category> categories))
            {
                categories = await _categoryAppService.GetAll(default);
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _memoryCache.Set(categoriesCacheKey, categories, cacheEntryOptions);
            }
            var model = categories;
            return View(model);
        }

        public async Task<IActionResult> SubCategories(int Id)
        {
            var allSubs = await _subCategoryAppService.GetAll(default);
            var model = allSubs.Where(x => x.CategoryId == Id).ToList();
            return View(model);
        }

        public async Task<IActionResult> Services(int Id)
        {
            var allServices = await _serviceAppService.GetAll(default);
            var model = allServices.Where(x => x.SubCategoryId == Id).ToList();
            return View(model);
        }

        public async Task<IActionResult> ServiceDetails(int Id)
        {
            var model = await _serviceAppService.GetById(Id, default);
            return View(model);
        }


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}