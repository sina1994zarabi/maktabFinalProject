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
		private readonly IServiceAppService _serviceAppService;
		private readonly IMemoryCache _memoryCache;

		public HomeController(ILogger<HomeController> logger,
            ICategoryAppService categoryAppService,
            IServiceAppService serviceAppService,
			IMemoryCache memoryCache)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _serviceAppService = serviceAppService;
			_memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
		{
            string servicesCacheKey = "ServicesCacheKey";
            string categoriesCacheKey = "CategoriesCacheKey";

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