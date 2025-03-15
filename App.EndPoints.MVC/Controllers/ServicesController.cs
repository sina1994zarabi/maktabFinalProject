using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Entities.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace App.EndPoints.MVC.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceAppService _serviceAppService;
        private readonly IMemoryCache _memoryCache;

        public ServicesController(IServiceAppService serviceAppService,IMemoryCache memoryCache)
        {
            _serviceAppService = serviceAppService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            string servicesCacheKey = "ServicesCacheKey";
            if (!_memoryCache.TryGetValue(servicesCacheKey, out List<Service> model))
            {
                model = await _serviceAppService.GetAll(default);
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _memoryCache.Set(servicesCacheKey, model, cacheEntryOptions);
            }
            return View(model);
        }


    }
}
